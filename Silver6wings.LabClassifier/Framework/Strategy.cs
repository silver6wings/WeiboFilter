using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Silver6wings.LabClassifier.Classifiers;

namespace Silver6wings.LabClassifier.Framework
{
    class Strategy
    {
        internal int _entrance;                         // 分类器入口
        internal List<Transmitter> _transmitters;       // 分类器列表

        private string _categoryResult;                 // 用以汇报

        public Strategy(int entrance, List<Transmitter> transmitters)
        {            
            _transmitters = transmitters;
            _entrance = entrance;
        }
        
        public string judgeItem(string item)
        {
            if (_entrance >= 0 && _entrance < _transmitters.Count)
            {
                _transmitters.ElementAt(_entrance).receiveItem(item);
                return _categoryResult;
            }
            return null;
        }

        internal void setCurrentResult(string result)
        {
            _categoryResult = result;
        }

        internal void connectClassifier(int i, int j, string key)
        {
            if (i < 0 || i >= _transmitters.Count || 
                j < 0 || j >= _transmitters.Count) return;

            ((Classifier)_transmitters[i])._nextStrategies.Add(key, _transmitters[j]);
        }
    }
}
