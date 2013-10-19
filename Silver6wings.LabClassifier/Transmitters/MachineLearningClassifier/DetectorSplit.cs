using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver6wings.LabClassifier.Classifiers
{
    class DetectorSplit : Detector
    {
        private int wordLengthMin = 1, wordLengthMax = 30;
        private char[] blanks = { ' ', '\r', '\n', '\t', '\"', 
                                  '`', '~', '!', '@', '#', '$', 
                                  '%', '^', '&', '*', '(', ')', 
                                  '_', '+', '-', '=', '{', '}', 
                                  '[', ']', ':', ';', '<', '>', 
                                  '?', ',', '.', '/' };

        public override string[] detect(string comment)
        {
            List<string> features = new List<string>();

            if (!string.IsNullOrEmpty(comment))
            {
                comment = comment.ToLower();
                comment = back(comment);
                comment = comment.Trim(blanks);

                string[] words = comment.Split(blanks);

                foreach (string word in words)
                {
                    if (word.Length >= wordLengthMin && word.Length <= wordLengthMax)
                    {
                        features.Add(word);
                    }
                }
            }
            return features.ToArray();
        }

        private string back(string str)
        {
            /*            
            \' 单引号
            \" 双引号
            \\ 反斜杠
            \0 空
            \a 警告（产生峰鸣）
            \b 退格
            \f 换页
            \n 换行
            \r 回车
            \t 水平制表符
            \v 垂直制表符            
            */

            str = str.Replace("\\\'", "\'");
            str = str.Replace("\\\"", "\"");
            str = str.Replace("\\\\", "\\");
            str = str.Replace("\\0", "\0");
            str = str.Replace("\\a", "\a");
            str = str.Replace("\\b", "\b");
            str = str.Replace("\\f", "\f");
            str = str.Replace("\\n", "\n");
            str = str.Replace("\\r", "\r");
            str = str.Replace("\\t", "\t");
            str = str.Replace("\\v", "\v");

            return str;
        }
    }
}
