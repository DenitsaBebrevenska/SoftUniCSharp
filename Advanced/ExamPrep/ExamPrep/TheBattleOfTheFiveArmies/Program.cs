using System;
using System.Linq;

namespace TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main()
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] map = new char[rows][];
            int armyRow = -1, armyCol = -1;

            for (int row = 0; row < rows; row++)
            {
                map[row] = Console.ReadLine().Trim().ToCharArray();

                if (map[row].Contains('A'))
                {
                    for (int i = 0; i < map[row].Length; i++)
                    {
                        if (map[row][i] == 'A')
                        {
                            armyRow = row;
                            armyCol = i;
                        }
                    }
                }
            }

            bool reachedMordor = false;

            while (armor > 0)
            {
                string[] lineDetails = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = lineDetails[0];
                int spawnRow = int.Parse(lineDetails[1]);
                int spawnCol = int.Parse(lineDetails[2]);

                map[spawnRow][spawnCol] = 'O';
                map[armyRow][armyCol] = '-';
                armor--;

                int nextRow = armyRow, nextCol = armyCol;

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

                if (!AreValidCoordinates(map, nextRow, nextCol))
                {
                    continue;
                }

                armyRow = nextRow;
                armyCol = nextCol;

                if (map[armyRow][armyCol] == 'M')
                {
                    reachedMordor = true;
                    map[armyRow][armyCol] = '-';
                    break;
                }

                if (map[armyRow][armyCol] == 'O')
                {
                    armor -= 2;

                    if (armor <= 0)
                    {
                        break;
                    }
                }
            }

            if (reachedMordor)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }
            else
            {
                map[armyRow][armyCol] = 'X';
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }

            PrintMap(map);
        }

        static bool AreValidCoordinates(char[][] map, int row, int col)
        {
            return row >= 0 && row < map.Length &&
                   col >= 0 && col < map[row].Length;
        }

        static void PrintMap(char[][] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.WriteLine(string.Join("", map[i]));
            }
        }
    }
}
