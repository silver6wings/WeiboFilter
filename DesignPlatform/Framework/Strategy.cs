using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPlatform.Classifiers;

namespace DesignPlatform
{
    class Strategy
    {
        internal string _categoryResult;                //
        internal string _name;                          // 策略名
        internal bool _showPath;                        // 是否显示路径

        internal List<Transmitter> _transmitters;       // 分类器
        internal string[][] _graph;                     // 分类器路径图

        
        public Strategy(string name, string[][] graph, List<Transmitter> classifierGroup, bool showPath = false)
        {
            _categoryResult = "";
            _name = name;
            _showPath = showPath;

            _graph = graph;
            _transmitters = classifierGroup;

            // 把每个classifer连接到strategy上
            for (int i = 0; i < _transmitters.Count; i++)
            {
                _transmitters.ElementAt(i)._index = i;
                _transmitters.ElementAt(i)._strategy = this;
            }
        }
        
        public string receiveItem(string item, int startClassiferNum = 0)
        {
            // default _classifiers[0] is entrance;
            _transmitters.ElementAt(startClassiferNum).receiveItem(item, "start");

            return _categoryResult;
        }
    }
}
