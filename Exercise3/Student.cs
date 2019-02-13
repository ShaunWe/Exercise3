using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Student
    {
        string _firstName;
        string _lastName;

        List<Class> _courseList = new List<Class>();

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public List<Class> CourseList
        {
            get { return _courseList; }
            set { _courseList = value; }
        }

        public string FullName()
        {
            return $"{_firstName} {_lastName}";
        }

        public double GetStudentGPA()
        {
            double returnGPA = 0;
            int numCourses = 0;
            foreach (Class c in _courseList)
            {
                numCourses += 1;
                returnGPA += c.GetGPAValue();
            }
            if (numCourses > 0)
            {
                returnGPA = returnGPA / (double)numCourses;
            }
            return returnGPA;
        }

        public Student(string firstname, string lastname)
        {
            _firstName = firstname;
            _lastName = lastname;
        }
    }
}
