using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DesignPlatform
{
    class StrategyTester
    {
        public static void testBinary(Strategy strategy, string testFileName)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("start testing ...");

            StreamReader sr = new StreamReader(testFileName);

            int[] whiteReal = { 0, 0 };
            int[] blackReal = { 0, 0 };


            string line = "";
            while (!string.IsNullOrEmpty(line = sr.ReadLine()))
            {
                if (line.Equals("1") || line.Equals("GOOD")) // is White
                {
                    line = sr.ReadLine();

                    if (strategy.makeDecision(line).Equals("GOOD"))
                    {
                        whiteReal[0]++;
                    }
                    else // SPAM
                    {
                        whiteReal[1]++;
                    }
                }
                else // is Black
                {
                    line = sr.ReadLine();
                    if (strategy.makeDecision(line).Equals("GOOD"))
                    {
                        blackReal[0]++;
                    }
                    else // SPAM
                    {
                        blackReal[1]++;
                    }
                }
            }
            sr.Close();

            Console.WriteLine("stop testing ...");
            Console.WriteLine(DateTime.Now - dt);

            StringBuilder sb = new StringBuilder(strategy._name);

            sb.Append("\r\n");
            sb.Append(testFileName);
            sb.Append("\r\n");
            sb.Append("----------------------------------------\r\n");
            sb.Append("Man\\Com\tWhite\tBlack\tTotal\tRecall\r\n");

            sb.Append(string.Format("White\t{0}\t{1}\t{2}\t{3:P}\r\n",
                whiteReal[0], 
                whiteReal[1], 
                whiteReal[0] + whiteReal[1], 
                (float)(whiteReal[0]) / (whiteReal[0] + whiteReal[1])));

            sb.Append(string.Format("Black\t{0}\t{1}\t{2}\t{3:P}\r\n",
                blackReal[0], 
                blackReal[1], 
                blackReal[0] + blackReal[1], 
                (float)(blackReal[1]) / (blackReal[0] + blackReal[1])));

            sb.Append(string.Format("Total\t{0}\t{1}\t{2}\r\n",
                whiteReal[0] + blackReal[0], 
                whiteReal[1] + blackReal[1], 
                whiteReal[0] + blackReal[0] + whiteReal[1] + blackReal[1]));

            sb.Append(string.Format("Prcison\t{0:P}\t{1:P}\r\n",
                (float)whiteReal[0] / (whiteReal[0] + blackReal[0]),
                (float)blackReal[1] / (whiteReal[1] + blackReal[1])));

            sb.Append("\n");
            sb.Append(string.Format("[Precision:{0:P}]\r\n", 
                (float)blackReal[1] / (whiteReal[1] + blackReal[1])));

            sb.Append(string.Format("[Recall:{0:P}]\r\n", 
                (float)(blackReal[1]) / (blackReal[0] + blackReal[1])));

            sb.Append("----------------------------------------\r\n");

            Console.WriteLine(sb);
            StreamWriter sw = new StreamWriter("../Data/Report.txt", true);
            sw.Write(sb);
            sw.Close();
        }
    }
}
