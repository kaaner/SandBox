// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
List<int> a = new List<int> { 1 };
List<int> b = new List<int> { 100 };
var result = getTotalX(a, b);
Console.WriteLine("Counter is = " + result.ToString());
static int getTotalX(List<int> a, List<int> b)
{
    int counter = 0;
    for (int i = a[0]; i <= b.Last(); i++)
    {
        if (a.All(x => i % x == 0) && b.All(y => y % i == 0)) {  counter++; }
    }

    // Write your code here
    return counter;
}