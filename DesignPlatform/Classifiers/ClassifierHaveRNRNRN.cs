using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPlatform.Classifiers
{
    class ClassifierHaveRNRNRN : Classifier
    {
        public override string classify(string comment)
        {
            if (comment.Contains("\\r\\n\\r\\n\\r\\n"))
            {
                return "BLACK";
            }
            return "WHITE";
        }
    }
}
