using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.MaxProductDifference
{
    public static class Sorting
    {

        public static int Quicksort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Partition the array into two halves and get the pivot index
                int pivotIndex = Partition(arr, low, high);

                // Recursively sort the sub-arrays
                Quicksort(arr, low, pivotIndex - 1);
                Quicksort(arr, pivotIndex + 1, high);
            }

            // Print or store the first two and last two numbers
            if (high - low + 1 >= 4)
            {
                return (arr[low] * arr[low + 1]) - (arr[high - 1] * arr[high]);
                //Console.WriteLine($"First two numbers: {arr[low]}, {arr[low + 1]}, Last two numbers: {arr[high - 1]}, {arr[high]}");
            }
            if (high - low + 1 == 3) return arr[0] * arr[1] - arr[1] * arr[2];
            else return 0;
            //else
            //{
            //    Console.WriteLine("Array too small to print first two and last two numbers.");
            //}
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);

            return i + 1;
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
