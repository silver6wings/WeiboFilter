using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPlatform.Classifiers
{
    class Speaker : Transmitter
    {
        protected string _finalCategory;

        public Speaker(string finalCategory)
        {
            _finalCategory = finalCategory;
        }

        public override void receiveItem(string comment, string category)
        {
            // 不分类直接就发布声明
            reportItem(comment, category);
        }

        public override void reportItem(string comment, string category)
        {
            // 显示分类路径
            if (_strategy.showPath()) Console.WriteLine("\"{0}\" >> {1}", comment, _finalCategory);

            // 告诉strategy最终结果
            _strategy.reportCategory(_finalCategory);
        }
    }
}
