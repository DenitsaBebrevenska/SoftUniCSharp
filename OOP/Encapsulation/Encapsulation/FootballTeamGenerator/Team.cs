namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players = new List<Player>();
        public Team(string name)
        {
            Name = name;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public int Rating => (int)Math.Round(CalculateRating());

        public IReadOnlyList<Player> Players => players.AsReadOnly();
        private double CalculateRating()
        {
            if (players.Count == 0)
            {
                return 0;
            }

            return players.Sum(p => p.SkillLevel) / players.Count;

        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                Console.WriteLine($"Player {playerName} is not in {Name} team.");
                return;
            }

            players.Remove(player);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
