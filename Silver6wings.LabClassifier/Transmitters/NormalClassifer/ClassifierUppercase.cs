using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver6wings.LabClassifier.Classifiers
{
    class ClassifierUppercase : Classifier
    {
        public override string classify(string comment)
        {
            for (int i = 0; i < comment.Length; i++)
            {
                if (comment[i] >= 'A' && comment[i] <= 'Z')
                {
                    return "HaveUppercase";
                }
            }
            return "NoUppercase";
        } 
    }
}
