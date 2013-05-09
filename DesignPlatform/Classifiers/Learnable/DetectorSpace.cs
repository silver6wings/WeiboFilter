using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPlatform.Classifiers
{
    class DetectorSpace : Detector
    {
        public override string[] detectFeature(string comment)
        {
            if (!string.IsNullOrEmpty(comment) && comment.Length < 2000)
            {
                try
                {
                    return comment.Split(' ');
                }
                catch
                {
                    Console.WriteLine('('+comment+')');
                }
            }
            return new string[0];
        }
    }
}
