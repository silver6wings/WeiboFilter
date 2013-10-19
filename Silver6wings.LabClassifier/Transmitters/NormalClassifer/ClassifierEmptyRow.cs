using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver6wings.LabClassifier.Classifiers
{
    class ClassifierEmptyRow : Classifier
    {
        public override string classify(string comment)
        {
            if (comment.Contains("\\r\\n\\r\\n"))
            {
                return "HaveEmptyRow";
            }
            return "NotHaveEmptyRow";
        }
    }
}
