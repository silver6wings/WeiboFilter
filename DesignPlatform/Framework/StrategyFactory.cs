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
            c0.setDetector(new DetectorSpace());
            Teacher.teachWithFile(c0, "../Data/DP/TrainData.txt");

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


            return new Strategy("Bayes", testGraph, testClassifierGroup);
        }

        public static Strategy getExperimentStrategy()
        {
            string[][] testGraph = new string[6][];
            for (int i = 0; i < 6; i++)
                testGraph[i] = new string[] { "", "", "", "", "", "" };

            List<Transmitter> testClassifierGroup = new List<Transmitter>();

            Classifier c1 = new ClassifierHaveIllegalChar();
            c1.setFilter(new FilterType());

            Classifier c2 = new ClassifierHaveRNRNRN();

            testClassifierGroup.Add(c1);
            testGraph[0][1] = "WHITE";
            testGraph[0][2] = "BLACK";

            testClassifierGroup.Add(new Speaker("GOOD"));
            testClassifierGroup.Add(new Speaker("SPAM"));

            return new Strategy("Experiment", testGraph, testClassifierGroup);
        }

        public static Strategy getSampleStrategy()
        {
            string[][] testGraph = new string[6][];
            for (int i = 0; i < 6; i++)
                testGraph[i] = new string[] { "", "", "", "", "", "" };

            List<Transmitter> testClassifierGroup = new List<Transmitter>();

            testClassifierGroup.Add(new ClassifierHaveNumber());
            testGraph[0][1] = "NB+";
            testGraph[0][2] = "NB-";

            testClassifierGroup.Add(new ClassifierLength10());
            testGraph[1][3] = "10+";
            testGraph[1][4] = "10-";

            testClassifierGroup.Add(new ClassifierHaveUppercase());
            testGraph[2][4] = "UC+";
            testGraph[2][5] = "UC-";

            testClassifierGroup.Add(new Speaker("s03"));
            testClassifierGroup.Add(new Speaker("s04"));
            testClassifierGroup.Add(new Speaker("s05"));

            return new Strategy("Sample", testGraph, testClassifierGroup);
        }
    }
}
