using System.Data;

namespace DiagonalDifference
{
    internal class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, rows];
            PopulateMatrix(rows, matrix);
            Console.WriteLine(GetDifferenceBetweenDiagonals(matrix, rows));
        }

        static void PopulateMatrix(int rows, int[,] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < rows; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
        }

        static int GetPrimaryDiagonalSum(int[,] matrix)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }

        static int GetSecondaryDiagonalSum(int[,] matrix, int rows)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, rows - 1 - i];
            }

            return sum;
        }

        static int GetDifferenceBetweenDiagonals(int[,] matrix, int rows)
        {
            int sum1 = GetPrimaryDiagonalSum(matrix);
            int sum2 = GetSecondaryDiagonalSum(matrix,rows);
            return Math.Abs(sum1 - sum2);
        }
    }
}
