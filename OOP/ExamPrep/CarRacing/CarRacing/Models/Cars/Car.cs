using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;
using System;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsepower;
        private double fuelConsumptionPerRace;
        protected Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            VIN = vin;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        public string Make
        {
            get => make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }
                make = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }
                model = value;
            }
        }

        public string VIN
        {
            get => vin;
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }
                vin = value;
            }
        }

        public int HorsePower
        {
            get => horsepower;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }
                horsepower = value;
            }
        }

        public double FuelAvailable { get; private set; }

        public double FuelConsumptionPerRace
        {
            get => fuelConsumptionPerRace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }
                fuelConsumptionPerRace = value;
            }
        }
        public virtual void Drive()
        {
            double newFuelAvailable = FuelAvailable - FuelConsumptionPerRace;
            //fuel can`t go below zero
            FuelAvailable = Math.Max(0, newFuelAvailable);
        }

    }
}
