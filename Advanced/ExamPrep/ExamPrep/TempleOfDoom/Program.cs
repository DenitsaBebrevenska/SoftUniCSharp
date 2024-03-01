namespace TempleOfDoom
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> tools = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> substances = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            List<int> challenges = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (tools.Count > 0 && substances.Count > 0 && challenges.Count > 0)
            {
                int currentTool = tools.Dequeue();
                int currentSubstance = substances.Pop();

                if (challenges.Any(c => c == currentSubstance * currentTool))
                {
                    challenges.Remove(currentSubstance * currentTool);
                }
                else
                {
                    tools.Enqueue(++currentTool);

                    if (--currentSubstance > 0)
                    {
                        substances.Push(currentSubstance);
                    }
                }
            }


            Console.WriteLine(challenges.Count == 0 ? "Harry found an ostracon, which is dated to the 6th century BCE."
                : "Harry is lost in the temple. Oblivion awaits him.");

            if (tools.Count > 0)
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }

            if (substances.Count > 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }

            if (challenges.Count > 0)
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}
