using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver6wings.LabClassifier.Classifiers
{
    class ClassifierShortUrl : Classifier
    {
        public override string classify(string comment)
        {
            //http://t.cn/zRfkCoY
         

            if (comment.Contains("http://t.cn/"))
            {
                return "HaveUppercase";
            }

            return "NoUppercase";
        } 
    }
}
