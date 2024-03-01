namespace SnakeMoves
{
    internal class Program
    {
        static void Main()
        {
            int[] matrixArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixArgs[0];
            int cols = matrixArgs[1];
            string snake = Console.ReadLine();
            char[,] matrix = new char[rows, cols];

            PopulateMatrix(matrix, snake);
            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        static void PopulateMatrix(char[,] matrix, string snake)
        {
            int indexSnake = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (indexSnake == snake.Length)
                        {
                            indexSnake = 0;
                        }

                        matrix[i, j] = snake[indexSnake];
                        indexSnake++;
                    }
                    continue;
                }

                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    if (indexSnake == snake.Length)
                    {
                        indexSnake = 0;
                    }

                    matrix[i, j] = snake[indexSnake];
                    indexSnake++;
                }
            }
        }
    }
}
