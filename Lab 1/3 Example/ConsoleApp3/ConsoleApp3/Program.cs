using System;
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
}