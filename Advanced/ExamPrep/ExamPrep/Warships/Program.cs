using System;
using System.Collections.Generic;
using System.Linq;

namespace Warships
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(",");
            Queue<int[]> commandCoordinates = new Queue<int[]>();

            foreach (var command in commands)
            {
                int[] currentCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                commandCoordinates.Enqueue(new[] { currentCommand[0], currentCommand[1]});
            }

            List<string> playerOneShipCoordinates = new  List<string>();
            List<string> playerTwoShipCoordinates = new List<string>();
            
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

                    if (currentRow[col] == '<')
                    {
                        playerOneShipCoordinates.Add($"{row} {col}");
                    }
                    else if (currentRow[col] == '>')
                    {
                        playerTwoShipCoordinates.Add($"{row} {col}");
                    }
                }
            }

            int playerOneShipCount = playerOneShipCoordinates.Count;
            int playerTwoShipCount = playerTwoShipCoordinates.Count;


            while (playerOneShipCoordinates.Any() && playerTwoShipCoordinates.Any()
                                                  && commandCoordinates.Any())
            {
                int[] currentCommand = commandCoordinates.Dequeue();
                string coordinatesString = $"{currentCommand[0]} {currentCommand[1]}";

                if (AreValidCoordinates(field, currentCommand[0], currentCommand[1]))
                {
                    if (playerOneShipCoordinates.Contains(coordinatesString))
                    {
                        playerOneShipCoordinates.Remove(coordinatesString);
                    }
                    else if (playerTwoShipCoordinates.Contains(coordinatesString))
                    {
                        playerTwoShipCoordinates.Remove(coordinatesString);
                    }
                    else if (field[currentCommand[0], currentCommand[1]] == '#')
                    {
                        MineExplode(field, currentCommand, playerOneShipCoordinates, playerTwoShipCoordinates);
                    }
                }
            }

            int shipsSunken = (playerOneShipCount + playerTwoShipCount) -
                              (playerOneShipCoordinates.Count + playerTwoShipCoordinates.Count);

            if (!playerOneShipCoordinates.Any())
            {
                Console.WriteLine($"Player Two has won the game! {shipsSunken} ships have been sunk in the battle.");
            }
            else if (!playerTwoShipCoordinates.Any())
            {
                Console.WriteLine($"Player One has won the game! {shipsSunken} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShipCoordinates.Count} ships left." +
                                  $" Player Two has {playerTwoShipCoordinates.Count} ships left.");
            }
        }

        private static void MineExplode(char[,] field, int[] coordinates, List<string> playerOneShipCoordinates, List<string> playerTwoShipCoordinates)
        {
            field[coordinates[0], coordinates[1]] = 'X';

            if (AreValidCoordinates(field, coordinates[0] - 1, coordinates[1] - 1))
            {
                if (field[coordinates[0] - 1, coordinates[1] - 1] != '*')
                {
                    field[coordinates[0] - 1, coordinates[1]] = 'X';
                    string coordinatesString = $"{coordinates[0] - 1} {coordinates[1] - 1}";
                    playerOneShipCoordinates.Remove(coordinatesString);
                    playerTwoShipCoordinates.Remove(coordinatesString);
                }

            }

            if (AreValidCoordinates(field, coordinates[0] + 1, coordinates[1] + 1))
            {
                if (field[coordinates[0] + 1, coordinates[1] + 1] != '*')
                {
                    field[coordinates[0] + 1, coordinates[1] + 1] = 'X';
                    string coordinatesString = $"{coordinates[0] + 1} {coordinates[1] + 1}";
                    playerOneShipCoordinates.Remove(coordinatesString);
                    playerTwoShipCoordinates.Remove(coordinatesString);
                }
            }

            if (AreValidCoordinates(field, coordinates[0], coordinates[1] - 1))
            {
                if (field[coordinates[0], coordinates[1] - 1] != '*')
                {
                    field[coordinates[0], coordinates[1] - 1] = 'X';
                    string coordinatesString = $"{coordinates[0]} {coordinates[1] - 1}";
                    playerOneShipCoordinates.Remove(coordinatesString);
                    playerTwoShipCoordinates.Remove(coordinatesString);
                }
            }
            if (AreValidCoordinates(field, coordinates[0] + 1, coordinates[1] - 1))
            {
                if (field[coordinates[0] + 1, coordinates[1] - 1] != '*')
                {
                    field[coordinates[0] + 1, coordinates[1] - 1] = 'X';
                    string coordinatesString = $"{coordinates[0] + 1} {coordinates[1] - 1}";
                    playerOneShipCoordinates.Remove(coordinatesString);
                    playerTwoShipCoordinates.Remove(coordinatesString);
                }
            }
            if (AreValidCoordinates(field, coordinates[0] - 1, coordinates[1]))
            {
                if (field[coordinates[0] - 1, coordinates[1]] != '*')
                {
                    field[coordinates[0] - 1, coordinates[1]] = 'X';
                    string coordinatesString = $"{coordinates[0] - 1} {coordinates[1]}";
                    playerOneShipCoordinates.Remove(coordinatesString);
                    playerTwoShipCoordinates.Remove(coordinatesString);
                }
            }
            if (AreValidCoordinates(field, coordinates[0] + 1, coordinates[1]))
            {
                if (field[coordinates[0] + 1, coordinates[1]] != '*')
                {
                    field[coordinates[0] + 1, coordinates[1]] = 'X';
                    string coordinatesString = $"{coordinates[0] + 1} {coordinates[1]}";
                    playerOneShipCoordinates.Remove(coordinatesString);
                    playerTwoShipCoordinates.Remove(coordinatesString);
                }
            }
            if (AreValidCoordinates(field, coordinates[0] - 1, coordinates[1] + 1))
            {
                if (field[coordinates[0] - 1, coordinates[1] + 1] != '*')
                {
                    field[coordinates[0] - 1, coordinates[1] + 1] = 'X';
                    string coordinatesString = $"{coordinates[0] - 1} {coordinates[1] + 1}";
                    playerOneShipCoordinates.Remove(coordinatesString);
                    playerTwoShipCoordinates.Remove(coordinatesString);
                }
            }
            if (AreValidCoordinates(field, coordinates[0], coordinates[1] + 1))
            {
                if (field[coordinates[0], coordinates[1] + 1] != '*')
                {
                    field[coordinates[0], coordinates[1] + 1] = 'X';
                    string coordinatesString = $"{coordinates[0]} {coordinates[1] + 1}";
                    playerOneShipCoordinates.Remove(coordinatesString);
                    playerTwoShipCoordinates.Remove(coordinatesString);
                }
            }
        }

        private static bool AreValidCoordinates(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0)
                && col >= 0 && col < field.GetLength(1);
        }
    }
}
