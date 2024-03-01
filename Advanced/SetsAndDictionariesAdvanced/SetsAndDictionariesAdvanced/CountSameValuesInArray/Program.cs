namespace CountSameValuesInArray
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<double, byte> numberOccurrence = new Dictionary<double, byte>();
            double[] numbers = Console.ReadLine().
                Split().
                Select(double.Parse).
                ToArray();

            foreach (double number in numbers)
            {
                if (!numberOccurrence.ContainsKey(number))
                {
                    numberOccurrence.Add(number, 0);
                }

                numberOccurrence[number]++;
            }

            foreach (var kvp in numberOccurrence)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
