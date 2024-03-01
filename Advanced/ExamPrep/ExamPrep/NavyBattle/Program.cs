namespace NavyBattle
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] battlefield = new char[size, size];
            int submarineRow = -1;
            int submarineCol = -1;

            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < battlefield.GetLength(1); col++)
                {
                    battlefield[row, col] = currentRow[col];

                    if (currentRow[col] == 'S')
                    {
                        submarineRow = row;
                        submarineCol = col;
                    }
                }
            }

            int mineCount = 3, cruiserCount = 3;

            while (mineCount > 0 && cruiserCount > 0)
            {
                battlefield[submarineRow, submarineCol] = '-';
                string direction = Console.ReadLine();

                switch (direction)
                {
                    case "up":
                        submarineRow--;
                        break;
                    case "down":
                        submarineRow++;
                        break;
                    case "left":
                        submarineCol--;
                        break;
                    case "right":
                        submarineCol++;
                        break;
                }

                if (battlefield[submarineRow, submarineCol] == '*')
                {
                    mineCount--;
                }
                else if (battlefield[submarineRow, submarineCol] == 'C')
                {
                    cruiserCount--;
                }
            }

            battlefield[submarineRow, submarineCol] = 'S';

            PrintBattleOutcome(cruiserCount, mineCount, submarineRow, submarineCol);
            PrintBattlefield(battlefield);
        }

        private static void PrintBattleOutcome(int cruiserCount, int mineCount, int submarineRow, int submarineCol)
        {
            if (cruiserCount == 0)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            }
            else if (mineCount == 0)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
            }
        }
        private static void PrintBattlefield(char[,] battlefield)
        {

            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                for (int col = 0; col < battlefield.GetLength(1); col++)
                {
                    Console.Write(battlefield[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
