namespace SandBox.Sorting
{
    public static class QuickSort
    {
        public static void Lomuto<T>(T[] array, int low, int high) where T : IComparable
        {
            if (low < high)
            {
                var partitionIndex = PartitionLomuto(array, low, high);

                Lomuto(array, low, partitionIndex - 1);
                Lomuto(array, partitionIndex + 1, high);
            }
        }
        private static int PartitionLomuto<T>(T[] array, int low, int high) where T : IComparable
        {
            {
                var pivot = array[high];
                int i = low - 1;

                for (int j = low; j < high; j++)
                {
                    if (array[j].CompareTo(pivot) < 0)
                    {
                        i++;
                        Swap(array, i, j);
                    }
                }

                Swap(array, i + 1, high);

                return i + 1;
            }
        }
        public static void Hoare<T>(T[] array, int low, int high) where T : IComparable
            {
            if (low < high)
            {
                var partitionIndex = PartitionHoare(array, low, high);

                Hoare(array, low, partitionIndex);
                Hoare(array, partitionIndex + 1, high);
            }
        }
        internal static int PartitionHoare<T>(T[] array, int low, int high) where T : IComparable
            {
            var pivot = array[low];
            int i = low - 1, j = high + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (array[i].CompareTo(pivot) < 0);

                do
                {
                    j--;
                } while (array[j].CompareTo(pivot) > 0);

                if (i >= j)
                    return j;

                Swap(array, i, j);
            }
        }
        internal static void Swap<T>(T[] array, int i, int j) where T : IComparable
            {
            (array[i], array[j]) = (array[j], array[i]);
        }

    }
}
