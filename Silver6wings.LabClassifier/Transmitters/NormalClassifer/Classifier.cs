using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver6wings.LabClassifier.Classifiers
{
    abstract class Classifier : Transmitter
    {
        public Filter _filter { get; set;} //item过滤器

        //receive comment and do classifiy
        public override void receiveItem(string item, string category)
        {
            if (_filter != null)            
                reportItem(item, classify(_filter.filtering(item)));           
            else            
                reportItem(item, classify(item));            
        }

        //report comment to next classifier or 
        public override void reportItem(string item, string category)
        {
            // 显示分类路径
            if (_strategy.showPath())
            {
                if (_filter != null)                
                    Console.WriteLine("\"{0}\" -> {1}", _filter.filtering(item), category);                
                else                
                    Console.WriteLine("\"{0}\" -> {1}", item, category);                
            }

            // 寻找下一个分类器
            for (int i = 0; i < _strategy._road[_index].Length; i++)
            {
                if(_strategy._road[_index][i].Equals(category)){

                    // 转交item
                    _strategy._transmitters.ElementAt(i).receiveItem(item, category);
                    return;
                }
            }

            // if cann't found next
            Console.WriteLine("Classifier can't find next...");
        }

        // return的string就是classifier分的类别
        public abstract string classify(string item); 
    }
}