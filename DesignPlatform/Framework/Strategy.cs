using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPlatform.Classifiers;

namespace DesignPlatform
{
    class Strategy
    {
        internal string _categoryResult;
        internal string _name;
        internal bool _showPath;

        internal List<Transmitter> _classifierGroup;
        internal string[][] _graph;

        
        public Strategy(string name, string[][] graph, List<Transmitter> classifierGroup, bool showPath = false)
        {
            _categoryResult = "";
            _name = name;
            _showPath = showPath;

            _graph = graph;
            _classifierGroup = classifierGroup;

            for (int i = 0; i < _classifierGroup.Count; i++)
            {
                _classifierGroup.ElementAt(i).setIndex(i);
                _classifierGroup.ElementAt(i).setStrategy(this);
            }
        }
        
        public string makeDecision(string comment, int startNum = 0)
        {
            // default _classifiers[0] is entrance;
            _classifierGroup.ElementAt(startNum).doReceive(comment, "start");
            return _categoryResult;
        }
    }
}
