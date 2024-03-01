namespace DeliveryBoy
{
    internal class Program
    {
        static void Main()
        {
            char[,] map = ReadMatrix();
            int[] startingPosition = GetStartingPosition(map);
            int[] currentPosition = { startingPosition[0], startingPosition[1] };
            int[] nextPosition = { 0, 0 };

            while (true)
            {
                string command = Console.ReadLine();
                nextPosition = GetNewPosition(command, currentPosition);

                if (!IsOnMap(nextPosition, map))
                {
                    map[startingPosition[0], startingPosition[1]] = ' ';
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    break;
                }

                if (map[nextPosition[0], nextPosition[1]] == 'A')
                {
                    map[nextPosition[0], nextPosition[1]] = 'P';
                    map[startingPosition[0], startingPosition[1]] = 'B';
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }

                if (map[nextPosition[0], nextPosition[1]] == 'P')
                {
                    currentPosition[0] = nextPosition[0];
                    currentPosition[1] = nextPosition[1];
                    map[currentPosition[0], currentPosition[1]] = 'R';
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                    continue;
                }

                if (map[nextPosition[0], nextPosition[1]] == '*')
                {
                    nextPosition[0] = currentPosition[0];
                    nextPosition[1] = currentPosition[1];
                    continue;
                }

                currentPosition[0] = nextPosition[0];
                currentPosition[1] = nextPosition[1];
                map[currentPosition[0], currentPosition[1]] = '.';
            }

            PrintMap(map);
        }

        static char[,] ReadMatrix()
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] map = new char[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < map.GetLength(0); row++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < map.GetLength(1); col++)
                {
                    map[row, col] = line[col];

                }
            }

            return map;
        }

        static int[] GetStartingPosition(char[,] map)
        {
            int[] startingPosition = new[] { -1, -1 };

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (map[row, col] == 'B')
                    {
                        startingPosition[0] = row;
                        startingPosition[1] = col;
                    }
                }
            }
            return startingPosition;
        }

        static int[] GetNewPosition(string command, int[] currentPosition)
        {
            int nextRow = currentPosition[0];
            int nextCol = currentPosition[1];

            if (command == "up")
            {
                nextRow--;
            }
            else if (command == "down")
            {
                nextRow++;
            }
            else if (command == "left")
            {
                nextCol--;
            }
            else //right
            {
                nextCol++;
            }

            return new[] { nextRow, nextCol };
        }

        static bool IsOnMap(int[] nextPosition, char[,] map)
        {
            return nextPosition[0] >= 0 && nextPosition[0] < map.GetLength(0) && nextPosition[1] >= 0 && nextPosition[1] < map.GetLength(1);
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
