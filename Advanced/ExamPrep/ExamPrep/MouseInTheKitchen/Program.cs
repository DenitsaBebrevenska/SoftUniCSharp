namespace MouseInTheKitchen
{
    internal class Program
    {
        static void Main()
        {
            char[,] map = ReadMapFromConsole();
            int[] currentPosition = GetStartingPosition(map); //mouse coordinates row, col
            int cheeseCount = GetCheeseCount(map);
            int[] nextPosition = { currentPosition[0], currentPosition[1] };

            while (true)
            {
                string command = Console.ReadLine();

                if (command != "danger")
                {
                    GetNextMoveCoordinates(command, nextPosition);
                }

                if (command == "danger" && cheeseCount > 0)
                {
                    Console.WriteLine("Mouse will come back later!");
                    break;
                }

                map[currentPosition[0], currentPosition[1]] = '*';

                if (!MoveIsOnTheMap(nextPosition, map))
                {
                    Console.WriteLine("No more cheese for tonight!");
                    break;
                }

                if (map[nextPosition[0], nextPosition[1]] == '@')
                {
                    nextPosition[0] = currentPosition[0];
                    nextPosition[1] = currentPosition[1];
                    continue;
                }

                currentPosition[0] = nextPosition[0];
                currentPosition[1] = nextPosition[1];

                if (map[nextPosition[0], nextPosition[1]] == 'C')
                {
                    cheeseCount--;

                    if (cheeseCount == 0)
                    {
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        break;
                    }

                    continue;
                }

                if (map[nextPosition[0], nextPosition[1]] == 'T')
                {
                    Console.WriteLine("Mouse is trapped!");
                    break;
                }

            }

            map[currentPosition[0], currentPosition[1]] = 'M';

            PrintMap(map);
        }

        static char[,] ReadMapFromConsole()
        {
            int[] mapSize = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            char[,] map = new char[mapSize[0], mapSize[1]];

            for (int row = 0; row < map.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < map.GetLength(1); col++)
                {
                    map[row, col] = currentRow[col];
                }
            }
            return map;
        }

        static int[] GetStartingPosition(char[,] map)
        {
            int[] currentPosition = { 0, 0 };

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (map[row, col] == 'M')
                    {
                        currentPosition[0] = row;
                        currentPosition[1] = col;
                    }
                }
            }
            return currentPosition;
        }

        static int GetCheeseCount(char[,] map)
        {
            int cheeseCount = 0;

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (map[row, col] == 'C')
                    {
                        cheeseCount++;
                    }
                }
            }
            return cheeseCount;
        }

        static void GetNextMoveCoordinates(string command, int[] nextPosition)
        {
            if (command == "up")
            {
                nextPosition[0]--;
            }
            else if (command == "down")
            {
                nextPosition[0]++;
            }
            else if (command == "left")
            {
                nextPosition[1]--;
            }
            else if (command == "right")
            {
                nextPosition[1]++;
            }
        }

        static bool MoveIsOnTheMap(int[] coordinates, char[,] map)
        {
            return coordinates[0] >= 0 && coordinates[0] < map.GetLength(0)
                && coordinates[1] >= 0 && coordinates[1] < map.GetLength(1);
        }
        static void PrintMap(char[,] map)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    Console.Write(map[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
