namespace Crossroads
{
    internal class Program
    {
        static void Main()
        {
            int greenLightTimer = int.Parse(Console.ReadLine()); //in seconds
            int freeWindowTimer = int.Parse(Console.ReadLine()); //in seconds
            //the passing of a car in seconds is equal to its name length
            string input;
            Queue<string> carQueue = new Queue<string>();
            int carsPassedSuccessfully = 0;

            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "green":
                        int timeAvailable = greenLightTimer;

                        while (carQueue.Count > 0 && timeAvailable > 0)
                        {
                            string currentCar = carQueue.Dequeue();
                            
                            if (timeAvailable - currentCar.Length >= 0)
                            {
                                carsPassedSuccessfully++;
                                timeAvailable -= currentCar.Length;
                            }
                            else
                            {
                                timeAvailable += freeWindowTimer;

                                if (currentCar.Length <= timeAvailable)
                                {
                                    carsPassedSuccessfully++;
                                    break;
                                }

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[timeAvailable]}.");
                                return;
                            }
                        }
                        break;
                    default:
                        carQueue.Enqueue(input);
                        break;
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassedSuccessfully} total cars passed the crossroads.");
        }
    }
}
