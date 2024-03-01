using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] pond = new char[size, size];
            int beaverRow = -1, beaverCol = -1, branchCount = 0;

            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = currentRow[col];

                    if (currentRow[col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    else if (char.IsLower(currentRow[col]))
                    {
                        branchCount++;
                    }
                }
            }

            string command;

            List<char> collectedBranches = new List<char>();

            while ((command = Console.ReadLine()) != "end" && branchCount > 0)
            {
                pond[beaverRow, beaverCol] = '-';

                if (command == "up" && IsValidIndex(pond, beaverRow - 1))
                {
                    beaverRow--;
                }
                else if (command == "down" && IsValidIndex(pond, beaverRow + 1))
                {
                    beaverRow++;
                }
                else if (command == "left" && IsValidIndex(pond, beaverCol - 1))
                {
                    beaverCol--;
                }
                else if (command == "right" && IsValidIndex(pond, beaverCol + 1))
                {
                    beaverCol++;
                }
                else
                {
                    if (collectedBranches.Count > 0)
                    {
                        collectedBranches.RemoveAt(collectedBranches.Count - 1);
                    }

                    continue;
                }

                if (char.IsLower(pond[beaverRow, beaverCol]))
                {
                    collectedBranches.Add(pond[beaverRow, beaverCol]);
                    branchCount--;
                }
                else if (pond[beaverRow, beaverCol] == 'F')
                {
                    pond[beaverRow, beaverCol] = '-';

                    if (command == "up")
                    {
                        if (beaverRow == 0)
                        {
                            beaverRow = pond.GetLength(0) - 1;
                        }
                        else
                        {
                            beaverRow = 0;
                        }
                    }
                    else if (command == "down")
                    {
                        if (beaverRow == pond.GetLength(0) - 1)
                        {
                            beaverRow = 0;
                        }
                        else
                        {
                            beaverRow = pond.GetLength(0) - 1;
                        }
                    }
                    else if (command == "left")
                    {
                        if (beaverCol == 0)
                        {
                            beaverCol = pond.GetLength(1) - 1;
                        }
                        else
                        {
                            beaverCol = 0;
                        }
                    }
                    else if (command == "right")
                    {
                        if (beaverCol == pond.GetLength(1) - 1)
                        {
                            beaverCol = 0;
                        }
                        else
                        {
                            beaverCol = pond.GetLength(1) - 1;
                        }
                    }

                    if (char.IsLower(pond[beaverRow, beaverCol]))
                    {
                        collectedBranches.Add(pond[beaverRow, beaverCol]);
                        branchCount--;
                    }

                }
            }

            pond[beaverRow, beaverCol] = 'B';

            Console.WriteLine(branchCount == 0 ? $"The Beaver successfully collect {collectedBranches.Count} wood branches: {string.Join(", ", collectedBranches)}."
                : $"The Beaver failed to collect every wood branch. There are {branchCount} branches left.");
            PrintPond(pond);
        }

        private static bool IsValidIndex(char[,] pond, int index)
        {
            return index >= 0 && index < pond.GetLength(0);
        }

        private static void PrintPond(char[,] pond)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write(pond[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
