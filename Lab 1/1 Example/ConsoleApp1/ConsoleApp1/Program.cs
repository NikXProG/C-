
/*
namespace Project1
{
    using System;
    using static System.Runtime.InteropServices.JavaScript.JSType;
    class Program
    {
        static void Main(string[] args)
        {
            double A = 2, B = -11, C = 12, D = 9 ;
            double qad = Math.Pow(A, 2); // необходимо умножить все уравнение на A в квадрате для замены.

            // Y3 + Y2 + Y * CA + D * A2 = 0 ищем теперь делители D * A2
            double free_const = D * qad;
            for (int i = 1; i <= free_const/2; i++)
            {
                if (free_const % i == 0)
                {
                    int i1 = i;
                    int i2 = -i;
                    Console.WriteLine(i1);
                    if  ((Math.Pow(i1, 3) + (B * Math.Pow(i1, 2)) + (A * C * i1) + free_const) == 0)
                    {
                        // Коэффициенты делимого полинома: 2x^3 - 11x^2 + 12x + 9
                        double[] dividendCoefficients = { 2, -11, 12, 9 };

                        // Коэффициенты делителя: x + 1/2
                        double[] divisorCoefficients = {i1 / 2, 1 };

                        int dividendDegree = dividendCoefficients.Length - 1;
                        int divisorDegree = divisorCoefficients.Length - 1;

                        // Создаем массив для хранения коэффициентов частного
                        double[] quotientCoefficients = new double[dividendDegree - divisorDegree + 1];

                        // Выполняем долгое деление
                        for (int q = 0; q < quotientCoefficients.Length; q++)
                        {
                            quotientCoefficients[i] = dividendCoefficients[q] / divisorCoefficients[0];

                            for (int j = 0; j <= divisorDegree; j++)
                            {
                                dividendCoefficients[q + j] -= quotientCoefficients[q] * divisorCoefficients[j];
                            }
                        }

                        Console.WriteLine("Результат деления: ");
                        Console.WriteLine("Частное: " + string.Join(" ", quotientCoefficients));
                        Console.WriteLine("Остаток: " + string.Join(" ", dividendCoefficients));
                    }

                    if ( (Math.Pow(i2, 3) + (B * Math.Pow(i2, 2)) + (A * C * i2) + free_const) == 0)
                    {
                        // Коэффициенты делимого полинома: 2x^3 - 11x^2 + 12x + 9
                        double[] dividendCoefficients = { 2, -11, 12, 9 };

                        // Коэффициенты делителя: x + 1/2
                        double[] divisorCoefficients = { i2 / 2, 1 };

                        int dividendDegree = dividendCoefficients.Length - 1;
                        int divisorDegree = divisorCoefficients.Length - 1;

                        // Создаем массив для хранения коэффициентов частного
                        double[] quotientCoefficients = new double[dividendDegree - divisorDegree + 1];

                        // Выполняем долгое деление
                        for (int q = 0; q < quotientCoefficients.Length; q++)
                        {
                            quotientCoefficients[q] = dividendCoefficients[q] / divisorCoefficients[0];

                            for (int j = 0; j <= divisorDegree; j++)
                            {
                                dividendCoefficients[q + j] -= quotientCoefficients[q] * divisorCoefficients[j];
                            }
                        }

                        Console.WriteLine("Результат деления: ");
                        Console.WriteLine("Частное: " + string.Join(" ", quotientCoefficients));
                        Console.WriteLine("Остаток: " + string.Join(" ", dividendCoefficients));
                    }
                }
            }
        }

    }
}*/
namespace Project1
{
    class Program
    {
        public struct Result
        {
            public int tip;
            public double p1;
            public double p2;
            public double p3;
        }
        public static Result Kardano(double a, double b, double c, double d)
        {
            Result result = new Result();

            double eps = 1E-14;
            double p = (3 * a * c - b * b) / (3 * a * a);
            double q = (2 * b * b * b - 9 * a * b * c + 27 * a * a * d) / (27 * a * a * a);
            double det = q * q / 4 + p * p * p / 27;
            if (Math.Abs(det) < eps)
                det = 0;
            if (det > 0)
            {
                result.tip = 1; // один вещественный, два комплексных корня
                double u = -q / 2 + Math.Sqrt(det);
                u = Math.Exp(Math.Log(u) / 3);
                double yy = u - p / (3 * u);
                result.p1 = yy - b / (3 * a); // первый корень
                result.p2 = -(u - p / (3 * u)) / 2 - b / (3 * a);
                result.p3 = Math.Sqrt(3) / 2 * (u + p / (3 * u));
            }
            else
            {
                if (det < 0)
                {
                    result.tip = 2; // три вещественных корня
                    double fi;
                    if (Math.Abs(q) < eps) // q=0
                        fi = Math.PI / 2;
                    else
                    {
                        if (q < 0) // q<0
                            fi = Math.Atan(Math.Sqrt(-det) / (-q / 2));
                        else // q<0
                            fi = Math.Atan(Math.Sqrt(-det) / (-q / 2)) + Math.PI;
                    }
                    double r = 2 * Math.Sqrt(-p / 3);
                    result.p1 = r * Math.Cos(fi / 3) - b / (3 * a);
                    result.p2 = r * Math.Cos((fi + 2 * Math.PI) / 3) - b / (3 * a);
                    result.p3 = r * Math.Cos((fi + 4 * Math.PI) / 3) - b / (3 * a);
                }
                else // det=0
                {
                    if (Math.Abs(q) < eps)
                    {
                        result.tip = 4; // 3-х кратный 
                        result.p1 = -b / (3 * a); // 3-х кратный 
                        result.p2 = -b / (3 * a);
                        result.p3 = -b / (3 * a);
                    }
                    else
                    {
                        result.tip = 3; // один и два кратных
                        double u = Math.Exp(Math.Log(Math.Abs(q) / 2) / 3);
                        if (q < 0)
                            u = -u;
                        result.p1 = -2 * u - b / (3 * a);
                        result.p2 = u - b / (3 * a);
                        result.p3 = u - b / (3 * a);
                    }
                }
            }
            return result;
        }
    }
 

