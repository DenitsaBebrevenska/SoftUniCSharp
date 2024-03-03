using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Text;

namespace Handball.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string _name;
        private double _rating;
        protected Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                _name = value;
            }
        }

        public double Rating
        {
            get => _rating;
            protected set
            {
                if (value < 1)
                {
                    _rating = 1;
                }
                else if (value > 10)
                {
                    _rating = 10;
                }
                else
                {
                    _rating = value;
                }
            }
        }


        public string Team { get; private set; }
        public void JoinTeam(string name)
         => Team = name;

        public abstract void IncreaseRating();

        public abstract void DecreaseRating();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}: {Name}");
            sb.AppendLine($"--Rating: {Rating}");

            return sb.ToString().TrimEnd();
        }
    }
}
