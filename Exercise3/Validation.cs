using System;

namespace Exercise3
{
    class Validation
    {
        public static int GetInt(string message = "Enter an integer: ")
        {
            int validatedInt;
            string inputLine = null;

            do
            {
                Console.Write(message);
                inputLine = Console.ReadLine();
            } while (!Int32.TryParse(inputLine, out validatedInt));

            return validatedInt;
        }

        public static int GetInt(int min, int max, string message = "Enter an integer: ")
        {
            int validatedInt;
            string inputLine = null;

            do
            {
                Console.Write(message);
                inputLine = Console.ReadLine();
            } while (!(Int32.TryParse(inputLine, out validatedInt)) || validatedInt < min || validatedInt > max);

            return validatedInt;
        }

        public static bool GetBool(string message = "Enter yes or no.")
        {
            bool validatedBool = false;
            string inputLine;

            bool needValidResponse = true;

            while (needValidResponse)
            {
                Console.WriteLine(message);
                inputLine = Console.ReadLine().ToLower();

                switch (inputLine)
                {
                    case "y":
                    case "yes":
                    case "t":
                    case "true":
                        {
                            validatedBool = true;
                            needValidResponse = false;
                        }
                        break;
                    case "n":
                    case "no":
                    case "f":
                    case "false":
                        {
                            needValidResponse = false;
                        }
                        break;
                }
            }

            return validatedBool;
        }

        public static double GetDouble(string message = "Enter a number: ")
        {
            double validatedDouble;
            string inputLine = null;

            do
            {
                Console.Write(message);
                inputLine = Console.ReadLine();
            } while (!double.TryParse(inputLine, out validatedDouble));

            return validatedDouble;
        }

        public static double GetDouble(double min, double max, string message = "Enter a number: ")
        {
            double validatedDouble;
            string inputLine = null;

            do
            {
                Console.Write(message);
                inputLine = Console.ReadLine();
            } while (!(double.TryParse(inputLine, out validatedDouble)) || validatedDouble < min || validatedDouble > max);

            return validatedDouble;
        }

        public static float GetFloat(string message = "Enter a number: ")
        {
            float validatedFloat;
            string inputLine = null;

            do
            {
                Console.Write(message);
                inputLine = Console.ReadLine();
            } while (!float.TryParse(inputLine, out validatedFloat));

            return validatedFloat;
        }

        public static float GetFloat(double min, double max, string message = "Enter a number: ")
        {
            float validatedFloat;
            string inputLine = null;

            do
            {
                Console.Write(message);
                inputLine = Console.ReadLine();
            } while (!(float.TryParse(inputLine, out validatedFloat)) || validatedFloat < min || validatedFloat > max);

            return validatedFloat;
        }

        public static decimal GetDecimal(string message = "Enter a number: ")
        {
            decimal validatedDecimal;
            string inputLine = null;

            do
            {
                Console.Write(message);
                inputLine = Console.ReadLine();
            } while (!decimal.TryParse(inputLine, out validatedDecimal));

            return validatedDecimal;
        }

        public static decimal GetDecimal(decimal min, decimal max, string message = "Enter a number: ")
        {
            decimal validatedDecimal;
            string inputLine = null;

            do
            {
                Console.Write(message);
                inputLine = Console.ReadLine();
            } while (!(decimal.TryParse(inputLine, out validatedDecimal)) || validatedDecimal < min || validatedDecimal > max);

            return validatedDecimal;
        }
    }
}
