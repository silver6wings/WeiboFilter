using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPlatform.Classifiers
{
	abstract class Transmitter
    {
        protected Strategy _strategy;
        protected int _index;
        
        public void setStrategy(Strategy strategy)
        {
            _strategy = strategy;
        }

        public void setIndex(int index)
        {
            _index = index;
        }

        public abstract void doReceive(string comment, string category);

        public abstract void doReport(string comment, string category);
	}
}
