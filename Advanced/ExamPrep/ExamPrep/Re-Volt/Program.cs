using System;

namespace Re_Volt
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int commandCount = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            int[] playerPosition = new int[] { -1, -1 };
            bool winAchieved = false;

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = currentRow[col];

                    if (currentRow[col] == 'f')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
                }
            }

            for (int i = 0; i < commandCount; i++) // no possibility of having two traps or bonuses in a row?
            {
                if (field[playerPosition[0], playerPosition[1]] != 'B'
                    || field[playerPosition[0], playerPosition[1]] != 'T')
                {
                    field[playerPosition[0], playerPosition[1]] = '-';
                }
                string direction = Console.ReadLine();
                playerPosition = GetNewCoordinates(field, playerPosition, direction);

                if (field[playerPosition[0], playerPosition[1]] == 'F')
                {
                    winAchieved = true;
                    break;
                }

                if (field[playerPosition[0], playerPosition[1]] == 'T')
                {
                    playerPosition = GetNewCoordinates(field, playerPosition, GetReverseDirection(direction));
                }
                else if (field[playerPosition[0], playerPosition[1]] == 'B')
                {
                    playerPosition = GetNewCoordinates(field, playerPosition, direction);

                    if (field[playerPosition[0], playerPosition[1]] == 'F') //possible that a bonus step will lead to the finish line
                    {
                        winAchieved = true;
                        break;
                    }
                }
            }

            field[playerPosition[0], playerPosition[1]] = 'f';
            Console.WriteLine(winAchieved ? "Player won!" : "Player lost!");
            PrintField(field);
        }

        private static bool IsValidRowOrCol(char[,] field, int index)
        {
            return index >= 0 && index < field.GetLength(0);
        }

        private static int[] GetNewCoordinates(char[,] field, int[] position, string direction)
        {
            int nextRow = position[0];
            int nextCol = position[1];

            if (direction == "up")
            {
                nextRow--;

                if (!IsValidRowOrCol(field, nextRow))
                {
                    nextRow = field.GetLength(0) - 1;
                }
            }
            else if (direction == "down")
            {
                nextRow++;

                if (!IsValidRowOrCol(field, nextRow))
                {
                    nextRow = 0;
                }
            }
            else if (direction == "left")
            {
                nextCol--;

                if (!IsValidRowOrCol(field, nextCol))
                {
                    nextCol = field.GetLength(1) - 1;
                }
            }
            else if (direction == "right")
            {
                nextCol++;

                if (!IsValidRowOrCol(field, nextCol))
                {
                    nextCol = 0;
                }
            }

            return new[] { nextRow, nextCol };
        }

        private static string GetReverseDirection(string direction)
        {
            switch (direction)
            {
                case "up":
                    return "down";
                case "down":
                    return "up";
                case "left":
                    return "right";
                case "right":
                    return "left";
            }

            return default;
        }

        private static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
