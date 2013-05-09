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

        public void pushComments(string comment)
        {
            foreach (Strategy strategy in _strategys)
            {
                strategy.makeDecision(comment);
            }
        }
    }
}
