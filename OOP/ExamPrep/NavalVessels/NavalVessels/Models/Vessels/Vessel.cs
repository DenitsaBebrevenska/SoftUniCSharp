using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private List<string> targets;
        private ICaptain captain;
        private double armorThickness;
        private double initialArmorThickness;
        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            initialArmorThickness = armorThickness;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            set
            {
                if (value is null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                captain = value;
            }
        }

        public double ArmorThickness
        {
            get => armorThickness;
            set
            {
                if (value < 0)
                {
                    armorThickness = 0;
                }

                armorThickness = value;
            }
        }
        public double MainWeaponCaliber { get; protected set; }
        public double Speed { get; protected set; }
        public ICollection<string> Targets => targets.AsReadOnly();
        public void Attack(IVessel target)
        {
            if (target is null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;
        }

        public void RepairVessel()
            => ArmorThickness = initialArmorThickness;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($"*Type: {GetType().Name}");
            sb.AppendLine($"*Armor thickness: {ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {Speed} knots");
            string vesselTargets = Targets.Count == 0 ? "None" : $"{string.Join(", ", Targets)}";
            sb.AppendLine($"*Targets: {vesselTargets}");

            return sb.ToString().TrimEnd();
        }

    }
}
