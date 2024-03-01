namespace TriFunction
{
    internal class Program
    {
        static void Main()
        {
            //Create a program that traverses a collection of names and returns the first name, whose sum of characters is equal to or larger than a given number N, which will be given on the first line. Use a function that accepts another function as one of its parameters. Start by building a regular function to hold the basic logic of the program. Something along the lines of Func<string, int, bool>. Afterward, create your main function which should accept the first function as one of its parameters

            int minimumSum = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> reachesMinimumSum = name =>
            {
                int sum = 0;

                foreach (char character in name)
                {
                    sum += character;
                }

                return sum >= minimumSum;
            };

            Func<List<string>, Predicate<string>, string> firstNameThatSatisfiesCondition =
                (list, predicateName) =>
                {
                    foreach (string name in list)
                    {
                        if (predicateName(name))
                        {
                            return name;
                        }
                    }
                    return string.Empty;
                };

            Console.WriteLine(firstNameThatSatisfiesCondition(names, reachesMinimumSum));

        }
    }
}
