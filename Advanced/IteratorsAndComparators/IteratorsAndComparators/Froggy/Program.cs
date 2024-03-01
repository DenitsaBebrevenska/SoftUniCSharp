namespace Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Lake lake = new (stones);

            List<int> froggyPath = new ();

            foreach (int stone in lake)
            {
                froggyPath.Add(stone);
            }

            Console.WriteLine(string.Join(", ", froggyPath));
        }
    }
}
