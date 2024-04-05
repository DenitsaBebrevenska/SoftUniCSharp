using NavalVessels.Models.Contracts;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double SubmarineArmorThickness = 200;
        private const double SubmarineMainWeaponCaliberChange = 40;
        private const double SubmarineSpeedChange = 4;
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, SubmarineArmorThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }
        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;

            if (SubmergeMode)
            {
                MainWeaponCaliber += SubmarineMainWeaponCaliberChange;
                Speed -= SubmarineSpeedChange;
            }
            else
            {
                MainWeaponCaliber -= SubmarineMainWeaponCaliberChange;
                Speed += SubmarineSpeedChange;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            string submergeModeStatus = SubmergeMode ? "ON" : "OFF";
            sb.AppendLine($" *Submerge mode: {submergeModeStatus}");
            return sb.ToString().TrimEnd();
        }
    }
}
