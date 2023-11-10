using System;

public class Program {
    // delegate Func<double, double> equation берет функцию, которую мы задали и вызывает ее с помощью equation
    public static double FindRoot(Func<double, double> equation, double lowerBound, double upperBound, double epsilon)
    {
        double middle;
        double fMiddle;

        do
        {
            middle = (lowerBound + upperBound) / 2;
            fMiddle = equation(middle);

            if (fMiddle == 0 || Math.Abs((upperBound - lowerBound) / 2) < epsilon)
            {
                return middle;
            }

            if (equation(lowerBound) * fMiddle < 0)
            {
                upperBound = middle;
            }
            else
            {
                lowerBound = middle;
            }
        } while (true);
    }

    public static void Main(string[] args)
    {
        double root = FindRoot(x => x * x * x - 27, 0, 10, 0.00001);
        Console.WriteLine("Корень уравнения: " + root);
    }
}