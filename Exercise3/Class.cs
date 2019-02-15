using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Class
    {
        string _name;
        double _grade;

        //Property method for name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //Property method for name
        public double Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        //Method returns letter grade based on grade value
        public char GetLetterGrade()
        {
            char returnChar = 'F';

            if (_grade >= 89.5 && _grade <= 100)
            {
                returnChar = 'A';
            }
            else if (_grade >= 79.5 && _grade < 89.5)
            {
                returnChar = 'B';
            }
            else if (_grade >= 72.5 && _grade < 79.5)
            {
                returnChar = 'C';
            }
            else if (_grade >= 69.5 && _grade < 72.5)
            {
                returnChar = 'D';
            }
            return returnChar;
        }

        //Method returns GPA value based on letter grade
        public double GetGPAValue()
        {
            double returnDouble = 0.0;
            char alphaGrade = GetLetterGrade();

            switch (alphaGrade)
            {
                case 'A':
                    returnDouble = 4.0;
                    break;
                case 'B':
                    returnDouble = 3.0;
                    break;
                case 'C':
                    returnDouble = 2.0;
                    break;
                case 'D':
                    returnDouble = 1.0;
                    break;
                default:
                    returnDouble = 0.0;
                    break;
            }

            return returnDouble;
        }

        //Constructor with name and grade
        public Class(string name, double grade)
        {
            _name = name;
            _grade = grade;
        }
    }
}
