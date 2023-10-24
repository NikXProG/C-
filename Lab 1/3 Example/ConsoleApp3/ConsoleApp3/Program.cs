/*using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        bool readFromConsole = true;
        string? input = "";

        if (args.Length == 2 && args[0] == "-f")
        {

            try
            {
                input = File.ReadAllText(args[1]);
                readFromConsole = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
                return;
            }
        }

        else if ((args.Length == 1 && args[0] == "-c") && (readFromConsole))
        {
            Console.WriteLine("Введите последовательность символов, разделенных пробелами:");
            input = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("INVALID COUNT ARGUMENTS");
            return;
        }

        string[] characters = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int sum = 0;
        int count = 0;

        foreach (string character in characters)
        {
            foreach (char ch in character)
            {
                sum += (int)ch;
                count++;
            }
        }

        if (count > 0)
        {
            double average = (double)sum / count;
            Console.WriteLine($"Среднее арифметическое кодов символов: {average}");
        }
        else
        {
            Console.WriteLine("NULL-ERROR: Введена пустая последовательность символов.");
        }
    }
}*/
using System;
using System.Collections.Generic;
using System.Globalization;

namespace NumericDataProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа, разделяя их пробелами (для окончания ввода введите 'done'):");
            string? input = Console.ReadLine();
            if (input == null) {
                Console.WriteLine("NULL-ERROR: введена пустая строка");
            }
            string[] numberStrings = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            List<double> numbers = new List<double>();

            foreach (string numberString in numberStrings)
            {
                double number;
                if (double.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out number))
                {
                    numbers.Add(number);
                }
                else if (numberString == "done")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка! Недопустимый символ: " + numberString);
                    return;
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("Не было введено ни одного числа.");
                return;
            }

            double geometricMean = CalculateGeometricMean(numbers);
            double harmonicMean = CalculateHarmonicMean(numbers);

            Console.WriteLine("Среднее геометрическое: " + geometricMean.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Среднее гармоническое: " + harmonicMean.ToString("F2", CultureInfo.InvariantCulture));
        }

        static double CalculateGeometricMean(List<double> numbers)
        {
            double product = 1.0;
            int count = 0;

            foreach (double number in numbers)
            {
                // Пропускаем отрицательные числа, так как их нельзя использовать в геометрическом среднем
                if (number < 0)
                {
                    continue;
                }

                product *= number;
                count++;
            }

            if (count == 0 || product == 1.0)
            {
                return 0.0; // Если не найдено ни одного неотрицательного числа, вернуть 0
            }

            return Math.Pow(product, 1.0 / count);
        }

        static double CalculateHarmonicMean(List<double> numbers)
        {
            double sumInverses = 0.0;
            int count = 0;

            foreach (double number in numbers)
            {
                // Пропускаем нулевые числа, так как их нельзя использовать в гармоническом среднем
                if (number == 0)
                {
                    continue;
                }

                sumInverses += 1.0 / number;
                count++;
            }

            if (count == 0)
            {
                return 0.0; // Если не найдено ни одного ненулевого числа, вернуть 0
            }

            return count / sumInverses;
        }
    }
}