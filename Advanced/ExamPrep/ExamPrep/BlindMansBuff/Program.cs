namespace BlindMansBuff
{
    internal class Program
    {
        static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] playground = new char[size[0], size[1]];
            int playerRow = -1, playerCol = -1;

            for (int row = 0; row < playground.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < playground.GetLength(1); col++)
                {
                    playground[row, col] = currentRow[col];

                    if (currentRow[col] == 'B')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            int playerNextRow = playerRow;
            int playerNextCol = playerCol;
            int movesMade = 0, opponentsTouched = 0;
            string command;

            while ((command = Console.ReadLine()) != "Finish")
            {
                switch (command)
                {
                    case "up":
                        playerNextRow--;
                        break;
                    case "down":
                        playerNextRow++;
                        break;
                    case "left":
                        playerNextCol--;
                        break;
                    case "right":
                        playerNextCol++;
                        break;
                }

                if (!CanMoveToNextPosition(playerNextRow, playerNextCol, playground))
                {
                    playerNextRow = playerRow;
                    playerNextCol = playerCol;
                    continue;
                }

                if (playground[playerNextRow, playerNextCol] == 'P')
                {
                    playground[playerNextRow, playerNextCol] = '-';
                    opponentsTouched++;


                }

                movesMade++;
                playerRow = playerNextRow;
                playerCol = playerNextCol;

                if (opponentsTouched == 3)
                {
                    break;
                }

            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {opponentsTouched} Moves made: {movesMade}");
        }

        private static bool CanMoveToNextPosition(int playerNextRow, int playerNextCol, char[,] playground)
        {
            if (playerNextRow >= 0 && playerNextRow < playground.GetLength(0) &&
                playerNextCol >= 0 && playerNextCol < playground.GetLength(1) &&
                playground[playerNextRow, playerNextCol] != 'O')
            {
                return true;
            }

            return false;
        }
    }
}
