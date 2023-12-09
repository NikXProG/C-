using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class MatOperation
{
    public static BigInteger FastExponentiation(int number, int degree)
    {
        string BinaryCode = Convert.ToString(degree, 2);
        BigInteger result = number;
        int count = 0;
        while (++count < BinaryCode.Length)
        {
            int c_sign = BinaryCode[count] - '0';
            result *= result;
            if (c_sign == 1)
            {
                result *= number;
            }
        }
        return result;
    }
    public static int GreatestCommonDivisor(int a, int b) 
    {

        while (a != 0  && b != 0) {
            if (a > b)
            {
                a = a % b;
            }
            else{
                b = b % a;
            }
        }
        return (a + b);
    }
    public static int JakobiSymbol(int a, int n)
    {
        if (a == 1)
        {
            return 1;
        }
        if (a == 2)
        {
            if (((n * n - 1) / 8) % 2 == 0)
               ( ( (n*n - 1) / 8 ) % 2 == 0) ? (return 1) : (return -1);

        }
    }
    public static int L(int a, int p)
    {

        if  (a % p == 0)
        {
            return 0;
        }
        else if (((int) (MatOperation.FastExponentiation(a, (p - 1) / 2) % p)) ==1)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}
public class Nahui
{
    public static bool Solovei(int n, int k)
    {
        if (n < 2)
            return false;
        if (n != 2 && n % 2 == 0)
            return false;

        int s = 0;
        int t = n - 1;

        while (t % 2 == 0)
        {
            s++;
            t /= 2;
        }

        for (int i = 0; i < k; i++)
        {
            Random random = new Random();
            int a = random.Next(2, n - 1);
            int x = (int)MatOperation.FastExponentiation(a, t) % n;
            if (x == 1 || x == n - 1)
                continue;

            for (int j = 0; j < s - 1; j++)
            {
                x = (int)MatOperation.FastExponentiation(x, 2) % n;
                if (x == 1)
                    return false;
                if (x == n - 1)
                    break;
            }
            if (x != n - 1)
                return false;
        }
        return true;
    }
}
namespace Project
{
    class Program
    {
        static int Main(string[] args)
        {
            MatOperation.JakobiSymbol(11, 15);
            int n = 4;
            Console.WriteLine(Nahui.Solovei(19, 1));
            return 0;
        }
    }
}