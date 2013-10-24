using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Silver6wings.LabClassifier.Classifiers
{
    enum ClassifierLearnableBayesType
    {
        Naive,
        Fisher,
        Revised
    }

    class ClassifierMLBayes : ClassifierML
    {
        private ClassifierLearnableBayesType _classifierBayesType;

        // <Category>
        private List<string> _categoryNames; 
        // <Category, Count of Items>
        private Dictionary<string, long> _itemsCountInCategory;
        // <Category, <Feature, Count>>
        private Dictionary<string, Dictionary<string, long>> _featuresCountInCategory;

        // just for performance
        private long _featuresCountTotal;
        // just for performance <Category, Count Sum of features in this category>
        private Dictionary<string, long> _allFeaturesCountInCategory;
        // just for performance <Feature, Count Sum of features In All Category> 
        private Dictionary<string, long> _featuresCountInAllCategory;  

        public ClassifierMLBayes(ClassifierLearnableBayesType defaultBayesType = ClassifierLearnableBayesType.Revised)
        {
            _classifierBayesType = defaultBayesType;            

            _categoryNames = new List<string>();
            _itemsCountInCategory = new Dictionary<string, long>();
            _featuresCountInCategory = new Dictionary<string, Dictionary<string, long>>();

            _featuresCountTotal = -1;
            _allFeaturesCountInCategory = new Dictionary<string, long>();
            _featuresCountInAllCategory = new Dictionary<string, long>();
        }

        public override string classify(string comment)
        {
            if (_detector == null) return null;

            if(_classifierBayesType == ClassifierLearnableBayesType.Revised)
            {
                return guessByRevised(comment);
            }
            else if (_classifierBayesType == ClassifierLearnableBayesType.Naive)
            {
                return guessByNaive(comment);
            }
            else
            {
                return guessByFisher(comment);
            }
        }

        public override void train(string comment, string category)
        {
            // Add category name list
            if (!_categoryNames.Contains(category)) _categoryNames.Add(category);

            // Add items count
            if (!_itemsCountInCategory.ContainsKey(category))
            {
                _itemsCountInCategory.Add(category, 0);
            }
            _itemsCountInCategory[category]++;

            // Add feature count
            if (!_featuresCountInCategory.ContainsKey(category)) _featuresCountInCategory.Add(category, new Dictionary<string, long>());

            string[] features = _detector.detect(comment);
            foreach (string feature in features)
            {
                // Add feature Count in all Category
                if (!_featuresCountInAllCategory.ContainsKey(feature))
                {
                    _featuresCountInAllCategory.Add(feature, 0);
                }
                _featuresCountInAllCategory[feature]++;

                // Add feature Count in that Category
                if (!_featuresCountInCategory[category].ContainsKey(feature))
                {
                    _featuresCountInCategory[category].Add(feature, 0);
                }
                _featuresCountInCategory[category][feature]++;
            }
        }

        public void showModelInfo(string toPath, bool toScreen)
        {
            if (String.IsNullOrEmpty(toPath) && toScreen == false) return;            

            StringBuilder sb = new StringBuilder("\t\t{ALL}");

            // Prepare Header
            foreach (string categoryName in _featuresCountInCategory.Keys)
            {
                sb.Append(string.Format("\t{0}\t", categoryName));
            }
            sb.Append("\r\n");

            // Prepare Feature Count
            foreach (string feature in _featuresCountInAllCategory.Keys)
            {
                if (feature.Length > 7) sb.Append(feature.Substring(0,6) + '.');
                else sb.Append(feature);

                sb.Append(string.Format("\t{0}", getFeatureTotalInAllCategory(feature)));

                foreach (string category in _featuresCountInCategory.Keys)
                {
                    sb.Append(string.Format("\t{0}", getFeatureTotalInCategory(category, feature)));
                    sb.Append(string.Format("\t{0:P}", getFeatureWeightedProbByFisher(category, feature)));
                }
                sb.Append("\r\n");
            }

            // Output to screen
            if(toScreen) Console.WriteLine(sb);
           
            // Output to file
            if (!String.IsNullOrEmpty(toPath))
            {
                StreamWriter sw = new StreamWriter(toPath);
                sw.WriteLine(sb);
                sw.Close();
            }
        }
        
        // ===== 3 Guess method =====

        private string guessByNaive(string comment)
        {
            double maxProb = 0.0;
            string result = "";
            foreach (string category in _featuresCountInCategory.Keys)
            {
                double tempProb = getProbNaive(category, _detector.detect(comment));
               
                if (tempProb > maxProb)
                {
                    maxProb = tempProb;
                    result = category;
                }
            }
            return result;
        }

        private string guessByFisher(string comment)
        {
            double maxProb = 0.0;
            string result = "";
            foreach (string category in _featuresCountInCategory.Keys)
            {
                double tempProb = getProbFisher(category, _detector.detect(comment));
                if (tempProb > maxProb)
                {
                    maxProb = tempProb;
                    result = category;
                }
            }
            return result;
        }

        private string guessByRevised(string comment)
        {
            double maxProb = 0.0;
            string result = "";
            foreach (string category in _featuresCountInCategory.Keys)
            {
                double tempProb = getProbRevised(category, _detector.detect(comment));
                if (tempProb > maxProb)
                {
                    maxProb = tempProb;
                    result = category;
                }
            }
            return result;
        }

        // ===== Naive Classifier =====

        private double getProbNaive(string category, string[] features)
        {
            // get category Probability
            double catProb = getCategoryProbByItems(category);

            // count document Probability
            double docProb = 1.0;

            foreach (string feature in features)
            {
                docProb *= getFeatureWeightedProbByNaive(category, feature);
            }
            //Console.WriteLine(catProb + "x" + docProb);

            return catProb * docProb;
            //return docProb;
        }

        private double getFeatureWeightedProbByNaive(string category, string feature)
        {
            double weight = 1.0;
            double allProb = 1.0 / getCategoryNamesCount();

            double basicProb = getFeatureProbInItemCategory(category, feature);

            double totals = getFeatureTotalInAllCategory(feature);

            return (weight * allProb + basicProb * totals) / (weight + totals);
        }

        private double getFeatureProbInItemCategory(string category, string feature)
        {
            if (getItemsTotalInCategory(category) > 0)
            {
                return (double)getFeatureTotalInCategory(category, feature) / getItemsTotalInCategory(category);
            }
            return 0.0;
        }

        private double getCategoryProbByItems(string category)
        {
            if (getItemsTotalAll() > 0)
            {
                return (double)getItemsTotalInCategory(category) / getItemsTotalAll();
            }
            return 0.0;
        }

        // ===== Fisher Classifier =====

        private double getProbFisher(string category, string[] features)
        {
            double p = 1.0;

            foreach (string feature in features)
            {
                p *= getFeatureWeightedProbByFisher(category, feature);
            }

            double fscore = -2 * Math.Log(p);

            return invchi2(fscore, (features.Length+1) * 2);
        }

        private double getFeatureWeightedProbByFisher(string category, string feature)
        {
            double weight = 1.0;
            double allProb = 1.0 / getCategoryNamesCount();

            double basicProb = getFeatureProbByFisher(category, feature);

            double totals = getFeatureTotalInAllCategory(feature);

            return (weight * allProb + basicProb * totals) / (weight + totals);
        }

        private double getFeatureProbByFisher(string category, string feature)
        {
            double fpsum = 0.0;

            foreach (string catName in _categoryNames)
            {
                fpsum += getFeatureProbInItemCategory(catName, feature);
            }
            if (fpsum > 0.0)
            {
                return getFeatureProbInItemCategory(category, feature) / fpsum;
            }
            return 0.0;
        }

        private double invchi2(double chi, int df)
        {
            double m = chi / 2.0;
            double term = Math.Exp(-m);
            double sum = term;

            for (int i = 1; i < df / 2; i++)
            {
                term *= m / i;
                sum += term;
            }

            return sum > 1.0 ? 1.0 : sum;
        }

        // ===== Revised Classifier =====

        private double getProbRevised(string category, string[] features)
        {

            double catProb = getCategoryProbByFeatures(category);

            double docProb = 1.0;
            foreach (string feature in features)
            {
                docProb *= getFeatureWeightedProbByRevised(category, feature); ;
            }
            return catProb * docProb;
        }

        private double getFeatureWeightedProbByRevised(string category, string feature)
        {

            double weight = 1.0;
            double allProb = 1.0 / getCategoryNamesCount();

            double basicProb = getFeatureProbByFeatureCount(category, feature);
            double totals = getFeatureTotalInAllCategory(feature);

            return (weight * allProb + basicProb * totals) / (weight + totals);
        }

        private double getFeatureProbByFeatureCount(string category, string feature)
        {
            if (_featuresCountInAllCategory.ContainsKey(feature))
            {
                return (double)getFeatureTotalInCategory(category, feature) / getFeatureTotalInAllCategory(feature);
            }
            return 0.0;
        }

        private double getCategoryProbByFeatures(string category)
        {
            if (_featuresCountInCategory.ContainsKey(category))
            {
                return (double)getAllFeaturesTotalInCategory(category) / getAllFeaturesTotalInAllCategory();
            }
            return 0.0;
        }

        // ===== Basic Data Collection =====

        private long getFeatureTotalInCategory(string category, string feature)
        {
            if (_featuresCountInCategory[category].ContainsKey(feature))
            {
                return _featuresCountInCategory[category][feature];
            }
            return 0;
        }

        private long getFeatureTotalInAllCategory(string feature)
        {
            if (_featuresCountInAllCategory.ContainsKey(feature))
            {
                return _featuresCountInAllCategory[feature];
            }
            return 0;
        }

        private long getAllFeaturesTotalInCategory(string category)
        {
            if (_allFeaturesCountInCategory.ContainsKey(category))
            {
                return _allFeaturesCountInCategory[category];
            }

            long sum = 0;
            foreach (long count in _featuresCountInCategory[category].Values)
            {
                sum += count;
            }
            _allFeaturesCountInCategory.Add(category, sum);
            return sum;
        }

        private long getAllFeaturesTotalInAllCategory()
        {
            if (_featuresCountTotal < 0)
            {
                _featuresCountTotal = 0;
                foreach (string catName in _categoryNames)
                {
                    _featuresCountTotal += getAllFeaturesTotalInCategory(catName);
                }
                return _featuresCountTotal;
            }
            return _featuresCountTotal;
        }

        private long getItemsTotalInCategory(string category)
        {
            if (_itemsCountInCategory.ContainsKey(category))
            {
                return _itemsCountInCategory[category];
            }
            return 0;
        }

        private long getItemsTotalAll()
        {
            long sum = 0;
            foreach (long count in _itemsCountInCategory.Values)
            {
                sum += count;
            }
            return sum;
        }

        private long getCategoryNamesCount()
        {
            return _categoryNames.Count;
        }
    }
}
