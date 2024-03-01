namespace ClothesMagazine
{
    public class Cloth
    {
        public string Color { get; private set; }
        public int Size { get; private set; }
        public string Type { get; private set; }

        public Cloth(string color, int size, string type)
        {
            Color = color;
            Size = size;
            Type = type;
        }

        public override string ToString() => $"Product: {Type} with size {Size}, color {Color}";
    }
}
