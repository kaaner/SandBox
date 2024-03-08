// See https://aka.ms/new-console-template for more information

using SandBox.Yield;
using System.Linq;

//var list = new List<int>();
//list.Add(1);
//list.Add(2);
//list.Add(3);
//list.Add(4);
//list.ToList();
//foreach (var item in list)
//{
//    Console.WriteLine(item);
//}
//Console.ReadLine();
//var enumerator = list.GetEnumerator();
//while (enumerator.MoveNext())
//{
//    Console.WriteLine(enumerator.Current); 
//}

Console.WriteLine("Hello, World!");
Console.Write("Enter a key! ");
var number = Console.ReadLine();
var numbers = Generator.GetOddNumbers().Take(Convert.ToInt32(number));
var enumerator = numbers.GetEnumerator();

var students = Generator.GetStudents();
var enumerator2 = students.GetEnumerator();

while (true)
{
    if (enumerator2.MoveNext())
    {
        Console.WriteLine(enumerator2.Current);
    }
    else break;
}

while (true)
{
    if (enumerator.MoveNext())
    {
        Console.WriteLine(enumerator.Current);
    }
    else break;
}