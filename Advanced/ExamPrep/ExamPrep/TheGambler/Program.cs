namespace TheGambler
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int playerRow = 0;
            int playerCol = 0; 
            

            for (int i = 0; i < size; i++)
            {
                char[] currentRow = Console.ReadLine().Trim().ToCharArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i,j] = currentRow[j];

                    if (currentRow[j] == 'G')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            bool leftTheBoard = false;
            string command;
            int totalMoney = 100;
            
            while ((command = Console.ReadLine()) != "end" && totalMoney > 0)
            {
                matrix[playerRow, playerCol] = '-';

                if (command == "up")
                {
                    playerRow--;
                }
                else if (command == "down")
                {
                    playerRow++;
                }
                else if (command == "left")
                {
                    playerCol--;
                }
                else if (command == "right")
                {
                    playerCol++;
                }

                if (!MoveIsInsideBoard(matrix, playerRow, playerCol))
                {
                    leftTheBoard = true; 
                    break;
                }

                if (matrix[playerRow, playerCol] == 'W')
                {
                    totalMoney += 100;
                }
                else if (matrix[playerRow, playerCol] == 'J')
                {
                    Console.WriteLine("You win the Jackpot!");
                    totalMoney += 100_000;
                    break;
                }
                else if (matrix[playerRow, playerCol] == 'P')
                {
                    totalMoney -= 200;
                }
            }

            if (leftTheBoard || totalMoney <= 0)
            {
                Console.WriteLine("Game over! You lost everything!");
                return;
            }

            matrix[playerRow, playerCol] = 'G';
            Console.WriteLine($"End of the game. Total amount: {totalMoney}$");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static bool MoveIsInsideBoard(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}
