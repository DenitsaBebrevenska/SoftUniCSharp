namespace OffroadChallenge
{
    internal class Program
    {
        static void Main()
        {
            Stack<int> initialFuel = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> additionFuelIndeces = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> neededFuel = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            List<string> reachedAltitudes = new List<string>();

            int altitudesReachedCount = 0;

            while (true)
            {
                if (initialFuel.Peek() - additionFuelIndeces.Peek() >= neededFuel.Peek())
                {
                    initialFuel.Pop();
                    additionFuelIndeces.Dequeue();
                    neededFuel.Dequeue();
                    reachedAltitudes.Add($"Altitude {++altitudesReachedCount}");
                    Console.WriteLine($"John has reached: Altitude {altitudesReachedCount}");
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {altitudesReachedCount + 1}");
                    break;
                }

                if (neededFuel.Count == 0)
                {
                    Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
                    Environment.Exit(0);
                }
            }

            if (reachedAltitudes. Count > 0)
            {
                Console.WriteLine("John failed to reach the top.");
                Console.WriteLine($"Reached altitudes: {string.Join(", ", reachedAltitudes)}");
            }

            if (reachedAltitudes. Count == 0)
            {
                Console.WriteLine("John failed to reach the top.");
                Console.WriteLine("John didn't reach any altitude.");
            }
        }
    }
}
