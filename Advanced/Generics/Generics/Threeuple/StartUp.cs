namespace Threeuple
{
    internal class StartUp
    {
        static void Main()
        {
            string[] line1Args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, string, string> line1Threeuple
                = new(line1Args[0] + " " + line1Args[1], line1Args[2], string.Join(' ', line1Args.Skip(3)));
            Console.WriteLine(line1Threeuple);
            string[] line2Args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, int, bool> line2Threeuple
                = new(line2Args[0], int.Parse(line2Args[1]), line2Args[2] == "drunk");
            Console.WriteLine(line2Threeuple);
            string[] line3Args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, double, string> line3Threeuple
                = new(line3Args[0], double.Parse(line3Args[1]), line3Args[2]);
            Console.WriteLine(line3Threeuple);
        }
    }
}
