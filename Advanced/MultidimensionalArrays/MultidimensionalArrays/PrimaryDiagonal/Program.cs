namespace PrimaryDiagonal
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sumPrimaryDiagonal = 0;

            for (int i = 0; i < n; i++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i,j] = currentRow[j];

                    if (i == j)
                    {
                        sumPrimaryDiagonal += currentRow[j];
                    }
                }
            }

            Console.WriteLine(sumPrimaryDiagonal);
        }
    }
}
