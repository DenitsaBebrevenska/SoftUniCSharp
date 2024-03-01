namespace SumMatrixElements
{
    internal class Program
    {
        static void Main()
        {
            int[] matrixArgs = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixArgs[0];
            int cols = matrixArgs[1];

            int[,] matrix = new int[rows, cols];
            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i,j] = currentRow[j];
                    sum += currentRow[j];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
