using Gym.Core.Contracts;
using System;

namespace Gym.Core
{
    public class Controller : IController
    {
        public string AddGym(string gymType, string gymName)
        {
            throw new NotImplementedException();
        }

        public string AddEquipment(string equipmentType)
        {
            throw new NotImplementedException();
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            throw new NotImplementedException();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            throw new NotImplementedException();
        }

        public string TrainAthletes(string gymName)
        {
            throw new NotImplementedException();
        }

        public string EquipmentWeight(string gymName)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
