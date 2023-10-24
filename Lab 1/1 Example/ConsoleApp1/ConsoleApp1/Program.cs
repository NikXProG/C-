

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
}