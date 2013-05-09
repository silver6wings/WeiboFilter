using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPlatform.Classifiers
{
    abstract class Classifier : Transmitter
    {
        protected Filter _filter;

        public void setFilter(Filter filter)
        {
            _filter = filter;
        }

        //receive comment and do classifiy
        public override void doReceive(string comment, string category)
        {
            if (_filter != null)
            {
                doReport(comment, doClassify(_filter.filtering(comment)));
            }
            else
            {
                doReport(comment, doClassify(comment));
            }
        }

        //report comment to next classifier or 
        public override void doReport(string comment, string category)
        {
            if (_strategy._showPath)
            {
                if (_filter != null)
                {
                    Console.WriteLine("\"{0}\" -> {1}", _filter.filtering(comment), category);
                }
                else
                {
                    Console.WriteLine("\"{0}\" -> {1}", comment, category);
                }
            }

            // find next classifier
            for (int i = 0; i < _strategy._graph[_index].Length; i++)
            {
                if(_strategy._graph[_index][i].Equals(category)){
                    _strategy._classifierGroup.ElementAt(i).doReceive(comment, category);
                    return;
                }
            }

            // if not found next classifier
            Console.WriteLine("Classifier can't find speaker.");
        }

        // classify detail
        public abstract string doClassify(string comment); 
    }
}