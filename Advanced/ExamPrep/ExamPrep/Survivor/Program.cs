using System;
using System.Linq;

namespace Survivor
{
    internal class Program
    {
        static void Main()
        {
            int rowCount = int.Parse(Console.ReadLine());
            char[][] beach = new char[rowCount][];

            for (int row = 0; row < rowCount; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                beach[row] = currentRow;
            }

            int playerTokens = 0;
            int opponentTokens = 0;

            string command;

            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] commandTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commandTokens[0];
                int row = int.Parse(commandTokens[1]);
                int col = int.Parse(commandTokens[2]);

                if (action == "Find")
                {
                    playerTokens = CollectToken(beach, row, col, playerTokens);
                }
                else if (action == "Opponent")
                {
                    string direction = commandTokens[3];

                    opponentTokens = CollectToken(beach, row, col, opponentTokens);

                    if (AreValidCoordinates(beach, row, col))
                    {
                        int nextRow = row;
                        int nextCol = col;

                        for (int i = 0; i < 3; i++)
                        {
                            switch (direction)
                            {
                                case "up":
                                    nextRow--;
                                    break;
                                case "down":
                                    nextRow++;
                                    break;
                                case "left":
                                    nextCol--;
                                    break;
                                case "right":
                                    nextCol++;
                                    break;
                            }

                            opponentTokens = CollectToken(beach, nextRow, nextCol, opponentTokens);
                        }
                    }
                }
            }
            PrintBeach(beach);
            Console.WriteLine($"Collected tokens: {playerTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static bool AreValidCoordinates(char[][] beach, int row, int col)
        {
            return row >= 0 && row < beach.Length
                            && col >= 0 && col < beach[row].Length;
        }

        private static int CollectToken(char[][] beach, int row, int col, int tokens)
        {
            if (AreValidCoordinates(beach, row, col))
            {
                if (beach[row][col] == 'T')
                {
                    beach[row][col] = '-';
                    tokens++;
                }
            }

            return tokens;
        }

        private static void PrintBeach(char[][] beach)
        {
            for (int row = 0; row < beach.Length; row++)
            {
                for (int col = 0; col < beach[row].Length; col++)
                {
                    Console.Write(beach[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
