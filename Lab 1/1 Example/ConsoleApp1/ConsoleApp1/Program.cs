

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace variant
{
    class Program
    {
        static void Main(string[] args)
        {

            double a = 2;
            double b = -11;
            double c = 12;
            double d = 9;

            int variant = 0;

            double y1 = 0, y2 = 0, y3 = 0;
            double x1 = 0, x2 = 0, x3 = 0;

            Kardano_metod(a, b, c, d, ref variant, ref y1, ref y2, ref y3);
            if (variant == 1)
                Console.WriteLine("Один вещественный и два комплексно сопряженных корня: root1={0} root2,3:{1}+-{2}i", y1, y2, y3);
            else if (variant == 2)
                Console.WriteLine("3 действительных корня: root1={0} root2={1} root3={2}", y1, y2, y3);
            else if (variant == 3)
                Console.WriteLine("3 вещественных корня, два из которых кратные: root1={0} root2,3={1}", y1, y2);
            else if (variant == 4)
                Console.WriteLine("3 кратных действительных корня: root1,2,3:{0}", y1);

            Classic_metod(a, b, c, d, ref x1,ref x2,ref x3);
            Console.WriteLine("Корни: root1={0} root2 = {1} root3={2}", x1, x2, x3);
        }

    private static void Classic_metod(double A, double B, double C,double D, ref double x1,ref double x2, ref double x3)
        {
            double qad = Math.Pow(A, 2); // необходимо умножить все уравнение на A в квадрате для замены.

            // Y3 + Y2 + Y * CA + D * A2 = 0 ищем теперь делители D * A2
            double free_const = D * qad;
            for (int i = 1; i <= free_const / 2; i++)
            {
                if (free_const % i == 0)
                {
                    int i1 = i;
                    int i2 = -i;
                    if ((Math.Pow(i1, 3) + (B * Math.Pow(i1, 2)) + (A * C * i1) + free_const) == 0)
                    {

                        // Коэффициенты делителя: x + 1/2
                        x1 = i1 / 2;

                    }
                    else if ((Math.Pow(i2, 3) + (B * Math.Pow(i2, 2)) + (A * C * i2) + free_const) == 0)
                    {


                        // Коэффициенты делителя: x + 1/2
                        x1 = i2 / 2;

                    }


                }
            }
            double b = x1 * A + B;
            double c = x1 * b + C;

            double disc = b * b - 4 * A * c;


            if (D < 0)
            {
                x2 = double.NaN;
                x3 = double.NaN;
            }
            else if (disc == 0)
            {
                 x2 = -b / (2 * A);
                 x3 = x2;
            }
            else
            {
                 x2 = (-b + Math.Sqrt(disc) ) / (2 * A);
                 x3 = (-b - Math.Sqrt(disc) ) / (2 * A);
            }

        }
        private static void Kardano_metod(double coefficientA, double coefficientB, double coefficientC, double coefficientD,
                                               ref int rootType, ref double root1, ref double root2, ref double root3)
        {
            const double epsilon = 1e-14;
            double numeratorP = (3 * coefficientA * coefficientC - Math.Pow(coefficientB, 2)) / (3 * Math.Pow(coefficientA, 2));
            double numeratorQ = (2 * Math.Pow(coefficientB, 3) - 9 * coefficientA * coefficientB * coefficientC
                                 + 27 * Math.Pow(coefficientA, 2) * coefficientD) / (27 * Math.Pow(coefficientA, 3));
            double disc = Math.Pow(numeratorQ, 2) / 4 + Math.Pow(numeratorP, 3) / 27;

            // Check for values close to zero
            if (Math.Abs(disc) < epsilon)
            {
                disc = 0;
            }

            if (disc > 0)
            {
                rootType = 1; // Real distinct root and 2 complex roots case

                double rootCube = -numeratorQ / 2 + Math.Sqrt(disc);
                rootCube = Math.Exp(Math.Log(rootCube) / 3);
                double yy = rootCube - numeratorP / (3 * rootCube);

                root1 = yy - coefficientB / (3 * coefficientA);
                // Complex roots
                root2 = -(rootCube - numeratorP / (3 * rootCube)) / 2 - coefficientB / (3 * coefficientA);
                root3 = Math.Sqrt(3) / 2 * (rootCube + numeratorP / (3 * rootCube));
            }
            else if (disc < 0)
            {
                rootType = 2; // All real roots case

                double fi;
                if (Math.Abs(numeratorQ) < epsilon)
                {
                    fi = Math.PI / 2;
                }
                else
                {
                    fi = numeratorQ < 0 ? Math.Atan(Math.Sqrt(-disc) / (-numeratorQ / 2))
                        : Math.Atan(Math.Sqrt(-disc) / (-numeratorQ / 2)) + Math.PI;
                }
                double r = 2 * Math.Sqrt(-numeratorP / 3);
                root1 = r * Math.Cos(fi / 3) - coefficientB / (3 * coefficientA);
                root2 = r * Math.Cos((fi + 2 * Math.PI) / 3) - coefficientB / (3 * coefficientA);
                root3 = r * Math.Cos((fi + 4 * Math.PI) / 3) - coefficientB / (3 * coefficientA);
            }
            else // if (discriminant == 0)
            {
                if (Math.Abs(numeratorQ) < epsilon)
                {
                    rootType = 4; // All roots are the same
                    root1 = root2 = root3 = -coefficientB / (3 * coefficientA);
                }
                else
                {
                    rootType = 3; // One single root and one positive negative pair
                    double rootCube = Math.Exp(Math.Log(Math.Abs(numeratorQ) / 2) / 3);
                    if (numeratorQ < 0)
                        rootCube = -rootCube;
                    root1 = -2 * rootCube - coefficientB / (3 * coefficientA);
                    root2 = root3 = rootCube - coefficientB / (3 * coefficientA);
                }
            }
        }
    }
}