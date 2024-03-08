using System;

class Program
{
    static void Main()
    {
        try
        {
            double pi = CalculatePi();
            Console.WriteLine($"Pi to the tenth digit: {pi:F10}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static double CalculatePi()
    {
        double a = 1.0;
        double b = 1.0 / Math.Sqrt(2);
        double t = 1.0 / 4.0;
        double p = 1.0;

        for (int i = 0; i < 10; i++)
        {
            double aNext = (a + b) / 2.0;
            double bNext = Math.Sqrt(a * b);
            double tNext = t - p * (a - aNext) * (a - aNext);
            double pNext = 2.0 * p;

            a = aNext;
            b = bNext;
            t = tNext;
            p = pNext;
        }

        // π is approximately (a + b)² / (4 * t)
        return (a + b) * (a + b) / (4 * t);
    }
}
