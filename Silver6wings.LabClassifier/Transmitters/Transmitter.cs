using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver6wings.LabClassifier.Classifiers
{
	abstract class Transmitter
    {             
        public abstract void receiveItem(string item);

        protected abstract void reportItem(string item, string category);
	}
}
