using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPlatform
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
            foreach (Strategy strategy in _strategys) strategy.receiveItem(item);            
        }
    }
}
