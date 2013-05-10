using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using DesignPlatform.Classifiers;

namespace DesignPlatform
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------- BEGIN ----------------");
            
            Strategy se = StrategyFactory.getBayesStra();

            se._showPath = false;
            se.makeDecision("À1234567890123ÀÁÂÃÄÅ℃【“”字");

            StrategyTester.testBinary(se, "../Data/DP/TestData_2012-10-31.txt");
             
            /* code for test distrbutor
              
            List<Strategy> stra = new List<Strategy>();
            stra.Add(getStra01());           

            Distributer dis = new Distributer(stra);
            dis.pushComments("123456789");
            dis.pushComments("12345678901");
            dis.pushComments("abcdefghjik");
            dis.pushComments("AVX");
            */

            Console.WriteLine("----------------- END -----------------");
            Console.ReadKey(); 
        }
    }    
}
