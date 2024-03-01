namespace PlayCatch
{
    internal class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            int exceptionCount = 0;

            while (true)
            {
                if (exceptionCount == 3)
                {
                    break;
                }

                string[] commandTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandTokens[0];

                try
                {
                    int firstValue = int.Parse(commandTokens[1]);

                    switch (command)
                    {
                        case "Replace":
                            int element = int.Parse(commandTokens[2]);
                            numbers[firstValue] = element;
                            break;
                        case "Print":
                            int end = int.Parse(commandTokens[2]);
                            List<int> selectedNumbers = new();

                            for (int i = firstValue; i <= end; i++)
                            {
                                selectedNumbers.Add(numbers[i]);
                            }

                            Console.WriteLine(string.Join(", ", selectedNumbers));
                            break;
                        case "Show":
                            Console.WriteLine(numbers[firstValue]);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionCount++;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionCount++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
