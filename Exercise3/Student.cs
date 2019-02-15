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

        //Property method for first name
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        //Property method for last name
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        //Property method for Course List list
        public List<Class> CourseList
        {
            get { return _courseList; }
            set { _courseList = value; }
        }

        //Returns a string representing the full name
        public string FullName()
        {
            return $"{_firstName} {_lastName}";
        }

        //Calculates and returns student's combined GPA
        public double GetStudentGPA()
        {
            double returnGPA = 0;
            int numCourses = 0;
            //Gathers GPA values and number of courses
            foreach (Class c in _courseList)
            {
                numCourses += 1;
                returnGPA += c.GetGPAValue();
            }
            //If no courses are available the default value (0) is returned instead, prevents divide by 0 error
            if (numCourses > 0)
            {
                returnGPA = returnGPA / (double)numCourses;
            }
            return returnGPA;
        }

        //Constructor builds student with first and last name
        public Student(string firstname, string lastname)
        {
            _firstName = firstname;
            _lastName = lastname;
        }
    }
}
