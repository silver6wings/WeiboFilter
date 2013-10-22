using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Silver6wings.LabClassifier.Classifiers;

namespace Silver6wings.LabClassifier.Framework
{
    class Distributer
    {
        List<Strategy> _strategys;
        List<float> _weight;

        public Distributer(List<Strategy> strategys, List<float> weight)
        {
            _strategys = strategys;
            _weight = weight;
        }

        public void addStrategy(Strategy strategy, float weight)
        {

        }

        // 将item分发给各个strategy
        public void pushItem(string item)
        {
            foreach (Strategy strategy in _strategys) strategy.judgeItem(item);            
        }
    }
}