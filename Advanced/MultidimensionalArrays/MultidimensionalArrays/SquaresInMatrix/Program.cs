namespace SquaresInMatrix
{
    internal class Program
    {
        static void Main()
        {
            int[] matrixArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixArgs[0];
            int cols = matrixArgs[1];
            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] currentRow = Console.ReadLine().Split(); //Split options?

                for (int j = 0; j < cols; j++)
                {
                    matrix[i,j] = currentRow[j];
                }
            }

            int numberOfSquares = 0;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    string currentString = matrix[i, j];

                    if (Equals(currentString, matrix[i, j + 1]) 
                        && Equals(currentString, matrix[i + 1,j])
                        && Equals(currentString, matrix[i +1, j + 1]))
                    {
                        numberOfSquares++;
                    }
                }
            }

            Console.WriteLine(numberOfSquares);
        }
    }
}
