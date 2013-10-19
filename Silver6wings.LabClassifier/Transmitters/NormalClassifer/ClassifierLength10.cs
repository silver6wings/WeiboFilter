using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver6wings.LabClassifier.Classifiers
{
    class ClassifierLength10 : Classifier
    {
        public override string classify(string comment)
        {
            if (comment.Length > 10)
            {
                return "Length>10";
            }
            return "Length<=10";            
        }
    }
}
