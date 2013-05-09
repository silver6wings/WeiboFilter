using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPlatform.Classifiers
{
    class ClassifierHaveNumber : Classifier
    {
        public override string doClassify(string comment)
        {
            for (int i = 0; i < comment.Length; i++)
            {
                if (comment[i] >= '0' && comment[i] <= '9')
                {
                    return "NB+";
                }
            }
            return "NB-";
        }
    }
}
