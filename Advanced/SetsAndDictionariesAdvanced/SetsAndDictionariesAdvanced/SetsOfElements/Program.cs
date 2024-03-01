namespace SetsOfElements
{
    internal class Program
    {
        static void Main()
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            int[] entries = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            for (int i = 0; i < entries[0] + entries[1]; i++)
            {
                if (i < entries[0])
                {
                    firstSet.Add(int.Parse(Console.ReadLine()));
                    continue;
                }

                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(" ", firstSet));

        }
    }
}
