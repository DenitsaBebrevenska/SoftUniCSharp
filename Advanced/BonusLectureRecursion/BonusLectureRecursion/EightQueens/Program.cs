namespace EightQueens
{
    internal class Program
    {
        static void Main()
        {
            int queens = int.Parse(Console.ReadLine());
            int[,] matrix = new int[queens, queens];
            Console.WriteLine(GetQueens(matrix, 0));
        }

        private static int GetQueens(int[,] matrix, int row)
        {
            if (row == matrix.GetLength(0))
            {
                Print(matrix);
                return 1;
            }

            int foundQueens = 0;

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (IsValidMove(matrix, row, col))
                {
                    matrix[row, col] = 1;
                    foundQueens += GetQueens(matrix, row + 1);
                    matrix[row, col] = 0;
                }
            }
            return foundQueens;
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        Console.Write("Q ");
                    }
                    else
                    {
                        Console.Write("* ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static bool IsValidMove(int[,] matrix, int row, int col)
        {
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (row - i >= 0 && matrix[row - i, col] == 1)
                {
                    return false;
                }

                if (col - i >= 0 && matrix[row, col - i] == 1)
                {
                    return false;
                }

                if (row + i < matrix.GetLength(0) && matrix[row + i, col] == 1)
                {
                    return false;
                }

                if (col + i < matrix.GetLength(0) && matrix[row, col + i] == 1)
                {
                    return false;
                }

                if (col - i >= 0
                    && row + i < matrix.GetLength(0)
                    && matrix[row + i, col - i] == 1)
                {
                    return false;
                }

                if (col - i >= 0
                    && row - i >= 0
                    && matrix[row - i, col - i] == 1)
                {
                    return false;
                }

                if (col + i < matrix.GetLength(0) && row - i >= 0
                    && matrix[row - i, col + i] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
