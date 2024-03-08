// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
do
{
    while (!Console.KeyAvailable)
    {
        // Enter the factorial number to calculate
        Console.Write("Enter the factorial number to calculate: ");
        int number = int.Parse(Console.ReadLine());

            // Call the Factorial calculation method 
            long total = CalculateFactorial(number);

        // Enter the factorial number to calculate
        Console.WriteLine ("Enter the factorial number to calculate is: " + total);
    }
} while (Console.ReadKey(true).Key != ConsoleKey.X);

int CalculateFactorial(int number)
{
    if (number == 0)
        return 1;

    return number * CalculateFactorial(number - 1);
}