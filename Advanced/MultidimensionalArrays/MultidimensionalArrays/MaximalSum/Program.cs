namespace MaximalSum
{
    internal class Program
    {
        static void Main()
        {
            int[] matrixArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixArgs[0];
            int cols = matrixArgs[1];
            int[,] matrix = new int[rows, cols];
            PopulateMatrix(rows, cols, matrix);

            int maxSum = int.MinValue;
            int indexRow = -1;
            int indexCol = -1;

            for (int i = 0; i <= rows - 3; i++)
            {
                for (int j = 0; j <= cols - 3; j++) //3 x 3 subsquare
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                       + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                       + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        indexRow = i;
                        indexCol = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            PrintMaxSumSubsquare(indexRow, indexCol, matrix);

        }

        static void PrintMaxSumSubsquare(int indexRow, int indexCol, int[,] matrix)
        {
            for (int i = indexRow; i < indexRow + 3; i++)
            {
                for (int j = indexCol; j < indexCol + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static void PopulateMatrix(int rows, int cols, int[,] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
        }
    }
}
