namespace Quicksort
{
    public class Quick
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            Shuffle(array);
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, int lowest, int highest) where T : IComparable<T>
        {
            if (lowest >= highest)
                return;

            int partition = Partition(array, lowest, highest);
            Sort(array, lowest, partition - 1);
            Sort(array, partition + 1, highest);
        }

        private static int Partition<T>(T[] array, int lowest, int highest) where T : IComparable<T>
        {
            if (lowest >= highest)
                return lowest;

            int i = lowest;
            int j = highest + 1;
            while (true)
            {
                while (array[++i].CompareTo(array[lowest]) < 0)
                    if (i == highest)
                        break;

                while (array[lowest].CompareTo(array[--j]) < 0)
                    if (j == lowest)
                        break;

                if (i >= j) break;
                Swap(array, i, j);
            }

            Swap(array, lowest, j);
            return j;
        }

        static void Swap<T>(T[] array, int i, int j)
        {
            (array[i], array[j]) = (array[j], array[i]);
        }

        private static void Shuffle<T>(T[] a) where T : IComparable<T>
        {
            Random random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                int j = i + random.Next(0, a.Length - i);
                Swap(a, i, j);
            }
        }
    }
}
