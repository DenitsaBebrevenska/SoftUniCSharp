using System;
using System.Linq;

namespace TruffleHunter
{
    internal class Program
    {
        static void Main()
        {
            char[,] field = GetField();
            int blackTruffles = 0, summerTruffles = 0, whiteTruffles = 0, boardEatenTruffles = 0;

            string input;

            while (!(input = Console.ReadLine()).Contains("Stop"))
            {
                string[] commandTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandTokens[0];
                int row = int.Parse(commandTokens[1]);
                int col = int.Parse(commandTokens[2]);

                if (command == "Collect" && AreValidCoordinates(row, col, field))
                {
                    if (field[row, col] == 'B')
                    {
                        blackTruffles++;
                    }
                    else if (field[row, col] == 'S')
                    {
                        summerTruffles++;
                    }
                    else if (field[row, col] == 'W')
                    {
                        whiteTruffles++;
                    }

                    field[row, col] = '-';
                }
                else //Wild_Boar
                {
                    string direction = commandTokens[3];

                    switch (direction)
                    {
                        case "up":
                            for (int i = row; i >= 0; i -= 2)
                            {
                                if (field[i, col] != '-')
                                {
                                    boardEatenTruffles++;
                                    field[i, col] = '-';
                                }
                            }
                            break;
                        case "down":
                            for (int i = row; i < field.GetLength(0); i += 2)
                            {
                                if (field[i, col] != '-')
                                {
                                    boardEatenTruffles++;
                                    field[i, col] = '-';
                                }
                            }
                            break;
                        case "left":
                            for (int i = col; i >= 0; i -= 2)
                            {
                                if (field[row, i] != '-')
                                {
                                    boardEatenTruffles++;
                                    field[row, i] = '-';
                                }
                            }
                            break;
                        case "right":
                            for (int i = col; i < field.GetLength(1); i += 2)
                            {
                                if (field[row, i] != '-')
                                {
                                    boardEatenTruffles++;
                                    field[row, i] = '-';
                                }
                            }
                            break;
                    }
                }
            }
            Console.WriteLine($"Peter manages to harvest {blackTruffles} black, " +
                              $"{summerTruffles} summer, and {whiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boardEatenTruffles} truffles.");
            PrintField(field);
        }
        private static char[,] GetField()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currentRow[col];
                }
            }
            return field;
        }

        private static bool AreValidCoordinates(int row, int col, char[,] field)
        {
            return row >= 0 && row < field.GetLength(0) &&
                   col >= 0 && col < field.GetLength(1);
        }

        private static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
