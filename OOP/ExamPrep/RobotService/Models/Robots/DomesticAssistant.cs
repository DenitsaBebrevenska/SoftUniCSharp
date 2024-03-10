namespace RobotService.Models.Robots
{
    public class DomesticAssistant : Robot
    {
        private const int DomesticAssistantBatteryCapacity = 20_000;
        private const int DomesticAssistantConvertionCapacityIndex = 2_000;
        public DomesticAssistant(string model)
            : base(model, DomesticAssistantBatteryCapacity, DomesticAssistantConvertionCapacityIndex)
        {
        }
    }
}
