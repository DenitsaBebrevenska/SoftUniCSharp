using System;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] wall = new char[size, size];
            int[] currentLocation = { -1, -1 };

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    wall[row, col] = currentRow[col];

                    if (currentRow[col] == 'V')
                    {
                        currentLocation[0] = row;
                        currentLocation[1] = col;
                    }
                }
            }

            string command;
            int[] nextPosition = { currentLocation[0], currentLocation[1] };
            int holesMade = 1, rodsHit = 0;
            bool electrocuted = false;

            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "up":
                        nextPosition[0]--;
                        break;
                    case "down":
                        nextPosition[0]++;
                        break;
                    case "left":
                        nextPosition[1]--;
                        break;
                    case "right":
                        nextPosition[1]++;
                        break;
                }

                if (!MoveIsOnTheWall(wall, nextPosition))
                {
                    nextPosition = new int[] { currentLocation[0], currentLocation[1] };
                    continue;
                }

                if (wall[nextPosition[0], nextPosition[1]] == 'R')
                {
                    rodsHit++;
                    Console.WriteLine("Vanko hit a rod!");
                    nextPosition = new int[] { currentLocation[0], currentLocation[1] };
                    continue;
                }

                wall[currentLocation[0], currentLocation[1]] = '*';
                currentLocation = new int[] { nextPosition[0], nextPosition[1] };

                if (wall[currentLocation[0], currentLocation[1]] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{nextPosition[0]}, {nextPosition[1]}]!");
                }
                else if (wall[currentLocation[0], currentLocation[1]] == '-')
                {
                    holesMade++;
                }
                else //electocution
                {
                    holesMade++;
                    electrocuted = true;
                    wall[currentLocation[0], currentLocation[1]] = 'E';
                    break;
                }
            }

            Console.WriteLine(electrocuted ? $"Vanko got electrocuted, but he managed to make {holesMade} hole(s)."
                : $"Vanko managed to make {holesMade} hole(s) and he hit only {rodsHit} rod(s).");

            if (!electrocuted)
            {
                wall[currentLocation[0], currentLocation[1]] = 'V';
            }

            PrintWall(wall);
        }

        private static bool MoveIsOnTheWall(char[,] wall, int[] nextPosition)
        {
            return nextPosition[0] >= 0 && nextPosition[0] < wall.GetLength(0) &&
                   nextPosition[1] >= 0 && nextPosition[1] < wall.GetLength(1);
        }

        private static void PrintWall(char[,] wall)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write(wall[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
