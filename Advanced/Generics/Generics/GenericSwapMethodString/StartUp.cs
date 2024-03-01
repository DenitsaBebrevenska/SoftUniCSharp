namespace GenericSwapMethodString
{
    public class StartUp
    {
        static void Main()
        {
            int entryCount = int.Parse(Console.ReadLine());
            List<int> strings = new List<int>();

            for (int i = 0; i < entryCount; i++)
            {
                strings.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SwapIndexes(strings, indexes[0], indexes[1]);

            foreach (var s in strings)
            {
                Console.WriteLine($"{s.GetType()}: {s}");
            }
        }

        public static void SwapIndexes<T>(List<T> list, int firstIndex, int secondIndex)
        {
            (list[firstIndex], list[secondIndex]) = (list[secondIndex], list[firstIndex]);
        }
    }
}
