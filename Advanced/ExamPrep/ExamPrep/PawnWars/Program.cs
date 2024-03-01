using System;

namespace PawnWars
{
    internal class Program
    {
        private const int BoardSize = 8;
        private static char[,] board = new char[BoardSize, BoardSize];
        static void Main()
        {
            int[] whitePawnPosition = new[] { -1, -1 };
            char whitePawnCol = '0';
            int[] blackPawnPosition = new[] { -1, -1 };
            char blackPawnCol = '0';

            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = currentRow[col];

                    if (currentRow[col] == 'w')
                    {
                        whitePawnPosition[0] = row;
                        whitePawnPosition[1] = col;
                        whitePawnCol = (char)(97 + col);
                    }
                    else if (currentRow[col] == 'b')
                    {
                        blackPawnPosition[0] = row;
                        blackPawnPosition[1] = col;
                        blackPawnCol = (char)(97 + col);
                    }
                }
            }

            int colDifference = Math.Abs(whitePawnPosition[1] - blackPawnPosition[1]);
            bool pawnCanIntersect = colDifference == 1;

            while (true)
            {
                if (pawnCanIntersect)
                {
                    if (WhiteCanCapture(whitePawnPosition[0], whitePawnPosition[1]))
                    {
                        Console.WriteLine($"Game over! White capture on {blackPawnCol}{8 - blackPawnPosition[0]}.");
                        break;
                    }
                }

                board[whitePawnPosition[0], whitePawnPosition[1]] = '-';
                whitePawnPosition[0]--;
                board[whitePawnPosition[0], whitePawnPosition[1]] = 'w';

                if (WhitePawnPromotion(whitePawnPosition[0]))
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {whitePawnCol}8.");
                    break;
                }

                if (pawnCanIntersect)
                {
                    if (BlackCanCapture(blackPawnPosition[0], blackPawnPosition[1]))
                    {
                        Console.WriteLine($"Game over! Black capture on {whitePawnCol}{8 - whitePawnPosition[0]}.");
                        break;
                    }
                }

                board[blackPawnPosition[0], blackPawnPosition[1]] = '-';
                blackPawnPosition[0]++;
                board[blackPawnPosition[0], blackPawnPosition[1]] = 'b';

                if (BlackPawnPromotion(blackPawnPosition[0]))
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {blackPawnCol}1.");
                    break;
                }
            }
        }

        static bool WhitePawnPromotion(int whitePawnRow)
        {
            return whitePawnRow == 0;
        }
        static bool BlackPawnPromotion(int blackPawnRow)
        {
            return blackPawnRow == board.GetLength(0) - 1;
        }

        static bool WhiteCanCapture(int pawnRow, int pawnCol)
        {
            if (AreValidCoordinates(pawnRow - 1, pawnCol - 1))
            {
                if (board[pawnRow - 1, pawnCol - 1] != '-')
                {
                    return true;
                }
            }

            if (AreValidCoordinates(pawnRow - 1, pawnCol + 1))
            {
                if (board[pawnRow - 1, pawnCol + 1] != '-')
                {
                    return true;
                }
            }

            return false;
        }

        static bool BlackCanCapture(int pawnRow, int pawnCol)
        {
            if (AreValidCoordinates(pawnRow + 1, pawnCol - 1))
            {
                if (board[pawnRow + 1, pawnCol - 1] != '-')
                {
                    return true;
                }
            }

            if (AreValidCoordinates(pawnRow + 1, pawnCol + 1))
            {
                if (board[pawnRow + 1, pawnCol + 1] != '-')
                {
                    return true;
                }
            }

            return false;
        }

        static bool AreValidCoordinates(int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) &&
                   col >= 0 && col < board.GetLength(1);
        }
    }
}
