namespace JaggedArrayModification
{
    internal class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedMatrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedMatrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split();
                string action = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (AreValidCoordinates(row, col, jaggedMatrix))
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
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

            }

            foreach (int[] row in jaggedMatrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        static bool AreValidCoordinates(int row, int col, int[][] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0))
            {
                if (col >= 0 && col < matrix[row].Length)
                {
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}
