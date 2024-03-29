﻿using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;

namespace EDriveRent.Models.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private string _brand;
        private string _model;
        private string _licensePlateNumber;

        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            BatteryLevel = 100;
            IsDamaged = false;
            Brand = brand;
            Model = model;
            LicensePlateNumber = licensePlateNumber;
            Brand = brand;
            MaxMileage = maxMileage;
        }
        public string Brand
        {
            get => _brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                _brand = value;
            }
        }
        public string Model
        {
            get => _model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                _model = value;
            }
        }
        public double MaxMileage { get; private set; }
        public string LicensePlateNumber
        {
            get => _licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                _licensePlateNumber = value;
            }
        }
        public int BatteryLevel { get; private set; }
        public bool IsDamaged { get; private set; }
        public void Drive(double mileage)
        {
            double percentage = mileage / MaxMileage * 100;

            if (this.GetType().Name == "CargoVan")
            {
                percentage += 5;
            }

            int rounderPercentage = (int)Math.Round(percentage);

            BatteryLevel -= (BatteryLevel * rounderPercentage) / 100;
        }

        public void Recharge()
            => BatteryLevel = 100;

        public void ChangeStatus()
            => IsDamaged = !IsDamaged;

        public override string ToString()
        {
            string status = IsDamaged ? "damaged" : "OK";
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {status}";
        }
    }
}
