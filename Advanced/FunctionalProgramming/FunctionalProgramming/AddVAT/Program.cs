namespace AddVAT
{
    internal class Program
    {
        static void Main()
        {
            Func<double, double> addVat = x => x * 1.2;

            List<double> price = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(addVat)
                .ToList();

                price.ForEach(p => Console.WriteLine($"{p:F2}"));
        }
    }
}
