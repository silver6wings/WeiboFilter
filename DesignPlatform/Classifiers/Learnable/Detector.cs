using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPlatform.Classifiers
{
    abstract class Detector
    {
        public abstract string[] detectFeature(string comment);
    }
}
