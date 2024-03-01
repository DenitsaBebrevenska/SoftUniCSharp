namespace TheSquirrel
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            char[,] map = new char[size, size];
            int[] rowColSquirrel = new[] { -1, -1 };

            for (int row = 0; row < map.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < map.GetLength(1); col++)
                {
                    map[row, col] = currentRow[col];

                    if (currentRow[col] == 's')
                    {
                        rowColSquirrel[0] = row;
                        rowColSquirrel[1] = col;
                    }
                }
            }

            int hazelnutCount = 0;

            for (int i = 0; i < directions.Length; i++)
            {
                map[rowColSquirrel[0], rowColSquirrel[1]] = '*';
                GetNewCoordinates(directions[i], rowColSquirrel);

                if (!AreOnTheMap(rowColSquirrel, map))
                {
                    Console.WriteLine("The squirrel is out of the field.");
                    break;
                }

                if (map[rowColSquirrel[0], rowColSquirrel[1]] == 'h')
                {
                    hazelnutCount++;

                    if (hazelnutCount == 3)
                    {
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        break;
                    }
                    map[rowColSquirrel[0], rowColSquirrel[1]] = '*';

                }

                if (map[rowColSquirrel[0], rowColSquirrel[1]] == 't')
                {
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    break;
                }

                if (i == directions.Length - 1)
                {
                    Console.WriteLine("There are more hazelnuts to collect.");
                }
            }

            Console.WriteLine($"Hazelnuts collected: {hazelnutCount}");
        }

        private static bool AreOnTheMap(int[] rowColSquirrel, char[,] map)
        {
            return rowColSquirrel[0] >= 0 && rowColSquirrel[0] < map.GetLength(0)
                && rowColSquirrel[1] >= 0 && rowColSquirrel[1] < map.GetLength(1);
        }

        private static void GetNewCoordinates(string direction, int[] rowColSquirrel)
        {
            switch (direction)
            {
                case "up":
                    rowColSquirrel[0]--;
                    break;
                case "down":
                    rowColSquirrel[0]++;
                    break;
                case "left":
                    rowColSquirrel[1]--;
                    break;
                case "right":
                    rowColSquirrel[1]++;
                    break;
            }
        }
    }
}
