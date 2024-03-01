namespace PeriodicTable
{
    internal class Program
    {
        static void Main()
        {
            byte entryCount = byte.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < entryCount; i++)
            {
                string[] currentEntry = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                elements.UnionWith(currentEntry);
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
