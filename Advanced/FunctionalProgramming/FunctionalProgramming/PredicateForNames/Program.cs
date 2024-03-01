namespace PredicateForNames
{
    internal class Program
    {
        static void Main()
        {
            //Write a program that filters a list of names according to their length. On the first line, you will be given an integer n, representing a name's length. On the second line, you will be given some names as strings separated by space. Write a function that prints only the names whose length is less than or equal to n.

            int filterLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //names = names.Where(name => name.Length <= filterLength).ToArray();
            //Console.WriteLine(string.Join(Environment.NewLine, names));
            
            //or implementing my own Func
            Action<string[], int> printFilteredNames = (nameList, filterNumber) =>
            {
                foreach (string name in nameList)
                {
                    if (name.Length <= filterNumber)
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            printFilteredNames(names, filterLength);
        }
    }
}
