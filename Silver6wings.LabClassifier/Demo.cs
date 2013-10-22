using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Silver6wings.LabClassifier.Classifiers;
using Silver6wings.LabClassifier.Framework;

namespace Silver6wings.LabClassifier
{
    class Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------- BEGIN ----------------");

            //DemoNormal();
            //DemoBayes();

            Distributer d = new Distributer(null, null);
            
            d.add(StrategyFactory.createDemoSingleBayesStrategy(), 1);
            d.add(StrategyFactory.createDemoNormalStrategy(), 1);

            Distributer.Output(d.distributeItem("quick MONEY"));

            //StrategyTester.testBinary(se, "../Data/DP/TestData_2012-10-31.txt");

            Console.WriteLine("----------------- END -----------------");
            Console.ReadKey(); 
        }

        static void DemoBayes()
        {
            Strategy sBayes = StrategyFactory.createDemoSingleBayesStrategy();
            Console.WriteLine(sBayes.judgeItem("quick Rabbit")); 
            Console.WriteLine(sBayes.judgeItem("quick MONEY"));
        }
        
        static void DemoNormal()
        {
            Strategy se = StrategyFactory.createDemoNormalStrategy();
            Console.WriteLine(se.judgeItem("À1234567890123ÀÁÂÃÄÅ℃【“”字"));
            Console.WriteLine(se.judgeItem("123456789"));
            Console.WriteLine(se.judgeItem("1234567890123"));
            Console.WriteLine(se.judgeItem("havumber"));
            Console.WriteLine(se.judgeItem("NoNuGDFDFGDFGDFGmber"));
        }        
    }    
}
