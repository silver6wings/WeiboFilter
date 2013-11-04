using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

using Silver6wings.LabClassifier.Classifiers;
using Silver6wings.LabClassifier.Framework;

namespace Silver6wings.LabClassifier
{
    class Demo
    {
        static void Main(string[] args)
        {

            Console.WriteLine("---------------- BEGIN ----------------");

            //training
            Process trainProcess = new Process();
            trainProcess.StartInfo.FileName = 
                "C:\\Users\\v-jipe\\Downloads\\libsvm-3.12\\libsvm-3.12\\windows\\svm-train";
            trainProcess.StartInfo.Arguments =
                "C:\\Users\\v-jipe\\Downloads\\libsvm-3.12\\libsvm-3.12\\windows\\heart " +
                "C:\\Users\\v-jipe\\Downloads\\libsvm-3.12\\libsvm-3.12\\windows\\heart.model";
            trainProcess.Start();
            trainProcess.Dispose();

            //test
            Process testProcess = new Process();
            testProcess.StartInfo.FileName =
                "C:\\Users\\v-jipe\\Downloads\\libsvm-3.12\\libsvm-3.12\\windows\\svm-predict";
            testProcess.StartInfo.Arguments =
                "C:\\Users\\v-jipe\\Desktop\\test " +
                "C:\\Users\\v-jipe\\Downloads\\libsvm-3.12\\libsvm-3.12\\windows\\heart.model " +
                "C:\\Users\\v-jipe\\Downloads\\libsvm-3.12\\libsvm-3.12\\windows\\test.result";
            testProcess.Start();
            testProcess.Dispose();   


            //StrategyTester.testBinary(se, "../Data/DP/TestData_2012-10-31.txt");

            Console.WriteLine("----------------- END -----------------");
            Console.ReadKey(); 
        }

        static void DemoBayes()
        {
            Strategy strategySingleNaiveBayes = StrategyFactory.createDemoSingleBayesStrategy();
            Console.WriteLine(strategySingleNaiveBayes.judgeItem("quick Rabbit")); 
            Console.WriteLine(strategySingleNaiveBayes.judgeItem("quick MONEY"));
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

        static void DemoDistributer(){
            Distributer d = new Distributer(null, null);
            
            d.add(StrategyFactory.createDemoSingleBayesStrategy(), 1);
            d.add(StrategyFactory.createDemoNormalStrategy(), 1);

            Distributer.Output(d.distributeItem("quick MONEY"));
        }
    }    
}
