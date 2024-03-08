do
{
    while (!Console.KeyAvailable)
    {
            // User input for the length of the Fibonacci sequence
            Console.Write("Enter the length of the Fibonacci sequence: ");
            int length = int.Parse(Console.ReadLine());

            // Output the Fibonacci sequence up to the specified length
            Console.WriteLine("Fibonacci Sequence:");

            for (int i = 0; i < length; i++)
            {
                // Call the Fibonacci calculation method for each index
                int fibonacciNumber = CalculateFibonacci(i);

                // Output the current Fibonacci number
                Console.Write(fibonacciNumber + " ");
            }
        }
} while (Console.ReadKey(true).Key != ConsoleKey.X);

int CalculateFibonacci(int n)
{
    if (n <= 1)
        return 1;

    return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
}