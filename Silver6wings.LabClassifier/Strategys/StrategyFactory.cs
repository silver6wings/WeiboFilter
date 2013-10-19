using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Silver6wings.LabClassifier.Classifiers
{
    class StrategyFactory
    {
        public static Strategy getDemoSingleBayesClassifier()
        {
            string[][] testGraph = new string[2][];
            for (int i = 0; i < 2; i++)
                testGraph[i] = new string[] { "", "", "" };

            List<Transmitter> testClassifierGroup = new List<Transmitter>();

            ClassifierML c0 = new ClassifierMLBayes(ClassifierLearnableBayesType.Naive);
            c0._detector = new DetectorSpace();
            //teachWithFile(c0, "../Data/DP/TrainData.txt");
            
            c0.train("Nobody owns the water", "GOOD");
            c0.train("the quick rabbit jumps fences", "GOOD");
            c0.train("the quick brown fox jumps", "GOOD");
            c0.train("buy pharmaceuticals now!", "BAD");
            c0.train("make quick money at the online casino.", "BAD");
            ((ClassifierMLBayes)c0).showModelInfo(null, true);

            testClassifierGroup.Add(c0); // 0
            testGraph[0][1] = "GOOD";
            testGraph[0][2] = "BAD";

            testClassifierGroup.Add(new Speaker("GOOD")); // 1
            testClassifierGroup.Add(new Speaker("BAD"));  // 2

            return new Strategy(0, testGraph, testClassifierGroup, true);
        }

        public static void teachWithFile(ClassifierML classifier, string trainFileName)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("start trainning...");

            StreamReader sr = new StreamReader(trainFileName);

            string line = sr.ReadLine();
            while (!line.Equals("@END"))
            {
                string catName = line;// Category Name
                line = sr.ReadLine(); // load features

                classifier.train(line, catName);

                line = sr.ReadLine(); // load next
            }

            sr.Close();

            Console.WriteLine("stop trainning...");
            Console.WriteLine(DateTime.Now - dt);
        }

        public static Strategy getDemoNormalStrategy()
        {
            string[][] testGraph = new string[6][];
            for (int i = 0; i < 6; i++)
                testGraph[i] = new string[] { "", "", "", "", "", "" };

            List<Transmitter> testClassifierGroup = new List<Transmitter>();

            testClassifierGroup.Add(new ClassifierHaveNumber());
            testGraph[0][1] = "HaveNumber";
            testGraph[0][2] = "NoNumber";

            testClassifierGroup.Add(new ClassifierLength10());
            testGraph[1][3] = "Length>10";
            testGraph[1][4] = "Length<=10";

            testClassifierGroup.Add(new ClassifierUppercase());
            testGraph[2][4] = "HaveUppercase";
            testGraph[2][5] = "NoUppercase";

            testClassifierGroup.Add(new Speaker("Category01"));
            testClassifierGroup.Add(new Speaker("Category02"));
            testClassifierGroup.Add(new Speaker("Category03"));

            return new Strategy(0, testGraph, testClassifierGroup, true);
        }
    }
}
