using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car()
        {
            TravelledDistance = 0;
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer) : this()
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public void Drive(int distance)
        {
            double fuelNeeded = distance * FuelConsumptionPerKilometer;

            if (FuelAmount < fuelNeeded)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            FuelAmount -= fuelNeeded;
            TravelledDistance += distance;
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }
    }
}
