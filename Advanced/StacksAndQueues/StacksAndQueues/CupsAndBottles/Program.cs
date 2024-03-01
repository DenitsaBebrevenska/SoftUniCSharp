namespace CupsAndBottles
{
    internal class Program
    {
        static void Main()
        {
           List<int> cups = Console.ReadLine().Split().Select(int.Parse).ToList();
           Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
           int wastedWater = 0;

           while (bottles.Count > 0 && cups.Count > 0)
           {
               int currentBottle = bottles.Peek();
               
               if (currentBottle >= cups[0])
               {
                   wastedWater += currentBottle - cups[0];
                   bottles.Pop();
                   cups.RemoveAt(0);
                   continue;
               }

               cups[0] -= currentBottle; 
               bottles.Pop();

           }

           if (bottles.Count == 0)
           {
               Console.WriteLine($"Cups: {string.Join(" ", cups)}");
           }
           else if (cups.Count == 0)
           {
               Console.WriteLine($"Bottles: {string.Join(" ", bottles)}" );
           }

           Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
