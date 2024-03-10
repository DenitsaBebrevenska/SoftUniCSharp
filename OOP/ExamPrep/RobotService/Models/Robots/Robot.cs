using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private string _model;
        private int _batteryCapacity;
        private List<int> _interfaceStandards;
        protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            BatteryLevel = BatteryCapacity;
            ConvertionCapacityIndex = convertionCapacityIndex;
            _interfaceStandards = new List<int>();
        }

        public string Model
        {
            get => _model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                _model = value;
            }
        }

        public int BatteryCapacity
        {
            get => _batteryCapacity;
            private set
            {
                if (value > 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                _batteryCapacity = value;
            }
        }
        public int BatteryLevel { get; private set; }
        public int ConvertionCapacityIndex { get; private set; }
        public IReadOnlyCollection<int> InterfaceStandards => _interfaceStandards.AsReadOnly();
        public void Eating(int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                int currentPowerProduction = ConvertionCapacityIndex * minutes;

                if (BatteryLevel + currentPowerProduction > BatteryCapacity)
                {
                    break;
                }
                BatteryLevel += ConvertionCapacityIndex * minutes;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            _interfaceStandards.Add(supplement.InterfaceStandard);
            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            string supplements = _interfaceStandards.Count == 0 ? "none" : $"{string.Join(" ", _interfaceStandards)}";
            sb.AppendLine($"--Supplements installed: {supplements}");

            return sb.ToString().TrimEnd();
        }
    }
}
