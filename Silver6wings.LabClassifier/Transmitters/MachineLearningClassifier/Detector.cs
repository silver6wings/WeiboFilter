using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver6wings.LabClassifier.Classifiers
{
    abstract class Detector
    {
        public abstract string[] detect(string comment);
    }
}
