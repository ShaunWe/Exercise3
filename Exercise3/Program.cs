using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Program
    {
        static int rand = 0;
        static void Main(string[] args)
        {
            /*
             * Shaun Wehe
             * Exercise 3
             * February 12, 2019
             */

            string inputLine;
            string menu = "Hello Administrator\n" +
                "\n" +
                "Please select an action from the following list:\n" +
                "1. Review Students (Students)\n" +
                "2. Review GPA (GPA)\n" +
                "3. Edit Student (Edit)\n" +
                "4. Exit";
            string[] classList = new string[] { "History of Clothing", "Clothing Design", "Marketing Clothing", "Clothing Business101", "Market Analysis"};
            string[] firstNameList = new string[] { "Bob", "Mary", "Ryan" };
            string[] lastNameList = new string[] { "O'Malley", "Reynolds", "Oldman" };
            bool programRunning = true;

            List<Student> students = new List<Student>();
            Student tempStudent = null;
            Class tempClass = null;

            //This is setting up 3 students to be used in this using the identified arrays to loop through
            for (int n = 0; n < firstNameList.Length; n++)
            {
                tempStudent = new Student(firstNameList[n], lastNameList[n]);
                //Thiis sets up the five named classes with a random grade between 60-100
                for (int i = 0; i < classList.Length; i++)
                {
                    tempClass = new Class(classList[i], GetRandomDouble(60.0, 100.0));
                    tempStudent.CourseList.Add(tempClass);
                }
                students.Add(tempStudent);
            }

            while (programRunning)
            {
                //This clears the screen and displays the menu asking for the user entry
                Console.Clear();
                Console.WriteLine(menu);
                Console.Write("\nSelection: ");
                inputLine = Console.ReadLine().ToLower();

                //Based on the user input, various actions are taken
                switch (inputLine)
                {
                    case "1":
                    case "students":
                        DisplayStudents(students);
                        break;
                    case "2":
                    case "gpa":
                        DisplayGPA(students, classList);
                        break;
                    case "3":
                        EditStudent(students);
                        break;
                    case "4":
                    case "exit":
                        programRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid entry.\n");
                        Utility.KeyToProceed();
                        break;
                }
            }
            
        }

        public static void DisplayStudents(List<Student> students)
        {
            bool loopRunning = true;
            int selection = 0;
            //This loop runs until a valid selection is made
            while (loopRunning)
            {
                //Displays list of students
                Console.Clear();
                Console.WriteLine("====================");
                Console.WriteLine("===   Students   ===");
                Console.WriteLine("====================");
                Console.WriteLine();
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {students[i].FullName()}\n");
                }
                Console.WriteLine($"{students.Count + 1}. Back");
                Console.WriteLine();
                Console.WriteLine("====================");
                Console.WriteLine();
                Console.Write("Which student would you like to review the classes of:");
                string input = Console.ReadLine().ToLower();

                //Checks for input to go back
                if (input == $"{students.Count+1}" || input == "back")
                {
                    return;
                }
                //Checks input against Student names and numbers
                for (int i = 0; i < students.Count; i++)
                {
                    if (input == $"{i + 1}" || input == students[i].FullName().ToLower() || input == students[i].FirstName.ToLower())
                    {
                        selection = i;
                        loopRunning = false;
                        break;
                    }
                }

                //If the check did not find anything, tell user invalid input was received
                if (loopRunning)
                {
                    Console.WriteLine("That is not a recognized entry. Please enter the students number or full name or first name.");
                    Utility.KeyToProceed();
                }
            }

            //Display student information to user
            Console.Clear();
            Console.WriteLine($"Student Name: {students[selection].FullName()}\n" +
                $"Overall GPA: {students[selection].GetStudentGPA().ToString("n")}\n" +
                $"========================================");
            foreach (Class c in students[selection].CourseList)
            {
                Console.WriteLine($"Course Name: {c.Name}\n" +
                    $"Grade: {c.Grade.ToString("n")}\tLetter Grade: {c.GetLetterGrade()}\n" +
                    $"========================================");
            }
            Utility.KeyToProceed();
        }

        public static void DisplayGPA(List<Student> students, string[] courseNames)
        {
            double[] courseGPA = new double[courseNames.Length];
            int num = 0;
            double GPAvalue = 0;
            //This loop gathers the GPA value from each student by each course and then averages it, storing it in the courseGPA array
            for (int i = 0; i < courseNames.Length; i++)
            {
                num = 0;
                GPAvalue = 0;
                foreach (Student s in students)
                {
                    num += 1;
                    GPAvalue += s.CourseList[i].GetGPAValue();
                }
                //Ensures there is no divide by 0 error, and performs calculation
                if (num > 0)
                {
                    GPAvalue = GPAvalue / num;
                }
                else
                {
                    GPAvalue = 0;
                }
                courseGPA[i] = GPAvalue;
            }

            //This displays each course and the collective GPA in the course
            Console.Clear();
            Console.WriteLine("==================================================");
            for (int i = 0; i < courseNames.Length; i++)
            {
                Console.WriteLine($"== Course: {courseNames[i]}\t|| GPA: {courseGPA[i].ToString("n")}\t==\n" +
                    $"==================================================");
            }
            Console.WriteLine();
            Utility.KeyToProceed();
        }

        public static void EditStudent(List<Student> students)
        {
            bool loopRunning = true;
            int selection = 0, iterator = 0, courseSelection = 0;
            double newGrade;

            //Loop runs until valid selection is made
            while (loopRunning)
            {
                //Displays list of students
                Console.Clear();
                Console.WriteLine("====================");
                Console.WriteLine("===   Students   ===");
                Console.WriteLine("====================");
                Console.WriteLine();
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {students[i].FullName()}\n");
                }
                Console.WriteLine($"{students.Count + 1}. Back\n");
                Console.WriteLine("====================");
                Console.WriteLine();
                Console.Write("Which student would you like to edit:");
                string input = Console.ReadLine().ToLower();

                //Checks for input to go back
                if (input == $"{students.Count + 1}" || input == "back")
                {
                    return;
                }
                //Checks input against Student names and numbers
                for (int i = 0; i < students.Count; i++)
                {
                    if (input == $"{i + 1}" || input == students[i].FullName().ToLower() || input == students[i].FirstName.ToLower())
                    {
                        selection = i;
                        loopRunning = false;
                        break;
                    }
                }

                //If the check did not find anything, tell user invalid input was received
                if (loopRunning)
                {
                    Console.WriteLine("That is not a recognized entry. Please enter the students number or full name or first name.");
                    Utility.KeyToProceed();
                }
            }

            //Loop runs until selection is made
            loopRunning = true;
            while (loopRunning)
            {
                //Displays students courses and grades
                iterator = 0;
                Console.Clear();
                Console.WriteLine($"Student Name: {students[selection].FullName()}\n" +
                $"Overall GPA: {students[selection].GetStudentGPA().ToString("n")}\n" +
                $"========================================");
                foreach (Class c in students[selection].CourseList)
                {
                    iterator += 1;
                    Console.WriteLine($"{iterator}. Course Name: {c.Name}\n" +
                        $"Grade: {c.Grade.ToString("n")}\tLetter Grade: {c.GetLetterGrade()}\n" +
                        $"========================================");
                }

                Console.Write($"{students[selection].CourseList.Count + 1}. Back\n\n" +
                    $"Select a course to edit using the number or course name: ");
                string input = Console.ReadLine().ToLower();

                //Checks the input to go back
                if (input == $"{students[selection].CourseList.Count + 1}" || input == "back")
                {
                    return;
                }
                //Checks input against course names and numbers
                for (int i = 0; i < students[selection].CourseList.Count; i++)
                {
                    if (input == $"{i + 1}" || input == students[selection].CourseList[i].Name.ToLower())
                    {
                        courseSelection = i;
                        loopRunning = false;
                        break;
                    }
                }

                //If the check did not find anything, tell user invalid input was received
                if (loopRunning)
                {
                    Console.WriteLine("That is not a recognized entry. Please enter the students number or full name or first name.");
                    Utility.KeyToProceed();
                }
            }

            //Ask user for new grade value and set new grade value
            newGrade = Validation.GetDouble(0, 100, $"Enter the new grade for {students[selection].CourseList[courseSelection].Name} (0-100): ");
            students[selection].CourseList[courseSelection].Grade = newGrade;

            //Inform user of success
            Console.WriteLine($"{students[selection].FullName()}'s grade for {students[selection].CourseList[courseSelection].Name} has been set to {students[selection].CourseList[courseSelection].Grade}");
            Utility.KeyToProceed();
        }

        public static double GetRandomDouble(double min, double max)
        {
            //Creates a random double number and iterates it based on static rand variable
            Random random = new Random();
            rand += 1;
            double returnValue = 0;
            for (int i = 0; i < rand; i++)
            {
                returnValue = random.NextDouble() * (max - min) + min;
            }
            return returnValue;
        }
    }
}
