using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver6wings.LabClassifier.Classifiers
{
    class Strategy
    {                       
        internal List<Transmitter> _transmitters;       // 分类器列表
        internal int _entrance;                         // 分类器入口
        internal string[][] _road;                      // 分类器路径图

        private string _categoryResult;                 // 用以汇报
        private bool _showPath;                         // 是否显示路径

        public Strategy(int entrance, string[][] road, List<Transmitter> transmitters, bool showPath = false)
        {
            _showPath = showPath;
            _categoryResult = "";

            _transmitters = transmitters;
            _entrance = entrance;
            _road = road;

            // 把每个classifer连接到strategy上
            for (int i = 0; i < _transmitters.Count; i++)
            {
                _transmitters.ElementAt(i)._index = i;
                _transmitters.ElementAt(i)._strategy = this;
            }
        }
        
        public string judgeItem(string item)
        {
            // default _classifiers[0] is entrance;
            _transmitters.ElementAt(_entrance).receiveItem(item, "start");

            return _categoryResult;
        }

        internal void reportCategory(string result)
        {
            _categoryResult = result;
        }

        internal Boolean showPath()
        {
            return _showPath;
        }
    }
}
