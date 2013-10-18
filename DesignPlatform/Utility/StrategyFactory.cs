using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPlatform.Classifiers;

namespace DesignPlatform
{
    class StrategyFactory
    {
        public static Strategy getBayesStra()
        {
            string[][] testGraph = new string[2][];
            for (int i = 0; i < 2; i++)
                testGraph[i] = new string[] { "", "", "" };

            List<Transmitter> testClassifierGroup = new List<Transmitter>();

            ClassifierLearnable c0 = new ClassifierLearnableBayes(ClassifierLearnableBayesType.Naive);
            c0._detector = new DetectorSpace();
            Assistant.teachWithFile(c0, "../Data/DP/TrainData.txt");

            /*        
            c0.doTrain("Nobody owns the water", "GOOD");
            c0.doTrain("the quick rabbit jumps fences", "GOOD");
            c0.doTrain("the quick brown fox jumps", "GOOD");
            c0.doTrain("buy pharmaceuticals now!", "BAD");
            c0.doTrain("make quick money at the online casino.", "BAD");
            c0.showModelInfo();
            */

            testClassifierGroup.Add(c0);
            testGraph[0][1] = "GOOD";
            testGraph[0][2] = "BAD";

            testClassifierGroup.Add(new Speaker("GOOD"));
            testClassifierGroup.Add(new Speaker("BAD"));


            return new Strategy(0, testGraph, testClassifierGroup);
        }

        public static Strategy getSampleStrategy()
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

            return new Strategy(1, testGraph, testClassifierGroup);
        }
    }
}
