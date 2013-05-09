using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPlatform.Classifiers
{
    abstract class ClassifierLearnable : Classifier
    {
        protected Detector _detector;

        public void setDetector(Detector detector)
        {
            _detector = detector;
        }

        public abstract void doTrain(string comment, string category);

        public abstract void doUntrain(string comment, string category);

        public abstract void showModelInfo();
    }
}
