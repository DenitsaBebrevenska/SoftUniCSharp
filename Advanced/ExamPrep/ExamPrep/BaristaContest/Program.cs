namespace BaristaContest
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> coffee = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> milk = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Dictionary<int, string> beverages = new()
            {
                {50,"Cortado"},
                {75,"Espresso"},
                {100,"Capuccino"},
                {150,"Americano"},
                {200,"Latte"}
            };
            Dictionary<string, int> completedBeverages = new();

            while (coffee.Count > 0 && milk.Count > 0)
            {
                int currentCoffee = coffee.Dequeue();
                int currentMilk = milk.Pop();
                int result = currentCoffee + currentMilk;
                var targetDrink = beverages.FirstOrDefault(b => b.Key == result);

                if (targetDrink.Value == null)
                {
                    milk.Push(currentMilk - 5);
                    continue;
                }

                if (!completedBeverages.ContainsKey(targetDrink.Value))
                {
                    completedBeverages.Add(targetDrink.Value, 0);
                }

                completedBeverages[targetDrink.Value]++;
            }

            if (coffee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            Console.WriteLine(coffee.Count == 0 ? "Coffee left: none" : $"Coffee left: {string.Join(", ", coffee)}");
            Console.WriteLine(milk.Count == 0 ? "Milk left: none" : $"Milk left: {string.Join(", ", milk)}");

            foreach (var beverage in completedBeverages
                         .OrderBy(b => b.Value)
                         .ThenByDescending(b => b.Key))
            {
                Console.WriteLine($"{beverage.Key}: {beverage.Value}");
            }
        }
    }
}
