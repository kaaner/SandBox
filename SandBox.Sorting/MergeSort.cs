using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox.Sorting
{
    public static class MergeSort
    {
        public static void Sort<T>(T[] array, int left, int right) where T : IComparable 
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                Sort(array, left, middle);
                Sort(array, left, middle);

                Merge(array, left, middle, right);
            }
        }

        private static void Merge<T>(T[] array, int left, int middle, int right) where T : IComparable
        {
            // 1, 3, 5, 4, 6, 9
            int n1 = middle - left + 1;
            int n2 = right - middle;

            T[] leftArray = new T[n1];
            T[] rightArray = new T[n2];

            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, middle + 1, rightArray, 0, n2);

            // 1, 2, 3  ---  4, 6, 9

            int leftIndex = 0, rightIndex = 0;
            int k = left;

            while (leftIndex < n1 && rightIndex < n2)
            {
                if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) <= 0)
                {
                    array[k] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    array[k] = rightArray[rightIndex];
                    rightIndex++;
                }

                k++;
            }

            while (leftIndex < n1)
            {
                array[k] = leftArray[leftIndex];
                leftIndex++;
                k++;
            }

            while (rightIndex < n2)
            {
                array[k] = rightArray[rightIndex];
                rightIndex++;
                k++;
            }
        }
    }
}
