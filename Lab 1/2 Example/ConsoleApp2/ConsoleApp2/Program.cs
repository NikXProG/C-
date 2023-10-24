using System;
using System.Collections.Generic;
using System.Linq;
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

                Console.WriteLine("Calculated value of e: {0}", lim_e);

                Console.WriteLine("Calculated value of e: {0}", sum_e);


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
                Console.WriteLine(term);
            }

            return result;
        }
        public static double PILim(double epsilon, int maxIterations)
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
        public static double PIsum(double epsilon)
        {
            double term = 1; double result = 1;
            ulong n = 1;

            while (term > epsilon)
            {
                term = 1f / n;
                result += 1f / n;
                n *= ++n;
                Console.WriteLine(term);
            }

            return result;
        }

        /*Console.Write("Enter const for sum E (no more than 20): ");
        input = Console.ReadLine();
        try
        {
            if (input == null)
            {
                throw new Exception("ERROR");
            }


            // Вторая часть по сумме.

            double sum_e = 0;
            double term = 1;
            ulong n = 0;
            epsilon = Convert.ToDouble(input);
            while (term > epsilon)
            {
                term = 1f / n;
                sum_e += 1f / n;
                n++;
            }

            Console.WriteLine("По сумме: {0}", sum_e);

        }
        catch (Exception e)
        {
            Console.WriteLine($"Произошла ошибка: {e.Message}");
        }

    }
    public static ulong factorial(ulong n)
    {
        if (n > 20)
        {
            throw new ArgumentOutOfRangeException("n", "n should be less than or equal to 20.");
        }
        if (n == 0 || n == 1)
        {
            return 1;
        }
        return factorial(n - 1) * n;
    }*/
    }

}