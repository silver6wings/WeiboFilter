using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Silver6wings.LabClassifier.Classifiers
{
    class FilterToLowcase : Filter
    {
        public override string filtering(string receive)
        {    
            return receive.ToLower();
        }
    }
}
