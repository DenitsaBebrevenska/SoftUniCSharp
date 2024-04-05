using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private IRepository<ICar> cars;
        private IRepository<IRacer> racers;
        private IMap map;
        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;

            switch (type)
            {
                case "SuperCar":
                    car = new SuperCar(make, model, VIN, horsePower);
                    break;
                case "TunedCar":
                    car = new TunedCar(make, model, VIN, horsePower);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer;

            switch (type)
            {
                case "ProfessionalRacer":
                    racer = new ProfessionalRacer(username, car);
                    break;
                case "StreetRacer":
                    racer = new StreetRacer(username, car);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer firstRacer = racers.FindBy(racerOneUsername);
            IRacer secondRacer = racers.FindBy(racerTwoUsername);

            if (firstRacer == null || secondRacer == null)
            {
                string missingRacer = firstRacer == null ? racerOneUsername : racerTwoUsername;
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, missingRacer));
            }

            return map.StartRace(firstRacer, secondRacer);
        }

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();

            foreach (var racer in racers.Models
                         .OrderByDescending(r => r.DrivingExperience)
                         .ThenBy(r => r.Username))
            {
                reportBuilder.AppendLine(racer.ToString());
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }
}
