using RobotService.Factories.Contracts;
using RobotService.Models.Contracts;
using RobotService.Models.Robots;

namespace RobotService.Factories
{
    public class RobotFactory : IFactory<IRobot>
    {
        public IRobot CreateInstance(string typeName, params string[] tokens)
        {
            switch (typeName)
            {
                case "DomesticAssistant":
                    return new DomesticAssistant(tokens[0]);
                case "IndustrialAssistant":
                    return new IndustrialAssistant(tokens[0]);
            }

            return default;
        }
    }
}
