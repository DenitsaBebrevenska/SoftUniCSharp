namespace SquareWithMaximumSum
{
    internal class Program
    {
        static void Main()
        {
            int[] matrixArgs = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixArgs[0];
            int cols = matrixArgs[1];
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int maxSumSubSquare = int.MinValue;
            int indexRow = -1, indexCol = -1;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {

                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (currentSum > maxSumSubSquare)
                    {
                        maxSumSubSquare = currentSum;
                        indexRow = i;
                        indexCol = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[indexRow, indexCol]} {matrix[indexRow, indexCol + 1]}");
            Console.WriteLine($"{matrix[indexRow + 1, indexCol]} {matrix[indexRow + 1, indexCol + 1]}");
            Console.WriteLine(maxSumSubSquare);
        }
    }
}
