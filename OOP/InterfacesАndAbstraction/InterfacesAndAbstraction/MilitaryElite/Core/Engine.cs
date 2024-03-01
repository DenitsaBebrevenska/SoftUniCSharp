using MilitaryElite.Core.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private List<Private> privatesAdded = new();
        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] inputDetails = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(ProcessInput(inputDetails));
                }
                catch (Exception e)
                { }
            }
        }

        private string ProcessInput(string[] inputDetails)
        {
            string rank = inputDetails[0];
            string id = inputDetails[1];
            string firstName = inputDetails[2];
            string lastName = inputDetails[3];
            ISoldier currentSoldier = null;

            switch (rank)
            {
                case "Private":
                    currentSoldier = new Private(id, firstName, lastName, decimal.Parse(inputDetails[4]));
                    privatesAdded.Add((Private)currentSoldier);
                    break;
                case "LieutenantGeneral":
                    currentSoldier = new LieutenantGeneral(id, firstName, lastName, decimal.Parse(inputDetails[4]),
                        GetPrivatesList(inputDetails));
                    break;
                case "Engineer":
                    currentSoldier = new Engineer(id, firstName, lastName, decimal.Parse(inputDetails[4]), GetCorps(inputDetails[5]),
                        GetRepairsList(inputDetails));
                    break;
                case "Commando":
                    currentSoldier = new Commando(id, firstName, lastName, decimal.Parse(inputDetails[4]),
                        GetCorps(inputDetails[5]),
                        GetMissionsList(inputDetails));
                    break;
                case "Spy":
                    currentSoldier = new Spy(id, firstName, lastName, int.Parse(inputDetails[4]));
                    break;
            }

            return currentSoldier.ToString();
        }

        private List<Mission> GetMissionsList(string[] inputDetails)
        {
            inputDetails = inputDetails.Skip(6).ToArray();
            List<Mission> missionList = new();

            for (int i = 0; i < inputDetails.Length - 1; i += 2)
            {
                bool isValidMissionState = Enum.TryParse(inputDetails[i + 1], out MissionState state);

                if (!isValidMissionState)
                {
                    continue;
                }

                missionList.Add(new Mission(inputDetails[i], state));
            }

            return missionList;
        }

        private List<Repair> GetRepairsList(string[] inputDetails)
        {
            inputDetails = inputDetails.Skip(6).ToArray();
            List<Repair> repairList = new();

            for (int i = 0; i < inputDetails.Length - 1; i += 2)
            {
                repairList.Add(new Repair(inputDetails[i], int.Parse(inputDetails[i + 1])));
            }

            return repairList;
        }

        private List<Private> GetPrivatesList(string[] inputDetails)
        {
            inputDetails = inputDetails.Skip(5).ToArray();
            List<Private> privates = new List<Private>();

            for (int i = 0; i < inputDetails.Length; i++)
            {
                Private currentPrivate = privatesAdded.FirstOrDefault(p => p.Id == inputDetails[i]);

                if (currentPrivate != null)
                {
                    privates.Add(currentPrivate);
                }
            }
            return privates;
        }

        private Corps GetCorps(string corpsInput)
        {
            bool isValidCorps = Enum.TryParse(corpsInput, out Corps corps);

            if (!isValidCorps)
            {
                throw new Exception();
            }

            return corps;
        }
    }
}
