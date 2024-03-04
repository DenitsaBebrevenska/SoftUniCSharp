using Handball.Models.Contracts;
using Handball.Models.Players;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string _name;
        private List<IPlayer> _players;
        public Team(string name)
        {
            Name = name;
            PointsEarned = 0;
            _players = new List<IPlayer>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                _name = value;
            }
        }
        public int PointsEarned { get; private set; }

        public double OverallRating
        {
            get
            {
                if (_players.Count == 0)
                    return 0;
                return Math.Round(_players.Average(p => p.Rating), 2);
            }
        }

        public IReadOnlyCollection<IPlayer> Players => _players.AsReadOnly();

        public void SignContract(IPlayer player)
            => _players.Add(player);

        public void Win()
        {
            PointsEarned += 3;
            _players.ForEach(p => p.IncreaseRating());
        }

        public void Lose()
            => _players.ForEach(p => p.DecreaseRating());

        public void Draw()
        {
            PointsEarned++;
            _players.First(p => p.GetType().Name == nameof(Goalkeeper)).IncreaseRating();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");

            if (_players.Count == 0)
            {
                sb.AppendLine("--Players: none");
            }
            else
            {
                sb.AppendLine($"--Players: {string.Join(", ", _players.Select(p => p.Name))}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
