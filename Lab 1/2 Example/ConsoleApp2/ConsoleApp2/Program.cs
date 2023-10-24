using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    throw new Exception("Please provide an epsilon ONE value as a command line argument.");
                }

                if (!Double.TryParse(args[0], out double epsilon))
                {
                    throw new Exception("The provided argument is not a valid decimal number.");
                }

                Console.WriteLine("Calculating e using limit with provided epsilon: {0}", epsilon);

                double lim_e = ELim(epsilon, 10000);

                double sum_e = Esum(epsilon);

                double sum_PI = PIsum(epsilon);

                Console.WriteLine("Calculated value of e LIMIT: {0}", lim_e);

                Console.WriteLine("Calculated value of e SUM: {0}", sum_e);

                Console.WriteLine("Calculated value of PI SUM: {0}", sum_PI);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public static double ELim(double epsilon, int maxIterations)
        {
            double ePrevious = 0;
            double eCurrent = 1;

            for (int n = 1; n <= maxIterations && Math.Abs(eCurrent - ePrevious) > epsilon; n++)
            {
                ePrevious = eCurrent;
                eCurrent = Math.Pow(1 + 1.0 / n, n);
            }

            return eCurrent;
        }
        public static double Esum(double epsilon)
        {
            double term = 1; double result = 1;
            ulong n = 1;

            while (term > epsilon)
            {
                term = 1f / n;
                result += 1f / n;
                n *= ++n;
            }

            return result;
        }



        public static double PIsum(double epsilon)
        {
            double pi = 0;
            int n = 0;
            double term = 1;

            while (Math.Abs(term) >= epsilon)
            {
                term = 1.0 / (2 * n + 1);
                pi += term;
                n++;
            }

            return 4 * pi;
        }
    }

}