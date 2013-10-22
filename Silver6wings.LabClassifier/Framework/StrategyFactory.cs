using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Silver6wings.LabClassifier.Classifiers;

namespace Silver6wings.LabClassifier.Framework
{
    class StrategyFactory
    {
        
        public static Strategy createDemoSingleBayesStrategy()
        {
            Console.WriteLine("Naive Bayes Classifier> Building up ....");

            List<Transmitter> tempT = new List<Transmitter>();
            Strategy tempS = new Strategy(0, tempT);

            tempT.Add(new ClassifierMLBayes(ClassifierLearnableBayesType.Naive));
            tempT.Add(new Speaker("normal", tempS)); // 1
            tempT.Add(new Speaker("spam", tempS));  // 2

            tempS.connectClassifier(0, 1, "GOOD");
            tempS.connectClassifier(0, 2, "BAD");

            // 训练过程
            ClassifierMLBayes c0 = (ClassifierMLBayes)tempT[0];
            c0._filter = new FilterToLowcase();
            c0._detector = new DetectorSpace();
            
            c0.train("Nobody owns the water", "GOOD");
            c0.train("the quick rabbit jumps fences", "GOOD");
            c0.train("the quick brown fox jumps", "GOOD");
            c0.train("buy pharmaceuticals now!", "BAD");
            c0.train("make quick money at the online casino.", "BAD");
            c0.showModelInfo(null, true);
            //teachWithFile(c0, "../Data/DP/TrainData.txt");

            return tempS;
        }

        public static void teachWithFile(ClassifierML classifier, string trainFileName)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("start trainning...");

            StreamReader sr = new StreamReader(trainFileName);

            string line = sr.ReadLine();
            while (!line.Equals("@END"))
            {
                string catName = line;// Category Name
                line = sr.ReadLine(); // load features

                classifier.train(line, catName);

                line = sr.ReadLine(); // load next
            }

            sr.Close();

            Console.WriteLine("stop trainning...");
            Console.WriteLine(DateTime.Now - dt);
        }

        public static Strategy createDemoNormalStrategy()
        {
            Console.WriteLine("Normal Classifier > Building up ....");

            List<Transmitter> tempT = new List<Transmitter>();
            Strategy tempS = new Strategy(0, tempT);

            tempT.Add(new ClassifierHaveNumber());
            tempT.Add(new ClassifierLength10());
            tempT.Add(new ClassifierUppercase());
            tempT.Add(new Speaker("Category01", tempS));
            tempT.Add(new Speaker("Category02", tempS));
            tempT.Add(new Speaker("Category03", tempS));

            tempS.connectClassifier(0, 1, "HaveNumber");
            tempS.connectClassifier(0, 2, "NoNumber");
            tempS.connectClassifier(1, 3, "Length>10");
            tempS.connectClassifier(1, 4, "Length<=10");
            tempS.connectClassifier(2, 4, "HaveUppercase");
            tempS.connectClassifier(2, 5, "NoUppercase");
            
            return tempS;
        }
    }
}
