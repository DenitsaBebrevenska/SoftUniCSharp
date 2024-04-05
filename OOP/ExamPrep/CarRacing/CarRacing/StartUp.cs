using CarRacing.Models.Cars;
using System;

namespace CarRacing
{
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new SuperCar("sd", "sddd", "asdadascasdwerftg", 20);
            car.Drive();
            Console.WriteLine();
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
