namespace Cards
{
    public class Card
    {
        private readonly string[] possibleFaceAnSuits
            = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "S", "H", "D", "C" };
        private Dictionary<string, string> symbolRepresentation = new()
        {
            {"S","\u2660"},
            {"H","\u2665"},
            {"D", "\u2666"},
            {"C", "\u2663"}
        };
        private string face;
        private string suit;
        private string symbol;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
            symbol = symbolRepresentation[Suit];
        }
        public string Face
        {
            get => face;
            init
            {
                if (!possibleFaceAnSuits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }
        }

        public string Suit
        {
            get => suit;
            init
            {
                if (!possibleFaceAnSuits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                suit = value;
            }
        }

        public override string ToString() => $"[{Face}{symbol}]";
    }
}
