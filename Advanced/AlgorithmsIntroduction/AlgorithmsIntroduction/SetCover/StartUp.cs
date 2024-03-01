namespace SetCover
{
    public class StartUp
    {
        static void Main()
        {
            //Create a program that finds the smallest subset of sets, which contains all elements from a given sequence. 
            // In the Set Cover Problem, we are given two sets - a set of sets (we’ll call it sets) and a universe (a sequence). The sets contain
            // all elements from the universe and no others; however, some elements are repeated. The task is to find the smallest subset of sets
            // that contains all elements in the universe. Use Greedy algorithm.
            List<int> universe = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int rowCount = int.Parse(Console.ReadLine());
            List<int[]> sets = new();

            for (int i = 0; i < rowCount; i++)
            {
                int[] currentArray = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                sets.Add(currentArray);
            }

            List<int[]> subsets = ChooseSets(sets, universe);

            Console.WriteLine($"Sets to take ({subsets.Count}):");

            foreach (var set in subsets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }
        public static List<int[]> ChooseSets(List<int[]> sets, List<int> universe)
        {
            List<int[]> subsets = new();

            while (universe.Count > 0)
            {
                var biggestSubset = sets.OrderByDescending(s => s.Count(x => universe.Contains(x))).First();
                sets.Remove(biggestSubset);
                subsets.Add(biggestSubset);
                universe.RemoveAll(e => biggestSubset.Contains(e));
            }

            return subsets;
        }
    }
}
