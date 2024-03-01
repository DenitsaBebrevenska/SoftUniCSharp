namespace ActionPrint
{
    internal class Program
    {
        static void Main()
        {
            //Create a program that reads a collection of strings from the console and then prints them onto the console. Each name should be printed on a new line. Use Action<T>.

            List<string> words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> print = word => Console.WriteLine(word);
            words.ForEach(print);

            //or
            //Action<List<string>> print = words =>
            //Console.WriteLine(string.Join(Environment.NewLine, words));
            //print(words);

        }
    }
}
