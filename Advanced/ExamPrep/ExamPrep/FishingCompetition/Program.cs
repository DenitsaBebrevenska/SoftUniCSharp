namespace FishingCompetition
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int fishermanRow = -1;
            int fishermanCol = -1;
            char[,] fishingArea = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    fishingArea[row, col] = currentRow[col];

                    if (fishingArea[row, col] == 'S')
                    {
                        fishermanRow = row;
                        fishermanCol = col;
                    }
                }
            }

            string command;
            int collectedFish = 0;

            while ((command = Console.ReadLine()) != "collect the nets")
            {
                fishingArea[fishermanRow, fishermanCol] = '-';

                if (command == "up" || command == "down")
                {
                    fishermanRow = UpdateRowPosition(command, fishermanRow, fishingArea);
                }
                else if (command == "left" || command == "right")
                {
                    fishermanCol = UpdateColPosition(command, fishermanCol, fishingArea);
                }

                if (char.IsDigit(fishingArea[fishermanRow, fishermanCol]))
                {
                    collectedFish += fishingArea[fishermanRow, fishermanCol] - '0';
                }
                else if (fishingArea[fishermanRow, fishermanCol] == 'W')
                {
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{fishermanRow},{fishermanCol}]");
                    Environment.Exit(0);
                }
            }

            fishingArea[fishermanRow, fishermanCol] = 'S';
            PrintCaughtFishStatistics(collectedFish);
            PrintMatrix(fishingArea);
        }

        static void PrintCaughtFishStatistics(int collectedFish)
        {
            if (collectedFish >= 20)
            {
                Console.WriteLine("Success! You managed to reach the quota!");

            }
            else
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - collectedFish} tons of fish more.");

            }

            if (collectedFish > 0)
            {
                Console.WriteLine($"Amount of fish caught: {collectedFish} tons.");
            }
        }

        static void PrintMatrix(char[,] fishingArea)
        {
            for (int row = 0; row < fishingArea.GetLength(0); row++)
            {
                for (int col = 0; col < fishingArea.GetLength(1); col++)
                {
                    Console.Write(fishingArea[row, col]);
                }

                Console.WriteLine();
            }
        }

        static int UpdateRowPosition(string command, int fishermanRow, char[,] fishingArea)
        {
            if (command == "up")
            {
                if (fishermanRow - 1 >= 0)
                {
                    fishermanRow--;
                }
                else
                {
                    fishermanRow = fishingArea.GetLength(0) - 1;
                }

            }
            else if (command == "down")
            {
                if (fishermanRow + 1 < fishingArea.GetLength(0))
                {
                    fishermanRow++;
                }
                else
                {
                    fishermanRow = 0;
                }
            }

            return fishermanRow;
        }

        static int UpdateColPosition(string command, int fishermanCol, char[,] fishingArea)
        {
            if (command == "left")
            {
                if (fishermanCol - 1 >= 0)
                {
                    fishermanCol--;
                }
                else
                {
                    fishermanCol = fishingArea.GetLength(1) - 1;
                }

            }
            else if (command == "right")
            {
                if (fishermanCol + 1 < fishingArea.GetLength(1))
                {
                    fishermanCol++;
                }
                else
                {
                    fishermanCol = 0;
                }
            }
            return fishermanCol;
        }
    }
}
