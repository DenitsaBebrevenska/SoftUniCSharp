namespace MonsterExtermination
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> armorValues = new Queue<int>(Console.ReadLine()
                .Split(',')
                .Select(int.Parse));
            Stack<int> strikeValue = new Stack<int>(Console.ReadLine()
                .Split(',')
                .Select(int.Parse));
            int monstersKilled = 0;

            while (armorValues.Count > 0 && strikeValue.Count > 0)
            {
                if (strikeValue.Peek() >= armorValues.Peek())
                {
                    monstersKilled++;
                    int currentStrike = strikeValue.Pop() - armorValues.Dequeue();

                    if (strikeValue.Count == 0)
                    {
                        if (currentStrike == 0)
                        {
                            continue;
                        }

                        strikeValue.Push(currentStrike);
                    }
                    else
                    {
                        strikeValue.Push(strikeValue.Pop() + currentStrike);
                    }
                }
                else
                {
                    int currentArmor = armorValues.Dequeue() - strikeValue.Pop();
                    armorValues.Enqueue(currentArmor);
                }
            }

            PrintBattleResult(armorValues, strikeValue, monstersKilled);
        }

        public static void PrintBattleResult(Queue<int> armorValues, Stack<int> strikeValue, int monstersKilled)
        {
            if (armorValues.Count == 0)
            {
                Console.WriteLine("All monsters have been killed!");
            }

            if (strikeValue.Count == 0)
            {
                Console.WriteLine("The soldier has been defeated.");
            }

            Console.WriteLine($"Total monsters killed: {monstersKilled}");
        }
    }
}
