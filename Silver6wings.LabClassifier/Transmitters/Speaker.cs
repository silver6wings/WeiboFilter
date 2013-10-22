using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Silver6wings.LabClassifier.Framework;

namespace Silver6wings.LabClassifier.Classifiers
{
    class Speaker : Transmitter
    {
        protected string _finalCategory;

        protected Strategy _strategy;     // 自己汇报的strategy

        public Speaker(string finalCategory, Strategy strategy)
        {
            _finalCategory = finalCategory;
            _strategy = strategy;
        }

        public override void receiveItem(string item)
        {
            // 不分类直接就发布声明
            reportItem(item, _finalCategory);
        }

        protected override void reportItem(string item, string category)
        {
            // 显示分类路径
            Console.WriteLine("\"{0}\" == {1}", item, category);

            // 告诉strategy最终结果
            _strategy.setCurrentResult(_finalCategory);
        }
    }
}
