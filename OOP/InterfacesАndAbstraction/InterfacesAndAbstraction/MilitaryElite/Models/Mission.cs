using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    public class Mission
    {
        public string CodeName { get; }

        public MissionState State { get; private set; }

        public void CompleteMission()
        {
            State = MissionState.Finished;
        }
        public Mission(string codeName, MissionState state)
        {
            CodeName = codeName;
            State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
