namespace MergeSortAlgorithm
{
    public class Mergesort<T> where T : IComparable<T>
    {
        public static T[] MergeSort(T[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }

            int mid = arr.Length / 2;

            T[] left = new T[mid];
            T[] right = new T[arr.Length - mid];

            // Copy elements to left and right halves
            for (int i = 0; i < mid; i++)
            {
                left[i] = arr[i];
            }

            for (int i = mid; i < arr.Length; i++)
            {
                right[i - mid] = arr[i];
            }

            // Recursively sort both left and right halves
            left = MergeSort(left);
            right = MergeSort(right);

            // Merge the sorted left and right halves back into the original array
            return Merge(left, right);
        }

        private static T[] Merge(T[] left, T[] right)
        {
            T[] result = new T[left.Length + right.Length];
            int i = 0, j = 0, k = 0;

            // Compare elements from both arrays and add the smaller one to the result
            while (i < left.Length && j < right.Length)
            {
                if (left[i].CompareTo(right[j]) <= 0)
                {
                    result[k++] = left[i++];
                }
                else
                {
                    result[k++] = right[j++];
                }
            }

            // Add remaining elements from either array if available
            while (i < left.Length)
            {
                result[k++] = left[i++];
            }

            while (j < right.Length)
            {
                result[k++] = right[j++];
            }

            return result;
        }
    }
}
