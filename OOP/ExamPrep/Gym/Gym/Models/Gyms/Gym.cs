using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipmentItems;
        private List<IAthlete> athletes;
        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipmentItems = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }
        public int Capacity { get; }
        public double EquipmentWeight => equipmentItems.Sum(e => e.Weight);
        public ICollection<IEquipment> Equipment => equipmentItems.AsReadOnly();
        public ICollection<IAthlete> Athletes => athletes.AsReadOnly();
        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
            => athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment)
            => equipmentItems.Add(equipment);

        public void Exercise()
            => athletes.ForEach(a => a.Exercise());

        public string GymInfo()
        {
            StringBuilder gymInfo = new StringBuilder();
            gymInfo.AppendLine($"{Name} is a {GetType().Name}:");
            string athletesInfo = athletes.Count == 0 ? "No athletes" : $"{string.Join(", ", athletes.Select(a => a.FullName))}";
            gymInfo.AppendLine($"Athletes: {athletesInfo}");
            gymInfo.AppendLine($"Equipment total count: {equipmentItems.Count}");
            gymInfo.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return gymInfo.ToString().TrimEnd();
        }
    }
}
