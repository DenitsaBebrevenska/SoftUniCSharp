using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private const int ExperienceGain = 10;
        private string fullName;
        private List<IVessel> vessels;
        public Captain(string fullName)
        {
            FullName = fullName;
            CombatExperience = 0;
            vessels = new List<IVessel>();
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }
        public int CombatExperience { get; private set; }
        public ICollection<IVessel> Vessels => vessels.AsReadOnly();
        public void AddVessel(IVessel vessel)
        {
            if (vessel is null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
            => CombatExperience += ExperienceGain;

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");
            vessels.ForEach(v => report.AppendLine(v.ToString()));
            return report.ToString().TrimEnd();
        }
    }
}
