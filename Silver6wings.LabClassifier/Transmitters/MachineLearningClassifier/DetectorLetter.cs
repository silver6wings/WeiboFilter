using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace Silver6wings.LabClassifier.Classifiers
{
    class DetectorLetter : Detector
    {
        private int wordLengthMin = 1, wordLengthMax = 30;

        public override string[] detect(string comment)
        {            
            List<string> features = new List<string>();

            if (!string.IsNullOrEmpty(comment))
            {
                Regex regex = new Regex("\\w*");
                MatchCollection mc = regex.Matches(comment);

                foreach (Match match in mc)
                {
                    if (match.Value.Length >= wordLengthMin && match.Value.Length <= wordLengthMax)
                    {
                        features.Add(match.Value);
                    }
                }
            }
            return features.ToArray();
        }
    }
}
