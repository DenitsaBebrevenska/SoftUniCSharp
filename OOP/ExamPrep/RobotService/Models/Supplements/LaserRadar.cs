namespace RobotService.Models.Supplements
{
    public class LaserRadar : Supplement
    {
        private const int LaserRadarInterfaceStandard = 20_082;
        private const int LaserRadarBatteryUsage = 5_000;
        public LaserRadar()
            : base(LaserRadarInterfaceStandard, LaserRadarBatteryUsage)
        {
        }
    }
}
