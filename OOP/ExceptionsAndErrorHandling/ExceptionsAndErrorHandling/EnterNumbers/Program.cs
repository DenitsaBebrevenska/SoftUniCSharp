namespace EnterNumbers
{
    internal class Program
    {
        static void Main()
        {
            Stack<int> numbers = new();
            int start = 1;

            while (numbers.Count < 10)
            {
                try
                {
                    numbers.Push(ReadNumber(start, 100));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                if (numbers.Count > 0)
                {
                    start = numbers.Peek();
                }
            }

            Console.WriteLine(string.Join(", ", numbers.Reverse().ToList()));
        }

        private static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number <= start || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }

            return number;
        }

    }
}
