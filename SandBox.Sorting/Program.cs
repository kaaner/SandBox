// See https://aka.ms/new-console-template for more information
using SandBox.Sorting;

Console.WriteLine("Hello, World!");

int[] numbers = { 4, 6, 2, 7, 0, 3 };
string[] names = { "erbi", "kiraz", "ali", "ale", "mehmet" };
//BubbleSort.Sort(numbers);
//BubbleSort.Sort(names);
//SelectionSort.Sort(numbers);
//SelectionSort.Sort(names);
InsertionSort.Sort(numbers);
InsertionSort.Sort(names);

Console.WriteLine(string.Join('-', numbers));
Console.WriteLine(string.Join('-', names));


// 4 -> Quick Sort

int[] intArray = new[] { 9, 2, 6, 2, 7, 0 };
string[] strArray = new[] { "a", "z", "b", "x", "y" };

QuickSort.Hoare(intArray, 0, intArray.Length - 1);
QuickSort.Hoare(intArray, 0, intArray.Length - 1);
QuickSort.Lomuto(intArray, 0, intArray.Length - 1);
QuickSort.Lomuto(strArray, 0, strArray.Length - 1);

Console.WriteLine(string.Join(',', intArray));
Console.WriteLine(string.Join(',', strArray));

Console.ReadLine();