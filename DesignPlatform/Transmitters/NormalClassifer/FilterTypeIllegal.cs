using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace DesignPlatform.Classifiers
{
    class FilterTypeIllegal : Filter
    {
        public override string  filtering(string receive)
        {
            StringBuilder result = new StringBuilder("");

            char[] punctuation = { ',', '.', '!', '?', '`', ':', ';', '(', ')', '<', '>', '[', ']', '{', '}', '\"' };
            char[] specialchar = { '~', '!', '@', '#', '$', '%', '^', '&', '*', '_', '+', '-', '=', '|', '/', '\\' };
            char[] illegalchar = { '¡', '¢', '£', '¤', '¥', '¦', '§', '¨', '©', 'ª', '«', '¬', '®', '¯', '°', '±', 
                                   '²', '³', '´', 'µ', '¶', '·', '¸', '¹', 'º', '»', '¼', '½', '¾', '¿', 'À', 'Á', 
                                   'Â', 'Ã', 'Ä', 'Å', 'Æ', 'Ç', 'È', 'É', 'Ê', 'Ë', 'Ì', 'Í', 'Î', 'Ï', 'Ð', 'Ñ', 
                                   'Ò', 'Ó', 'Ô', 'Õ', 'Ö', '×', 'Ø', 'Ù', 'Ú', 'Û', 'Ü', 'Ý', 'Þ', 'ß', 'à', 'á', 
                                   'â', 'ã', 'ä', 'å', 'æ', 'ç', 'è', 'é', 'ê', 'ë', 'ì', 'í', 'î', 'ï', 'ð', 'ñ', 
                                   'ò', 'ó', 'ô', 'õ', 'ö', '÷', 'ø', 'ù', 'ú', 'û', 'ü', 'ý', 'þ', 'ÿ'};

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

                else if (illegalchar.Contains(receive[i]))
                    result.Append('?');
                
                else
                    result.Append(' ');
                
            }

            string report = result.ToString();
            return report;
        }
    }
}
