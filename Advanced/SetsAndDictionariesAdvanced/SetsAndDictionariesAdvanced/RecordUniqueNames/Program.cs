namespace RecordUniqueNames
{
    internal class Program
    {
        static void Main()
        {
            HashSet<string> uniqueNames = new HashSet<string>();
            byte entryCount = byte.Parse(Console.ReadLine());

            for (int i = 0; i < entryCount; i++)
            {
                uniqueNames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\n", uniqueNames));
        }
    }
}
