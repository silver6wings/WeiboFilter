using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver6wings.LabClassifier.Classifiers
{
    abstract class ClassifierML : Classifier
    {
        public Detector _detector { get; set; }        

        public abstract void train(string comment, string category);

        public abstract void untrain(string comment, string category);
    }
}
