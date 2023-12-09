
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    class MathOperation
    {

        public static long Factorial(int n)
        {
            int f = 1;
            for (int i = 2; i < n + 1; i++) { f *= i; }
            return f;
        }

    }
    class СalculationsFunctions : MathOperation {
        public static double Lnx(double epsilon)
        {
            double x = 1.0;
            while (Math.Abs(Math.Log(x) - 1.0) > epsilon)
            {
                x *= Math.Exp(1 - Math.Log(x));
                if (x >= 0)
                {
                    return x;
                }

            }
            return double.NaN;
        }

        // 3.2
        public static double Cosx(double epsilon)
        {
            double x = Math.PI;

            while (Math.Abs(Math.Cos(x) + 1.0) > epsilon)
            {
                x -= (Math.Cos(x) + 1.0) / Math.Sin(x);
            }

            return x;
        }

        //3.3
        public static double Ex(double epsilon)
        {
            double x = 0.0;

            while (Math.Abs(Math.Exp(x) - 2.0) > epsilon)
            {
                x -= (Math.Exp(x) - 2.0) / Math.Exp(x);
            }
            return x;
        }

        public static double X2(double epsilon)
        {
            double xn = 1.0;
            double xn_prev;
            do
            {
                xn_prev = xn;
                xn = xn_prev - (xn_prev * xn_prev - 2) / (2 * xn_prev);
            } while (Math.Abs(xn - xn_prev) > epsilon);
            return xn;
        }

        public static double eminx(double epsilon)
        {
            return 0;
        }

        public static double SumE(double epsilon)
        {
            double sum = 0;
            int n = 0;
            double term = 1.0;
            while (term >= epsilon)
            {
                term = 1.0 / Factorial(n);
                sum += term;
                n++;
            }
            return sum;
        }

        public static double SumPi(double epsilon)
        {
            double sum = 0;
            int n = 1;
            double term = 1.0;
            while (Math.Abs(term) > epsilon)
            {
                term = (double)Math.Pow(-1, n - 1) / (2 * n - 1);
                sum += term;
                n++;
            }
            return sum * 4;
        }

        public static double SumLn2 (double epsilon)
        {

            double sum = 0;
            int n = 1;
            double term = 1.0;
            while (Math.Abs(term) > epsilon)
            {
                term = (double)Math.Pow(-1, n - 1) / n;
                sum += term;
                n++;
            }
            return sum;
        }

        public static double SumSqrt2(double epsilon)
        {
            double product = 1.0;
            double term;
            int k = 2;
            do
            {
                term = Math.Pow(2, -k);
                product *= Math.Pow(2, term);
                k++;
            } while (epsilon < term);

            return product;
        }


        public static double SumY(double epsilon)
        {
            double sum = 0.0;

            for (int k = 2; ; k++)
            {
                double term = 1.0 / Math.Pow(Math.Sqrt(k), 2) - 1.0 / k;
                sum += term;
                if (Math.Abs(term) < epsilon)
                {
                    break;
                }
            }

            return -Math.PI * Math.PI / 6 + sum;
        }

        public static double LimE(double epsilon)
        {
            double prev = 0, currectValue = 1;
            for (int counter = 1; counter <= int.MaxValue && Math.Abs(currectValue - prev) > epsilon; counter++)
            {
                prev = currectValue;
                currectValue = Math.Pow(1 + 1.0 / counter, counter);
            }
            return currectValue;
        }
        public static double LimPi(double epsilon)
        {
            double previousValue = 0;
            double currentValue = 0;
            int n = 1;
            do
            {
                previousValue = currentValue;

                currentValue = (Math.Pow(16, n) * Math.Pow(Factorial(n), 4)) / (n * Math.Pow(Factorial(2 * n), 2));

                if (Math.Floor(currentValue) > 5) {return previousValue;}
                n++;
            } while (Math.Abs(currentValue - previousValue) > epsilon);

            return currentValue;
        }


        public static double LimLn2(double epsilon)
        {
            double prev = 0, currentValue = 2;
            for (int counter = 1; counter <= int.MaxValue && Math.Abs(currentValue - prev) > epsilon; counter++)
            {
                prev = currentValue;
                currentValue = counter * (Math.Pow(2, 1.0 / counter) - 1);
            }
            return currentValue;
        }

        public static double LimSqrt2(double epsilon)
        {
            double prev = 0, cur = -0.5;
            for (int counter = 1; counter <= int.MaxValue && Math.Abs(cur - prev) > epsilon; counter++)
            {
                prev = cur;
                cur = prev - (Math.Pow(prev, 2) / 2) + 1;
            }
            return cur;
        }

        public static double LimY(double epsilon)
        {
            double sum = 0.0;
            int m = 1;

            do
            {
                double term = CalculateTerm(m);
                sum += term;
                m++;
            } while (Math.Abs(sum) > epsilon);

            return sum;
        }

        private static double CalculateTerm(int m)
        {
            double term = 0.0;
            for (int k = 1; k <= m; k++)
            {
                double coefficient = Factorial(m) / (Factorial(k) * Factorial(m - k));
                term += coefficient * Math.Pow(-1, k) / k * Math.Log(Factorial(k));
            }
            return term;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double epsilon = double.Parse(args[0]);

            // e

            double decision = СalculationsFunctions.LimE(epsilon);

            Console.WriteLine($"Второй замечательный предел: {decision}");


            decision = СalculationsFunctions.SumE(epsilon);

            Console.WriteLine($"Sum(от 0 до бесконечности) 1/n!: {decision}");

            decision = СalculationsFunctions.Lnx(epsilon);

            Console.WriteLine($"ln x = 1: {decision}\n");

            // ...


            // π

            decision = СalculationsFunctions.LimPi(epsilon);
            Console.WriteLine($"Предел пи: {decision}");

            decision = СalculationsFunctions.SumPi(epsilon);
            Console.WriteLine($"Сумма ряда для числа пи: {decision}");

            decision = СalculationsFunctions.Cosx(epsilon);
            Console.WriteLine($"Решение уравнения cos x = -1: {decision}\n");

            // ...

            // ln 2 

            decision = СalculationsFunctions.LimLn2(epsilon);
            Console.WriteLine($"Предел Ln2: {decision}");

            decision = СalculationsFunctions.SumLn2(epsilon);
            Console.WriteLine($"Сумма ряда ln2 = Σ((-1)^(n-1)/n: {decision}");

            decision = СalculationsFunctions.Ex(epsilon);
            Console.WriteLine($"Решение уравнения e^x = 2: {decision}\n");

            // ...


            //√2

            decision = СalculationsFunctions.LimSqrt2(epsilon);
            Console.WriteLine($"Предел корня из 2: {decision}");

            decision = СalculationsFunctions.SumSqrt2(epsilon);

            Console.WriteLine($"Сумма ряда sqrt(2) = П((2)^2)^-k): {decision}");

            decision = СalculationsFunctions.X2(epsilon);
            Console.WriteLine($"Решение уравнения x^2 = 2: {decision}\n");

            //...

            //Y
            decision = СalculationsFunctions.LimY(epsilon);
            Console.WriteLine($"предел Y: {decision}");

            decision = СalculationsFunctions.SumY(epsilon);
            Console.WriteLine($"Сумма ряда: {decision}");

            decision = СalculationsFunctions.eminx(epsilon);
            Console.WriteLine($"Решение e^-x: {decision}\n");

            //...

        }
    }

}