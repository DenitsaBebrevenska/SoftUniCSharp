using RobotService.Factories.Contracts;
using RobotService.Models.Contracts;
using RobotService.Models.Supplements;

namespace RobotService.Factories
{
    public class SupplementFactory : IFactory<ISupplement>
    {
        public ISupplement CreateInstance(string typeName, params string[] tokens)
        {
            switch (typeName)
            {
                case "LaserRadar":
                    return new LaserRadar();
                case "SpecializedArm":
                    return new SpecializedArm();
            }

            return default;
        }
    }
}
