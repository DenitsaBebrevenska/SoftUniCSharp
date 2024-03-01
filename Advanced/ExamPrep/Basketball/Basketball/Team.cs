using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        public IReadOnlyCollection<Player> Players => players.AsReadOnly();
        public string Name { get; private set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();
        }

        public int Count => players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrWhiteSpace(player.Name) || string.IsNullOrWhiteSpace(player.Position))
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            OpenPositions--;
            players.Add(player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            Player player = players.FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                OpenPositions++;
                players.Remove(player);
                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = players.Count(p => p.Position == position);
            players.RemoveAll(p => p.Position == position);
            OpenPositions += count;
            return count;
        }

        public Player RetirePlayer(string name)
        {
            Player player = players.FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                player.Retired = true;
            }

            return player;
        }

        public List<Player> AwardPlayers(int games) => players.FindAll(p => p.Games >= games);

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in players.Where(p => p.Retired == false))
            {
                reportBuilder.AppendLine(player.ToString());
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }
}
