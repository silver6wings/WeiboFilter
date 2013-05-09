using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPlatform.Classifiers
{
    class ClassifierLength10 : Classifier
    {
        public override string doClassify(string comment)
        {
            if (comment.Length > 10)
            {
                return "10+";
            }
            return "10-";            
        }
    }
}
