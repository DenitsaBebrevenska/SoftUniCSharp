namespace RubberDuckDebugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> time = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> tasks = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Dictionary<string, int> rewards =
                new()
                {
                    {"Darth Vader Ducky",0},
                    {"Thor Ducky", 0 },
                    {"Big Blue Rubber Ducky", 0},
                    {"Small Yellow Rubber Ducky", 0}
                };

            while (time.Count > 0 && tasks.Count > 0)
            {
                int currentTask = tasks.Pop();
                int result = time.Peek() * currentTask;

                if (result > 240)
                {
                    tasks.Push(currentTask - 2);
                    time.Enqueue(time.Dequeue());
                    continue;
                }

                time.Dequeue();

                if (result <= 60)
                {
                    rewards["Darth Vader Ducky"]++;
                }
                else if (result <= 120)
                {
                    rewards["Thor Ducky"]++;
                }
                else if (result <= 180)
                {
                    rewards["Big Blue Rubber Ducky"]++;
                }
                else
                {
                    rewards["Small Yellow Rubber Ducky"]++;
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            foreach (var kvp in rewards)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
