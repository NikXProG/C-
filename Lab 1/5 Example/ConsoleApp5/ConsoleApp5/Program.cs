
namespace Project
{
    using System;
    using System.Linq;
    using System.Security.Principal;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string? input_string = Console.ReadLine();
            if (input_string != null) {
                Console.WriteLine("Вот ваш отсортированная строка первых символов: ");
                Console.WriteLine( SortAndGetLastCharacters(input_string) );
                Console.WriteLine("Вот ваша новая строка 1 и последнего символов верхнего и нижнего регистра: ");
                Console.WriteLine( UpperAndLowerCharacters(input_string) );
                Console.WriteLine("Вот ваше число слов  введеного вами слова: ");
                Console.WriteLine(CountWord(input_string));
                Console.WriteLine("Вот ваша новая строка с замененнными предпоследним словом: ");
                Console.WriteLine(ReplaceWord(input_string));
                Console.WriteLine("Вот выше найденное k-слово с заглавной буквой: ");
                Console.WriteLine(SearchWord(input_string));
            }


        }
        static string SortAndGetLastCharacters(string input) {
            string[] words = input.Split(); // разделяем строку на слова
            Array.Sort(words); // сортируем слова по алфавиту
            string result = "";
            foreach (string myString in words)
            {
                if (myString.Length > 0) // check if the word is not empty
                {
                    result += myString[^1];
                } 
            }
            return result;

        }
        static string UpperAndLowerCharacters(string input)
        {
            string[] words = input.Split(); // разделяем строку на слова
            string result = "";
            foreach (string myString in words)
            {
                if (myString.Length > 0) // check if the word is not empty
                {
                    result += char.ToUpper(myString[0]) + myString.Substring(1, myString.Length - 2) + char.ToLower(myString[^1]) + " ";
                }
            }
            return result;

        }
        static int CountWord(string input)
        {
            string? word = Console.ReadLine();
            string[] words = input.Split(); // разделяем строку на слова
            int count = 0;
            foreach (string myString in words)
            {
                if (myString == word)
                {
                    count++;
                }
            }
            return count;

        }
        static string  ReplaceWord(string input)
        {
            string? word = Console.ReadLine();
            string[] words = input.Split(); // разделяем строку на слова
            string result = "";
            foreach (string myString in words)
            {
                if (myString.Length > 0){
                    if (myString == words[words.Length - 2])
                    {
                        result += word + " ";
                    }
                    else
                    {
                        result += myString + " ";
                    }
                }
            }
            return result;

        }
        static int SearchWord(string input)
        {
            string[] words = input.Split(); // разделяем строку на слова
            Array.Sort(words); // сортируем слова по алфавиту
            int k = 0;
            foreach (string myString in words)
            {
                if (myString.Length > 0) // check if the word is not empty
                {
                    string search = char.IsUpper(myString[0]) + myString.Substring(1, myString.Length - 1);
                    if ( search == myString)
                    {
                        return k;
                    }
                    ++k;
                }
            }
            return k;

        }

    }
}