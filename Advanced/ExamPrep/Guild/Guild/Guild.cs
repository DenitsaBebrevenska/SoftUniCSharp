using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                roster.Remove(player);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                if (player.Rank != "Member")
                {
                    player.Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                if (player.Rank != "Trial")
                {
                    player.Rank = "Trial";
                }
            }
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            Player[] kickedPlayers = roster.Where(p => p.Class == playerClass).ToArray();
            roster.RemoveAll(p => p.Class == playerClass);
            return kickedPlayers;
        }

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"Players in the guild: {Name}");
            roster.ForEach(p => reportBuilder.AppendLine(p.ToString()));
            return reportBuilder.ToString().TrimEnd();
        }
    }
}
