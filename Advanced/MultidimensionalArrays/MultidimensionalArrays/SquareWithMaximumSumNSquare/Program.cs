namespace SquareWithMaximumSumNSquare
{
    internal class Program
    {
        static void Main()
        {
            //Create a program that reads a matrix from the console.
            //Then find the biggest sum of the n x n submatrix and print it to the console.
            
            int n = int.Parse(Console.ReadLine());
            int[] matrixArgs = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixArgs[0];
            int cols = matrixArgs[1];
            int[,] matrix = new int[rows, cols];

            if (n > cols || n > rows)
            {
                Console.WriteLine("Cannot find the maximum sum subsquare.");
                Console.WriteLine("The subsquare size is bigger than the matrix.");
                return;
            }

            PopulateMatrix(rows, cols, matrix);

            int maxSum = int.MinValue;
            int indexRow = -1;
            int indexCol = -1;

            for (int i = 0; i <= rows - n; i++)
            {
                for (int j = 0; j <= cols - n; j++)
                {
                    int sum = 0;

                    for (int k = 0; k < n; k++)
                    {
                        for (int l = 0; l < n; l++)
                        {
                            sum += matrix[i + k, j + l];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        indexRow = i;
                        indexCol = j;
                    }
                }
            }
            Console.WriteLine($"Max sum: {maxSum}");
            PrintMaxSumSubsquare(n, indexRow, indexCol, matrix);
        }

        static void PopulateMatrix(int rows, int cols, int[,]matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
        }

        static void PrintMaxSumSubsquare(int n, int indexRow, int indexCol, int[,] matrix)
        {
            for (int i = indexRow; i < indexRow + n; i++)
            {
                for (int j = indexCol; j < indexCol
                     + n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
