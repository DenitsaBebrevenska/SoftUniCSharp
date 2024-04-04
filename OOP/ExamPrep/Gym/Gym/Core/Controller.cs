using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private List<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            switch (gymType)
            {
                case "BoxingGym":
                    gym = new BoxingGym(gymName);
                    break;
                case "WeightliftingGym":
                    gym = new WeightliftingGym(gymName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            gyms.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment pieceOfEquipment;

            switch (equipmentType)
            {
                case "BoxingGloves":
                    pieceOfEquipment = new BoxingGloves();
                    break;
                case "Kettlebell":
                    pieceOfEquipment = new Kettlebell();
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            equipment.Add(pieceOfEquipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment pieceOfEquipment = equipment.FindByType(equipmentType);

            if (pieceOfEquipment is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gyms.First(g => g.Name == gymName).AddEquipment(pieceOfEquipment);
            equipment.Remove(pieceOfEquipment);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;

            switch (athleteType)
            {
                case "Boxer":
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;
                case "Weightlifter":
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IGym gym = gyms.First(g => g.Name == gymName);

            if (athlete is Boxer && gym.GetType() != typeof(BoxingGym)
                || athlete is Weightlifter && gym.GetType() != typeof(WeightliftingGym))
            {
                return OutputMessages.InappropriateGym;
            }

            gym.AddAthlete(athlete);
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.First(g => g.Name == gymName);
            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.First(g => g.Name == gymName);
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, $"{gym.EquipmentWeight:F2}");
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            gyms.ForEach(g => report.AppendLine(g.GymInfo()));
            return report.ToString().TrimEnd();
        }
    }
}
