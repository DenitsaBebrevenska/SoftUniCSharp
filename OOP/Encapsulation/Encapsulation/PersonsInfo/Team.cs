namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public string Name { get; private set; }
        public IReadOnlyCollection<Person> FirstTeam => firstTeam.AsReadOnly();
        public IReadOnlyCollection<Person> ReserveTeam => reserveTeam.AsReadOnly();
        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            return $"First team has {firstTeam.Count} players.{Environment.NewLine}" +
                   $"Reserve team has {reserveTeam.Count} players.";
        }
    }
}
