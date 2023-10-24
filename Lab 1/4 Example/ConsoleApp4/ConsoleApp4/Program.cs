namespace Project
{
        using System;

        class Program
        {
        static void Main(string[] args)
        {
            decimal number = 128.323m;
            int baseNumber = 16;

            string result = Convert(number, baseNumber);
            Console.WriteLine(result);
        }
        public static string Convert(decimal number, int baseNumber)
        {
            if (baseNumber < 2 || baseNumber > 36)
            {
                throw new ArgumentOutOfRangeException("baseNumber", "The base number should be in the range [2..36].");
            }

            long wholePart = (long)number;
            decimal fractionalPart = number - wholePart;

            string result = ConvertWholePart(wholePart, baseNumber);

            if (fractionalPart > 0)
            {
                result += ".";
                result += ConvertFractionalPart(fractionalPart, baseNumber);
            }

            return result;
        }

        private static string ConvertWholePart(long number, int baseNumber)
        {
            string result = "";

            while (number > 0)
            {
                long remainder = number % baseNumber;
                result = GetDigitFromValue((int)remainder) + result;
                number = number / baseNumber;
            }

            return result;
        }

        private static string ConvertFractionalPart(decimal number, int baseNumber)
        {
            const int maxPrecision = 20; 

            string result = "";
            int precision = 0;
            long wholePart = (long)number;
            decimal fractionalPart = number - wholePart;
            decimal epsilon = 1e-9m; 

            while (fractionalPart > epsilon && precision < maxPrecision)
            {
                fractionalPart *= baseNumber;
                long digit = (long)fractionalPart;
                result += GetDigitFromValue((int)digit);
                fractionalPart -= digit;
                precision++;
            }

            if (fractionalPart > epsilon)
            {
                int startIndex = result.IndexOf(result[result.Length - 1]);
                string repeatingPart = result.Substring(startIndex);
                result = result.Substring(0, startIndex) ;
            }

            return result;
        }

        private static char GetDigitFromValue(int value)
        {
            if (value < 10)
            {
                return (char)('0' + value);
            }
            else
            {
                return (char)('A' + value - 10);
            }
        }
    }
}
