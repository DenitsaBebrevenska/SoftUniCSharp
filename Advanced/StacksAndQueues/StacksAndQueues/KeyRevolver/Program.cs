namespace KeyRevolver
{
    internal class Program
    {
        static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int valueOfIntelligence = int.Parse(Console.ReadLine());
            int totalBullets = bullets.Count;
            int bulletsUsed = 0;

            while (locks.Count > 0 && bullets.Count > 0)
            {
                int currentLock = locks.Peek();

                while (bullets.Count > 0)
                {
                    int currentBullet = bullets.Pop();
                    bulletsUsed++;
                    bool targetShot = false;

                    if (currentBullet <= currentLock)
                    {
                        locks.Dequeue();
                        Console.WriteLine("Bang!");
                        targetShot = true;
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                    if (bulletsUsed % barrelSize == 0 && bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!"); 
                    }

                    if (targetShot)
                    {
                        break;
                    }

                }
                
            }

            if (locks.Count > 0 && bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence - bulletsUsed * bulletPrice}");
            }  
        }
    }
}