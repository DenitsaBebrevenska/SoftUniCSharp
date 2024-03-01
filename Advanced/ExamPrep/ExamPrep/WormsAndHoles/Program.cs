namespace WormsAndHoles
{
    internal class Program
    {
        static void Main()
        {
            Stack<int> worms = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> holes = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int matchCount = 0;
            int wormTotalCount = worms.Count;

            while (worms.Count > 0 && holes.Count > 0)
            {
                int currentWorm = worms.Peek();
                int currentHole = holes.Peek();
                holes.Dequeue();

                if (currentWorm == currentHole)
                {
                    worms.Pop();
                    matchCount++;
                    continue;
                }

                if (currentWorm > 3)
                {
                    currentWorm -= 3;
                    worms.Pop();
                    worms.Push(currentWorm);
                }
                else
                {
                    worms.Pop();
                }
            }

            Console.WriteLine(matchCount == 0 ? "There are no matches." : $"Matches: {matchCount}");

            if (worms.Count == 0 && matchCount == wormTotalCount)
            {
                Console.WriteLine("Every worm found a suitable hole!");
            }
            else if (worms.Count == 0 && matchCount != wormTotalCount)
            {
                Console.WriteLine("Worms left: none");
            }
            else
            {
                Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
            }

            Console.WriteLine(holes.Count == 0 ? "Holes left: none" : $"Holes left: {string.Join(", ", holes)}");
        }
    }
}
