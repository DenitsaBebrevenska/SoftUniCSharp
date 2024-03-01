namespace Largest3Numbers
{
    internal class Program
    {
        static void Main()
        {
            List<int> largestNumbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                OrderByDescending(n => n).
                Take(3).
                ToList();

            Console.WriteLine(string.Join(' ', largestNumbers));
        }
    }
}
