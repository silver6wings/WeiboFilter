using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPlatform.Classifiers
{
    class ClassifierHaveIllegalChar : Classifier
    {
        public override string doClassify(string comment)
        {
            int t = 0;
            int max = 0;

            int width = 20;
            int threshold = 8;

            for (int i = 0; i < comment.Length; i++)
            {
                if(comment[i] == '?')  t++;                                                                          
                if (i - width >= 0 && comment[i - width] == '?') t--;

                if (t > max) max = t;
            }

            if (max > threshold) return "BLACK";
            return "WHITE";
        }
    }
}
