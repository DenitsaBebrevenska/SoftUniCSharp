using RobotService.Core.Contracts;
using RobotService.Factories;
using RobotService.Factories.Contracts;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IRepository<ISupplement> _supplements;
        private IRepository<IRobot> _robots;
        private IFactory<ISupplement> _suppmentFactory;
        private IFactory<IRobot> _robotFactory;
        public Controller()
        {
            _supplements = new SupplementRepository();
            _robots = new RobotRepository();
            _suppmentFactory = new SupplementFactory();
            _robotFactory = new RobotFactory();
        }

        public string CreateRobot(string model, string typeName)
        {
            //Commented lines do not work in one of the hidden tests for whatever the reason....
            //var children = Assembly.GetAssembly(typeof(Robot))
            //    .GetTypes()
            //    .Where(t => t.IsClass && !t.IsAbstract && t.IsAssignableTo(typeof(Robot)))
            //    .ToList();

            //if (children.All(ch => ch.Name != typeName))
            //{
            //    return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            //}

            //var instance = Activator.CreateInstance(children.First(ch => ch.Name == typeName), model);
            //_robots.AddNew(instance as IRobot);

            //return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);


            IRobot robot = _robotFactory.CreateInstance(typeName, model);

            if (robot is null)
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            _robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {

            //var children = Assembly.GetAssembly(typeof(Supplement))
            //    .GetTypes()
            //    .Where(t => t.IsClass && !t.IsAbstract && t.IsAssignableTo(typeof(Supplement)))
            //    .ToList();

            //if (children.All(ch => ch.Name != typeName))
            //{
            //    return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            //}

            //var instance = Activator.CreateInstance(children.First(ch => ch.Name == typeName));
            //_supplements.AddNew(instance as ISupplement);

            //return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);

            ISupplement supplement = _suppmentFactory.CreateInstance(typeName);

            if (supplement is null)
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            _supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = _supplements.Models().First(m => m.GetType().Name == supplementTypeName);

            var robots = _robots.Models()
                .Where(r => !r.InterfaceStandards.Contains(supplement.InterfaceStandard) && r.Model == model)
                .ToList();

            if (!robots.Any())
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            robots.First().InstallSupplement(supplement);
            _supplements.RemoveByName(supplementTypeName);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }

        public string RobotRecovery(string model, int minutes)
        {
            var robotsToRecover = _robots.Models()
                .Where(r => r.Model == model && r.BatteryLevel / r.BatteryCapacity * 100 < 50)
                .ToList();
            robotsToRecover.ForEach(r => r.Eating(minutes));

            return string.Format(OutputMessages.RobotsFed, robotsToRecover.Count);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var suitableRobots = _robots.Models()
                .Where(r => r.InterfaceStandards.Contains(intefaceStandard))
                .OrderByDescending(r => r.BatteryLevel)
                .ToList();

            if (!suitableRobots.Any())
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int sumBatteryLevels = suitableRobots.Sum(r => r.BatteryLevel);

            if (sumBatteryLevels < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sumBatteryLevels);
            }

            int robotsParticipated = 0;

            for (int i = 0; i < suitableRobots.Count; i++)
            {
                if (suitableRobots[i].BatteryLevel >= totalPowerNeeded)
                {
                    suitableRobots[i].ExecuteService(totalPowerNeeded);
                    robotsParticipated++;
                    break;
                }
                else
                {
                    totalPowerNeeded -= suitableRobots[i].BatteryLevel;
                    suitableRobots[i].ExecuteService(suitableRobots[i].BatteryLevel);
                    robotsParticipated++;
                }
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotsParticipated);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            foreach (var robot in _robots.Models()
                         .OrderByDescending(r => r.BatteryLevel)
                         .ThenBy(r => r.BatteryCapacity))
            {
                report.AppendLine(robot.ToString());
            }

            return report.ToString().TrimEnd();
        }
    }
}
