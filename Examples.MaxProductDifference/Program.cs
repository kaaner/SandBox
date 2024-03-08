using Examples.MaxProductDifference;

int[] array = { 5, 2, 8, 1, 6, 4 };
Console.WriteLine("Original array: " + string.Join(", ", array));

Sorting.Quicksort(array, 0, array.Length - 1);

Console.WriteLine("Sorted array: " + string.Join(", ", array));

Console.WriteLine("Max Product Distance is = " + string.Join(", ", array));
