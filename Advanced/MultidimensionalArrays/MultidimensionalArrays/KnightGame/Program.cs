namespace KnightGame
{
    internal class Program
    {
        static void Main()
        {
            int rowsAndCols = int.Parse(Console.ReadLine());
            char[,] board = new char[rowsAndCols, rowsAndCols];
            PopulateBoard(rowsAndCols, board);
            int removedKnights = 0;
            
            while (true)
            {
                int maxCountConflicts = 0;
                int indexRowMostConflict = -1;
                int indexColMostConflict = -1;

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] != 'K')
                        {
                            continue;
                        }

                        List<int[]> coordinates = new List<int[]>()
                        {
                            new int[] { i - 2, j - 1 },
                            new int[] { i - 2, j + 1 },
                            new int[] { i - 1, j - 2 },
                            new int[] { i - 1, j + 2 },
                            new int[] { i + 1, j - 2 },
                            new int[] { i + 1, j + 2 },
                            new int[] { i + 2, j - 1 },
                            new int[] { i + 2, j + 1 }
                        };

                        int currentConflictCount = 0;

                        for (int k = 0; k < coordinates.Count; k++)
                        {
                            if (IsValidCoordinate(coordinates[k], board))
                            {
                                if (board[coordinates[k][0], coordinates[k][1]] == 'K')
                                {
                                    currentConflictCount++;
                                }
                            }
                        }

                        if (currentConflictCount > maxCountConflicts)
                        {
                            maxCountConflicts = currentConflictCount;
                            indexRowMostConflict = i;
                            indexColMostConflict = j;
                        }
                    }
                }

                if (maxCountConflicts == 0)
                {
                    break;
                }

                board[indexRowMostConflict, indexColMostConflict] = '0';
                removedKnights++;
            }

            Console.WriteLine(removedKnights);
        }

        static bool IsValidCoordinate(int[] coordinates, char[,] board)
        {
            int row = coordinates[0];
            int col = coordinates[1];

            return row >= 0 && row < board.GetLength(0)
                && col >= 0 && col < board.GetLength(1);
        }

        static void PopulateBoard(int rowsAndCols, char[,] board)
        {
            for (int i = 0; i < rowsAndCols; i++)
            {
                string currentRow = Console.ReadLine();

                for (int j = 0; j < rowsAndCols; j++)
                {
                    board[i, j] = currentRow[j];
                }
            }

        }

    }
}
