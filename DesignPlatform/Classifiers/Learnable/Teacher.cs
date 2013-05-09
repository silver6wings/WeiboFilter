using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace DesignPlatform.Classifiers
{
    class Teacher
    {
        public static void teachWithFile(ClassifierLearnable classifier, string trainFileName)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("start trainning...");

            StreamReader sr = new StreamReader(trainFileName);

            string line = sr.ReadLine();
            while (!line.Equals("@END"))
            {
                string catName = line;// Category Name
                line = sr.ReadLine(); // load features

                classifier.doTrain(line, catName);

                line = sr.ReadLine(); // load next
            }

            sr.Close();

            Console.WriteLine("stop trainning...");
            Console.WriteLine(DateTime.Now - dt);
        }
    }
}
