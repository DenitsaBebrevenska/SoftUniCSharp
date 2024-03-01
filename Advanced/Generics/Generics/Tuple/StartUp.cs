namespace Tuple
{
    public class StartUp
    {
        static void Main()
        {
            string[] line1Args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, string> line1Tuple = new Tuple<string, string>(line1Args[0] + " " + line1Args[1] , line1Args[2]);
            Console.WriteLine(line1Tuple);
            string[] line2Args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, int> line2Tuple = new Tuple<string, int>(line2Args[0], int.Parse(line2Args[1]));
            Console.WriteLine(line2Tuple);
            string[] line3Args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<int, double> line3Tuple = new Tuple<int, double>(int.Parse(line3Args[0]), double.Parse(line3Args[1]));
            Console.WriteLine(line3Tuple);
        }
    }
}
