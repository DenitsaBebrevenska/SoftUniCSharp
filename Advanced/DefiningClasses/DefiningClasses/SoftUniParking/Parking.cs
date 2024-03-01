using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public int Count => cars.Count;

        public Parking(int capacity)
        {
            cars = new List<Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";

            }

            cars.Remove(car);
            return $"Successfully removed {car.RegistrationNumber}";

        }

        public Car GetCar(string registrationNumber)
        {
            return cars.FirstOrDefault(car => car.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            for (int i = 0; i < registrationNumbers.Count; i++)
            {
                Car currentCar = cars.FirstOrDefault(car => car.RegistrationNumber == registrationNumbers[i]);

                if (currentCar != null)
                {
                    cars.Remove(currentCar);
                }
            }
        }
    }
}
