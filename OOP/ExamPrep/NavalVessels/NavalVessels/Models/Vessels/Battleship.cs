using NavalVessels.Models.Contracts;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    public class Battleship : Vessel, IBattleship
    {
        private const double BattleShipArmorThickness = 300;
        private const double BattleShipMainWeaponCaliberChange = 40;
        private const double BattleShipSpeedChange = 5;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, BattleShipArmorThickness)
        {
            SonarMode = false;
        }
        public bool SonarMode { get; private set; }
        public void ToggleSonarMode()
        {
            if (!SonarMode)
            {
                MainWeaponCaliber += BattleShipMainWeaponCaliberChange;
                Speed -= BattleShipSpeedChange;
            }
            else
            {
                MainWeaponCaliber -= BattleShipMainWeaponCaliberChange;
                Speed += BattleShipSpeedChange;
            }

            SonarMode = !SonarMode;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            string sonarModeStatus = SonarMode ? "ON" : "OFF";
            sb.AppendLine($"*Sonar mode: {sonarModeStatus}");
            return sb.ToString().TrimEnd();
        }
    }
}
