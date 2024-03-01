using System.Text;

namespace Basketball
{
    public class Player
    {
        public string Name { get; private set; }
        public string Position { get; private set; }
        public double Rating { get; set; }
        public int Games { get; set; }
        public bool Retired { get; set; }

        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
            Retired = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Player: {Name}");
            sb.AppendLine($"--Position: {Position}");
            sb.AppendLine($"--Rating: {Rating}");
            sb.AppendLine($"--Games played: {Games}");

            return sb.ToString().TrimEnd();
        }
    }
}
