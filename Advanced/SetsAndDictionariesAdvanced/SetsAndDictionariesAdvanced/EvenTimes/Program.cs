namespace EvenTimes
{
    internal class Program
    {
        static void Main()
        {
            byte entryCount = byte.Parse(Console.ReadLine());
            Dictionary<int, int> numberOccurrence = new Dictionary<int, int>();

            for (int i = 0; i < entryCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numberOccurrence.ContainsKey(number))
                {
                    numberOccurrence.Add(number, 1);
                    continue;
                }

                numberOccurrence[number]++;
            }

            Console.WriteLine(numberOccurrence.First(kvp => kvp.Value % 2 == 0).Key);
        }
    }
}
