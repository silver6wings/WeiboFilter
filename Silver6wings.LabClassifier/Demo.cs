using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Silver6wings.LabClassifier.Classifiers;

namespace Silver6wings.LabClassifier
{
    class Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------- BEGIN ----------------");

            DemoNormal();
            DemoBayes();

            //StrategyTester.testBinary(se, "../Data/DP/TestData_2012-10-31.txt");

            Console.WriteLine("----------------- END -----------------");
            Console.ReadKey(); 
        }

        static void DemoBayes()
        {
            Console.WriteLine("===== NBC =====");
            Strategy sBayes = StrategyFactory.getDemoSingleBayesClassifier();
            Console.WriteLine(sBayes.judgeItem("quick Rabbit")); 
            Console.WriteLine(sBayes.judgeItem("quick MONEY"));
        }
        
        static void DemoNormal()
        {
            Console.WriteLine("===== Normal =====");
            Strategy se = StrategyFactory.getDemoNormalStrategy();
            Console.WriteLine(se.judgeItem("À1234567890123ÀÁÂÃÄÅ℃【“”字"));
            Console.WriteLine(se.judgeItem("123456789"));
            Console.WriteLine(se.judgeItem("1234567890123"));
            Console.WriteLine(se.judgeItem("havumber"));
            Console.WriteLine(se.judgeItem("NoNuGDFDFGDFGDFGmber"));
        }        
    }    
}
