namespace PascalTriangle
{
    internal class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[rows][];
            pascalTriangle[0] = new long[] { 1 };

            for (int i = 1; i < rows; i++)
            {
                pascalTriangle[i] = new long[i + 1];
                pascalTriangle[i][0] = pascalTriangle[i - 1][0];
                pascalTriangle[i][^1] = pascalTriangle[i - 1][^1];

                for (int j = 1; j < pascalTriangle[i].Length - 1; j++)
                {
                    long number1 = pascalTriangle[i - 1][j - 1];
                    long number2 = pascalTriangle[i - 1][j];
                    pascalTriangle[i][j] = number1 + number2;
                }
            }

            foreach (long[] row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
