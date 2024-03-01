namespace MatrixShuffling
{
    internal class Program
    {
        static void Main()
        {
            int[] matrixArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixArgs[0];
            int cols = matrixArgs[1];
            string[,] matrix = new string[rows, cols];
            PopulateMatrix(rows, cols, matrix);

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!IsValidInput(commandArgs, matrix))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(commandArgs[1]);
                int col1 = int.Parse(commandArgs[2]);
                int row2 = int.Parse(commandArgs[3]);
                int col2 = int.Parse(commandArgs[4]);

                (matrix[row1, col1], matrix[row2, col2]) = (matrix[row2, col2], matrix[row1, col1]);
                PrintMatrix(matrix);
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void PopulateMatrix(int rows, int cols, string[,] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                string[] currentRow = Console.ReadLine().Split();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
        }

        private static bool IsValidInput(string[] commandArgs, string[,] matrix)
        {
            if (commandArgs[0] != "swap" || commandArgs.Length != 5)
            {
                return false;
            }

            int row1 = int.Parse(commandArgs[1]);
            int col1 = int.Parse(commandArgs[2]);
            int row2 = int.Parse(commandArgs[3]);
            int col2 = int.Parse(commandArgs[4]);

            return row1 >= 0 && row1 < matrix.GetLength(0) &&
                   row2 >= 0 && row2 < matrix.GetLength(0) &&
                   col1 >= 0 && col1 < matrix.GetLength(1) &&
                   col2 >= 0 && col2 < matrix.GetLength(1);

        }

    }
}
