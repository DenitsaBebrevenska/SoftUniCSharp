using System;

namespace Armory
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] armory = new char[size, size];
            int officerRow = -1, officerCol = -1, firstMirrorRow = -1, firstMirrorCol = -1, secondMirrorRow = -1, secondMirrorCol = -1;
            bool firstMirrorFound = false;

            for (int row = 0; row < armory.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    armory[row, col] = currentRow[col];

                    if (currentRow[col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                    else if (currentRow[col] == 'M')
                    {
                        if (!firstMirrorFound)
                        {
                            firstMirrorRow = row;
                            firstMirrorCol = col;
                            firstMirrorFound = true;
                        }
                        else
                        {
                            secondMirrorRow = row;
                            secondMirrorCol = col;
                        }
                    }
                }
            }

            int goldSpent = 0;
            bool officerLeft = false;

            while (goldSpent < 65 && !officerLeft)
            {
                armory[officerRow, officerCol] = '-';
                string direction = Console.ReadLine();
                int nextRow = officerRow, nextCol = officerCol;

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

                if (!IsInsideTheArmory(armory, nextRow, nextCol))
                {
                    officerLeft = true;
                    break;
                }

                officerRow = nextRow;
                officerCol = nextCol;

                if (char.IsDigit(armory[officerRow, officerCol]))
                {
                    goldSpent += int.Parse(armory[officerRow, officerCol].ToString());
                }
                else if (armory[officerRow, officerCol] == 'M')
                {
                    armory[officerRow, officerCol] = '-';

                    if (officerRow == firstMirrorRow && officerCol == firstMirrorCol)
                    {
                        officerRow = secondMirrorRow;
                        officerCol = secondMirrorCol;
                    }
                    else
                    {
                        officerRow = firstMirrorRow;
                        officerCol = firstMirrorCol;
                    }
                }
            }

            if (!officerLeft)
            {
                armory[officerRow, officerCol] = 'A';
            }

            Console.WriteLine(officerLeft ? "I do not need more swords!" : "Very nice swords, I will come back for more!");
            Console.WriteLine($"The king paid {goldSpent} gold coins.");
            PrintArmory(armory);
        }

        private static bool IsInsideTheArmory(char[,] armory, int row, int col)
        {
            return row >= 0 && row < armory.GetLength(0)
                && col >= 0 && col < armory.GetLength(1);
        }

        private static void PrintArmory(char[,] armory)
        {
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    Console.Write(armory[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
