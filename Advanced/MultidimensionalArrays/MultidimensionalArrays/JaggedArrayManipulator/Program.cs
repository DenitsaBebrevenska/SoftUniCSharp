namespace JaggedArrayManipulator
{
    internal class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedMatrix = new double[rows][];
            PopulateMatrix(rows, jaggedMatrix);
            AnalyzeMatrix(jaggedMatrix);
            ManipulateMatrix(jaggedMatrix);
            PrintMatrix(jaggedMatrix);
        }

        static void PrintMatrix(double[][] jaggedMatrix)
        {
            foreach (double[] row in jaggedMatrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        static void ManipulateMatrix(double[][] jaggedMatrix)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();
                string action = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (AreValidIndexes(row, col, jaggedMatrix))
                {
                    switch (action)
                    {
                        case "Add":
                            jaggedMatrix[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedMatrix[row][col] -= value;
                            break;
                    }
                }
            }
        }

        static void PopulateMatrix(int rows, double[][] jaggedMatrix)
        {
            for (int i = 0; i < rows; i++)
            {
                jaggedMatrix[i] = Console.ReadLine().Split().Select(double.Parse).ToArray();
            }
        }

        static void AnalyzeMatrix(double[][] jaggedMatrix)
        {
            for (int i = 0; i < jaggedMatrix.Length - 1; i++)
            {
                if (jaggedMatrix[i].Length == jaggedMatrix[i + 1].Length)
                {
                    for (int j = 0; j < jaggedMatrix[i].Length; j++)
                    {
                        jaggedMatrix[i][j] *= 2;
                        jaggedMatrix[i + 1][j] *= 2;
                    }
                    continue;
                }

                for (int j = 0; j < jaggedMatrix[i].Length; j++)
                {
                    jaggedMatrix[i][j] /= 2;
                }

                for (int j = 0; j < jaggedMatrix[i + 1].Length; j++)
                {
                    jaggedMatrix[i + 1][j] /= 2;
                }
            }
        }

        static bool AreValidIndexes(int row, int col, double[][] jaggedMatrix)
        {
            if (row >= 0 && row < jaggedMatrix.Length)
            {
                if (col >= 0 && col < jaggedMatrix[row].Length)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
