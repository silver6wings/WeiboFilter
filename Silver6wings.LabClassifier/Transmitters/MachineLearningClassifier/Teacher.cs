using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silver6wings.LabClassifier.Classifiers
{
    class Teacher
    {
        List<ClassifierML> _students;

        public Teacher()
        {
            _students = new List<ClassifierML>();
        }

        public Teacher(List<ClassifierML> students)
        {
            if (students == null)
            {
                students = new List<ClassifierML>();
            }
            _students = students;
        }

        public void teachStudents(string comment, string category)
        {
            foreach (ClassifierML student in _students)
            {
                student.train(comment, category);
            }            
        }
    }
}
