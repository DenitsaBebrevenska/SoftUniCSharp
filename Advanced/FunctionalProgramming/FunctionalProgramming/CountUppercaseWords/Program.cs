namespace CountUppercaseWords
{
    internal class Program
    {
        static void Main()
        {
            //I prefer the lambda instead of defining a predicate although the code can be written in many ways to satisfy the goal
            List<string> words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(s => char.IsUpper(s[0]))
                .ToList();

            words.ForEach(s => Console.WriteLine(s));

            //Predicate<string> firstCharIsUpper = s => char.IsUpper(s[0]);
            //List<string> words = Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Where(w => firstCharIsUpper(w))
            //    .ToList();

            //words.ForEach(w => Console.WriteLine(w));
        }
    }
}
