using System;
using System.Linq;

namespace SuperMario
{
    internal class Program
    {
        static void Main()
        {
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] map = new char[rows][];
            int marioRow = -1, marioCol = -1;
            bool peachSaved = false;

            for (int row = 0; row < rows; row++)
            {
                map[row] = Console.ReadLine().ToCharArray();

                if (map[row].Contains('M'))
                {
                    for (int i = 0; i < map[row].Length; i++)
                    {
                        if (map[row][i] == 'M')
                        {
                            marioRow = row;
                            marioCol = i;
                        }
                    }
                }
            }

            while (lives > 0)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = command[0];
                int spawnRow = int.Parse(command[1]);
                int spawnCol = int.Parse(command[2]);
                map[spawnRow][spawnCol] = 'B';
                lives--;

                int nextRow = marioRow;
                int nextCol = marioCol;

                switch (direction)
                {
                    case "W":
                        nextRow--;
                        break;
                    case "S":
                        nextRow++;
                        break;
                    case "A":
                        nextCol--;
                        break;
                    case "D":
                        nextCol++;
                        break;
                }

                if (!AreValidCoordinates(map, nextRow, nextCol))
                {
                    continue;
                }

                map[marioRow][marioCol] = '-';
                marioRow = nextRow;
                marioCol = nextCol;

                if (map[marioRow][marioCol] == 'P')
                {
                    peachSaved = true;
                    break;
                }
                else if (map[marioRow][marioCol] == 'B')
                {
                    lives -= 2;

                }
            }

            if (peachSaved)
            {
                map[marioRow][marioCol] = '-';
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                map[marioRow][marioCol] = 'X';
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            PrintMap(map);
        }

        private static bool AreValidCoordinates(char[][] map, int row, int col)
        {
            return row >= 0 && row < map.Length
                && col >= 0 && col < map[row].Length;
        }

        private static void PrintMap(char[][] map)
        {
            for (int row = 0; row < map.Length; row++)
            {
                Console.WriteLine(string.Join("", map[row]));
            }
        }
    }
}
