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

        public override void doReceive(string comment, string category)
        {
            doReport(comment, category);
        }

        public override void doReport(string comment, string category)
        {
            if (_strategy._showPath) Console.WriteLine("\"{0}\" >> {1}", comment, _finalCategory);
            _strategy._categoryResult = _finalCategory;
        }
    }
}
