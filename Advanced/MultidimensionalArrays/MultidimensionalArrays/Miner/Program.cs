namespace Miner
{
    internal class Program
    {
        static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine()); //A square field
            string[] route = Console.ReadLine().Split();
            string[,] field = new string[fieldSize, fieldSize];
            int[] coordinatesMiner = new int[2];
            int coalCount = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                string[] currentRow = Console.ReadLine().Split();

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = currentRow[j];

                    if (currentRow[j] == "s") //starting coordinates for the miner
                    { 
                        coordinatesMiner[0] = i;
                        coordinatesMiner[1] = j;
                    }
                    else if (currentRow[j] == "c")
                    {
                        coalCount++;
                    }
                }
            }

            int rowMinerLocation = coordinatesMiner[0];
            int colMinerLocation = coordinatesMiner[1];
            int coalsCollected = 0;

            for (int i = 0; i < route.Length; i++)
            {
                string direction = route[i];

                if (direction == "up" && rowMinerLocation - 1 >= 0)
                {
                    rowMinerLocation -= 1;
                }
                else if (direction == "down" && rowMinerLocation + 1 < field.GetLength(0))
                {
                    rowMinerLocation += 1;
                }
                else if (direction == "left" && colMinerLocation - 1 >= 0)
                {
                    colMinerLocation -= 1;
                }
                else if (direction == "right" && colMinerLocation + 1 < field.GetLength(1))
                {
                    colMinerLocation += 1;
                }

                if (field[rowMinerLocation, colMinerLocation] == "e")
                {
                    Console.WriteLine($"Game over! ({rowMinerLocation}, {colMinerLocation})");
                    return;
                }

                if (field[rowMinerLocation,colMinerLocation] == "c")
                {
                    coalsCollected++;
                    field[rowMinerLocation, colMinerLocation] = "*";
                }

                if (coalsCollected == coalCount)
                {
                    Console.WriteLine($"You collected all coals! ({rowMinerLocation}, {colMinerLocation})");
                    return;
                }
            }

            Console.WriteLine($"{coalCount - coalsCollected} coals left. ({rowMinerLocation}, {colMinerLocation})");
        }
    }
}
