using System;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;

public interface IPrimalityTest
{
    bool PrimeTest(int number, double minProbability);
}
public abstract class ProbabilisticPrimalityTest : HelperFunctions, IPrimalityTest
{
    public int CalculateIterations(double P)
    {
        if (P < 0 || P >= 1)
        {
            throw new ArgumentException("Invalid epsilon value", nameof(P));
        }

        var iterationsCount = 0;
        double accumulator = 1;
        do
        {
            iterationsCount++;
            accumulator *= OneIterationCompositanceProbability;
        } while (accumulator >= 1 - P);

        return iterationsCount;
    }

    protected abstract double OneIterationCompositanceProbability
    {
        get;
    }

    public bool PrimeTest(int number, double Probability)
    {
        if (number <= 0)
        {
            throw new ArgumentException("Value can't be lower or equal to 0", nameof(number));
        }
        if (number == 1)
        {
            throw new ArgumentException("Value 1 is not prime nor composite", nameof(number));
        }
        if (number <= 3)
        {
            return true;
        }
        if (number % 2 == 0 || number % 3 == 0)
        {
            return false;
        }
        var iterationsCount = CalculateIterations(Probability);
        Random random = new Random();
        for (var counter = 0; counter < iterationsCount; counter++)
        {
            int a = random.Next(2, number - 2);
            if (!TestIteration(number, a))
            {
                return false;
            }
        }
        return true;
    }

    protected abstract bool TestIteration(int primeCandidate, int iterationParameter);
}



public class DeterministicPrimalityTest : IPrimalityTest
{
    public bool PrimeTest(int number, double Probability)
    {
        if (number <= 0)
        {
            throw new ArgumentException("Value can't be lower or equal to 0", nameof(number));
        }
        if (number == 1)
        {
            throw new ArgumentException("Value 1 is not prime nor composite", nameof(number));
        }
        if (number <= 3)
        {
            return true;
        }
        if (number % 2 == 0 || number % 3 == 0)
        {
            return false;
        }

        for (int count = 5; count * count <= number; count += 2)
        {
            if (number % count == 0)
            {
                return false;
            }
        }
        return true;
    }
}

public class FermatPrimalityTest : ProbabilisticPrimalityTest
{
    protected override double OneIterationCompositanceProbability =>
        0.5;
    protected override bool TestIteration(int primeCandidate, int iterationParameter)
    {
        if (GreatestCommonDivisor(primeCandidate, iterationParameter) != 1)
        {
            return false;
        }
        if (FastExponentiation(iterationParameter, primeCandidate - 1, primeCandidate) != 1)
        {
            return false;
        }
        return true;
    }
}

public class SolovayStrassenPrimalityTest : ProbabilisticPrimalityTest
{
    protected override double OneIterationCompositanceProbability =>
        0.5;

    protected override bool TestIteration(int primeCandidate, int iterationParameter)
    {
        if (GreatestCommonDivisor(iterationParameter, primeCandidate) > 1)
        {
            return false;
        }

        int jacobi = JacobiSymbol(iterationParameter, primeCandidate);
        int mod = FastExponentiation(iterationParameter, (primeCandidate - 1) / 2, primeCandidate);

        if (jacobi == 0)
        {
            return true;
        }
        if (mod == primeCandidate - 1)
        {
            return true;
        }
        if (mod == jacobi)
        {
            return true;
        }
        if (mod == 1 || mod == 0)
        {
            return true;
        }
        return false;
    }
}

public class MillerRabinPrimalityTest : ProbabilisticPrimalityTest
{
    protected override double OneIterationCompositanceProbability =>
        0.25;
    protected override bool TestIteration(int primeCandidate, int iterationParameter)
    {
        int d = primeCandidate - 1;
        int s = 0;
        while (d % 2 == 0)
        {
            d /= 2;
            s++;
        }

        int Jsimbol = JacobiSymbol(iterationParameter, primeCandidate);
        int mod = FastExponentiation(iterationParameter, d, primeCandidate);

        if (Jsimbol == 0)
        {
            return true;
        }
        if (mod == primeCandidate - 1)
        {
            return true;
        }
        if (mod == Jsimbol)
        {
            return true;
        }
        if (mod == 1 || mod == 0)
        {
            return true;
        }

        for (int counter = 1; counter < s; counter++)
        {
            int exponent = (int)Math.Pow(2, counter);
            int power = FastExponentiation(iterationParameter, d * exponent, primeCandidate);
            if (Jsimbol == 0)
            {
                return true;
            }
            if (power == primeCandidate - 1)
            {
                return true;
            }
            if (power == Jsimbol)
            {
                return true;
            }
            if (power == 1)
            {
                return true;
            }
        }

        return false;
    }
}

public class HelperFunctions
{
    public static int GreatestCommonDivisor(int a, int b)
    {

        while (a != 0 && b != 0)
        {
            if (a > b)
            {
                a = a % b;
            }
            else
            {
                b = b % a;
            }
        }
        return (a + b);
    }

    protected int JacobiSymbol(int iterationParameter, int primeCandidate)
    {
        int r = 1;
        while (iterationParameter != 0)
        {
            int t = 0;
            while ((iterationParameter & 1) == 0)
            {
                t++;
                iterationParameter >>= 1;
            }

            if ((t & 1) != 0)
            {
                int temp = primeCandidate % 6;
                if (temp == 3 || temp == 5)
                {
                    r = -r;
                }
            }
            int c = iterationParameter;
            iterationParameter = primeCandidate % c;
            primeCandidate = c;
        }
        return r;
    }

    protected int FastExponentiation(int iterationParameter, int PowerOfA, int mod)
    {
        string BinaryCode = Convert.ToString(PowerOfA, 2);
        int result = iterationParameter;
        int count = 0;
        while (++count < BinaryCode.Length)
        {
            int c_sign = BinaryCode[count] - '0';
            result *= result;
            if (c_sign == 1)
            {
                result *= iterationParameter;
            }
            result %= mod;
        }
        return result;
    }

}


class Program
{
    static void Main()
    {
        try
        {
            int value = 3;

            bool test1 = new MillerRabinPrimalityTest().PrimeTest(value, 0.99);
            bool test2 = new SolovayStrassenPrimalityTest().PrimeTest(value, 0.99);
            bool test3 = new FermatPrimalityTest().PrimeTest(value, 0.99);
            bool test4 = new DeterministicPrimalityTest().PrimeTest(value, 0.99);
            Console.WriteLine($"Testing Deterministic Primality Test for {value}: {test4}");
            Console.WriteLine($"Testing Fermat Primality Test for  {value}: {test3}");
            Console.WriteLine($"Testing Solovay Strassen Primality Test for {value}: {test2}");
            Console.WriteLine($"Testing Miller Rabin Primality Test for {value}: {test1}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}