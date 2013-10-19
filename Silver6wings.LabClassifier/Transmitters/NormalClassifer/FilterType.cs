using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Silver6wings.LabClassifier.Classifiers
{
    class FilterType : Filter
    {
        public override string  filtering(string receive)
        {
            StringBuilder result = new StringBuilder("");

            char[] punctuation = { ',', '.', '!', '?', '`', ':', ';', '(', ')', '<', '>', '[', ']', '{', '}', '\"' };
            char[] specialchar = { '~', '!', '@', '#', '$', '%', '^', '&', '*', '_', '+', '-', '=', '|', '/', '\\' };

            for (int i = 0; i < receive.Length; i++)
            {
                if (receive[i] == ' ')
                    result.Append(' ');

                else if (receive[i] >= 'a' && receive[i] <= 'z' || receive[i] == '\'')
                    result.Append('a');

                else if (receive[i] >= 'A' && receive[i] <= 'Z')
                    result.Append('A');

                else if (receive[i] >= '0' && receive[i] <= '9')
                    result.Append('1');

                else if (punctuation.Contains(receive[i]))
                    result.Append('.');

                else if (specialchar.Contains(receive[i]))
                    result.Append('#');
                
                else
                    result.Append('?');
            }

            string report = result.ToString();
            return report;
        }
    }
}
