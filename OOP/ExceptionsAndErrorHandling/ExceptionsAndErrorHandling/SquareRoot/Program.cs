namespace SquareRoot
{
    internal class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(FindSquareRoot(number));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        private static double FindSquareRoot(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }

            return Math.Sqrt(number);
        }
    }
}
