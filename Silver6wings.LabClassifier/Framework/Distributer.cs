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

        public Distributer(List<Strategy> strategys)
        {
            _strategys = strategys;
        }

        // 将item分发给各个strategy
        public void pushItem(string item)
        {
            foreach (Strategy strategy in _strategys) strategy.judgeItem(item);            
        }
    }
}