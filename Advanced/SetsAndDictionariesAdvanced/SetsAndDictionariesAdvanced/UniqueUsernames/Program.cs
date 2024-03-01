namespace UniqueUsernames
{
    internal class Program
    {
        static void Main()
        {
            byte entryCount = byte.Parse(Console.ReadLine());
            HashSet<string> uniqueUsernames = new HashSet<string>();

            for (int i = 0; i < entryCount; i++)
            {
                uniqueUsernames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\n", uniqueUsernames));
        }
    }
}
