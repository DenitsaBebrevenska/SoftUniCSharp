namespace HelpAMole
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            int moleRow = -1, moleCol = -1;
            int firstPortalRow = -1, firstPortalCol = -1;
            int secondPortalRow = -1, secondPortalCol = -1;
            bool firstPortalFound = false;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currentRow[col];

                    if (currentRow[col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                    else if (currentRow[col] == 'S' && !firstPortalFound)
                    {
                        firstPortalRow = row;
                        firstPortalCol = col;
                        firstPortalFound = true;
                    }
                    else if (currentRow[col] == 'S' && firstPortalFound)
                    {
                        secondPortalRow = row;
                        secondPortalCol = col;
                    }
                }
            }

            int points = 0;
            int nextRow = moleRow, nextCol = moleCol;
            bool victoryAchieved = false;
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
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

                if (!IsInsideTheField(field, nextRow, nextCol))
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    nextRow = moleRow;
                    nextCol = moleCol;
                    continue;
                }

                field[moleRow, moleCol] = '-';
                moleRow = nextRow;
                moleCol = nextCol;

                if (char.IsDigit(field[moleRow, moleCol]))
                {
                    points += field[moleRow, moleCol] - '0';

                    if (points >= 25)
                    {
                        victoryAchieved = true;
                        break;
                    }
                }
                else if (field[moleRow, moleCol] == 'S')
                {
                    if (moleRow == firstPortalRow && moleCol == firstPortalCol)
                    {
                        field[firstPortalRow, firstPortalCol] = '-';
                        moleRow = nextRow = secondPortalRow;
                        moleCol = nextCol = secondPortalCol;
                    }
                    else
                    {
                        field[secondPortalRow, secondPortalCol] = '-';
                        moleRow = nextRow = firstPortalRow;
                        moleCol = nextCol = firstPortalCol;
                    }

                    points -= 3;
                }
            }

            field[moleRow, moleCol] = 'M';

            Console.WriteLine(victoryAchieved ?
                $"Yay! The Mole survived another game!{Environment.NewLine}The Mole managed to survive with a total of {points} points."
                : $"Too bad! The Mole lost this battle!{Environment.NewLine}The Mole lost the game with a total of {points} points.");
            PrintField(field);
        }

        private static bool IsInsideTheField(char[,] field, int nextRow, int nextCol)
        {
            return nextRow >= 0 && nextRow < field.GetLength(0) &&
                   nextCol >= 0 && nextCol < field.GetLength(1);

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
