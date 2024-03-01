namespace Bombs
{
    internal class Program
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            PopulateSquareMatrix(matrix);
            List<int[]> bombCoordinates = GetBombCoordinates();
            HandleExplosions(bombCoordinates, matrix);
            PrintAliveCellsDetails(matrix);
            PrintMatrixFinalState(matrix);
        }

        static void HandleExplosions(List<int[]> bombCoordinates, int[,] matrix)
        {
            for (int i = 0; i < bombCoordinates.Count; i++)
            {
                int row = bombCoordinates[i][0];
                int col = bombCoordinates[i][1];

                if (matrix[row, col] <= 0) //nothing to explode
                {
                    continue;
                }

                HandleAreaOfExplosion(matrix, row, col);
            }
        }

        static void HandleAreaOfExplosion(int[,] matrix, int row, int col)
        {
            int bombPower = matrix[row, col];
            matrix[row, col] = 0;

            List<int[]> areaExplosion = new List<int[]>()
            {
                new int[] {row , col - 1},
                new int[] {row , col + 1},
                new int[] {row - 1 , col},
                new int[] {row + 1 , col},
                new int[] {row - 1 , col - 1},
                new int[] {row - 1 , col + 1},
                new int[] {row + 1 , col - 1},
                new int[] {row + 1 , col + 1}
            };

            for (int j = 0; j < areaExplosion.Count; j++)
            {
                int rowExplosion = areaExplosion[j][0];
                int colExplosion = areaExplosion[j][1];

                if (!AreValidCoordinates(rowExplosion, colExplosion, matrix))
                {
                    continue;
                }

                if (matrix[rowExplosion, colExplosion] <= 0)
                {
                    continue;
                }

                matrix[rowExplosion, colExplosion] -= bombPower;
            }
        }

        static List<int[]> GetBombCoordinates()
        {
            return Console.ReadLine().
                Split().
                Select(x => x.Split(',').
                    Select(int.Parse).
                    ToArray()).
                ToList();
        }

        static void PrintMatrixFinalState(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static int[] GetAliveCellsDetails(int[,] matrix)
        {
            int aliveCellsCount = 0;
            int aliveCellsSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        aliveCellsCount++;
                        aliveCellsSum += matrix[i, j];
                    }
                }
            }

            return new[] { aliveCellsCount, aliveCellsSum };
        }

        static void PrintAliveCellsDetails(int[,] matrix)
        {
            int[] aliveCellsDetails = GetAliveCellsDetails(matrix);
            int cellCount = aliveCellsDetails[0];
            int cellSum = aliveCellsDetails[1];
            Console.WriteLine($"Alive cells: {cellCount}");
            Console.WriteLine($"Sum: {cellSum}");

        }

        static void PopulateSquareMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
        }

        static bool AreValidCoordinates(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}
