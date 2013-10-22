using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver6wings.LabClassifier.Classifiers
{
    abstract class Classifier : Transmitter
    {
        public Filter _filter { get; set;} //item过滤器

        public Dictionary<string, Transmitter> _nextStrategies = new Dictionary<string,Transmitter>();

        //receive comment and do classifiy
        public override void receiveItem(string item)
        {
            // 一式两份保证传递的过程没有丢掉信息
            if (_filter != null)            
                reportItem(item, classify(_filter.filtering(item)));       
            else            
                reportItem(item, classify(item));            
        }

        //report comment to next classifier or 
        public override void reportItem(string item, string category)
        {
            if (_nextStrategies.Keys.Contains(category))
            {
                // 显示分类路径
                if (_filter != null)
                    Console.WriteLine("\"{0}\" >- {1}", _filter.filtering(item), category);
                else
                    Console.WriteLine("\"{0}\" >> {1}", item, category); 

                // 递交下一个
                _nextStrategies[category].receiveItem(item);
            }
            else
            {
                // 显示错误的路径
                Console.WriteLine("Classifier Can't find next...");
            }
        }

        // return的string就是classifier分的类别
        public abstract string classify(string item); 
    }
}