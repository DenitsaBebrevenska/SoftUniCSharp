namespace RecursiveFactorial
{
    internal class Program
    {
        static void Main()
        {
            //Create a program that finds the factorial of a given number. Use recursion.
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateFactorial(number));
        }

        private static long CalculateFactorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * CalculateFactorial(--number);
        }
    }
}
