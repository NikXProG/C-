

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
                    Console.WriteLine(i2);
                    if  ((Math.Pow(i1, 3) + (B * Math.Pow(i1, 2)) + (A * C * i1) + free_const) == 0)
                    {
                        // Коэффициенты делимого полинома: 2x^3 - 11x^2 + 12x + 9
                        double[] dividendCoefficients = { 2, -11, 12, 9 };

                        // Коэффициенты делителя: x + 1/2
                        double[] divisorCoefficients = {i1 / 2, 1 };
                    }

                    if ( (Math.Pow(i2, 3) + (B * Math.Pow(i2, 2)) + (A * C * i2) + free_const) == 0)
                    {
                        // Коэффициенты делимого полинома: 2x^3 - 11x^2 + 12x + 9
                        double[] dividendCoefficients = { 2, -11, 12, 9 };

                        // Коэффициенты делителя: x + 1/2
                        double[] divisorCoefficients = { i2 / 2, 1 };

                    }
                }
            }
        }

    }
}
/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace num1
{
    class Program
    {

        private static void Kardano(double a, double b, double c, double d, ref int type, ref double p1, ref double p2, ref double p3)
        {
            double eps = 1E-14;
            double p = (3 * a * c - b * b) / (3 * a * a);
            double q = (2 * b * b * b - 9 * a * b * c + 27 * a * a * d) / (27 * a * a * a);
            double det = q * q / 4 + p * p * p / 27;
            if (Math.Abs(det) < eps)
                det = 0;
            if (det > 0)
            {
                type = 1;
                double u = -q / 2 + Math.Sqrt(det);
                u = Math.Exp(Math.Log(u) / 3);
                double yy = u - p / (3 * u);

                p1 = yy - b / (3 * a);
                p2 = -(u - p / (3 * u)) / 2 - b / (3 * a);
                p3 = Math.Sqrt(3) / 2 * (u + p / (3 * u));
            }
            else
            {
                if (det < 0)
                {
                    type = 2;
                    double fi;
                    if (Math.Abs(q) < eps)
                        fi = Math.PI / 2;
                    else
                    {
                        if (q < 0)
                            fi = Math.Atan(Math.Sqrt(-det) / (-q / 2));
                        else
                            fi = Math.Atan(Math.Sqrt(-det) / (-q / 2)) + Math.PI;
                    }
                    double r = 2 * Math.Sqrt(-p / 3);
                    p1 = r * Math.Cos(fi / 3) - b / (3 * a);
                    p2 = r * Math.Cos((fi + 2 * Math.PI) / 3) - b / (3 * a);
                    p3 = r * Math.Cos((fi + 4 * Math.PI) / 3) - b / (3 * a);
                }

                else if (det == 0)
                {
                    if (Math.Abs(q) < eps)
                    {
                        type = 4;
                        p1 = -b / (3 * a);
                        p2 = -b / (3 * a);
                        p3 = -b / (3 * a);
                    }
                    else
                    {
                        type = 3;
                        double u = Math.Exp(Math.Log(Math.Abs(q) / 2) / 3);
                        if (q < 0)
                            u = -u;
                        p1 = -2 * u - b / (3 * a);
                        p2 = u - b / (3 * a);
                        p3 = u - b / (3 * a);
                    }
                }
            }
        }

        static void Main(string[] args)
        {

            double a = 99.0;
            double b = -28.4;
            double c = 8.0;
            double d = 0.0;

            int variant = 0;

            double p1 = 0, p2 = 0, p3 = 0;

            Kardano(a, b, c, d, ref variant, ref p1, ref p2, ref p3);
            if (variant == 1)
                Console.WriteLine("Один вещественный и два комплексно сопряженных корня: root1={0} root2,3:{1}+-{2}i", p1, p2, p3);
            else if (variant == 2)
                Console.WriteLine("3 действительных корня: root1={0} root2={1} root3={2}", p1, p2, p3);
            else if (variant == 3)
                Console.WriteLine("3 вещественных корня, два из которых кратные: root1={0} root2,3={1}", p1, p2);
            else if (variant == 4)
                Console.WriteLine("3 кратных действительных корня: root1,2,3:{0}", p1);

        }

    }
}*/