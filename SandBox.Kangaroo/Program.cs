// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine("Result = " + kangaroo(0, 3, 4, 2));
Console.WriteLine("Result = " + kangaroo(0, 2, 5, 3));
Console.ReadLine();
static String kangaroo(int x1, int v1, int x2, int v2)
{
    /*
     * x1 + n * v1 = x2 + n * v2; 
     */

    if ((x2 - x1) % (v2 - v1) == 0) return "YES";
    else return "NO";

}