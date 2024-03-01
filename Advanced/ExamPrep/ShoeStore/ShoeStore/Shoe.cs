namespace ShoeStore
{
    public class Shoe
    {
        public string Brand { get; private set; }
        public string Type { get; private set; }
        public double Size { get; private set; }
        public string Material { get; private set; }

        public Shoe(string brand, string type, double size, string material)
        {
            Brand = brand;
            Type = type;
            Size = size;
            Material = material;
        }

        public override string ToString() => $"Size {Size}, {Material} {Brand} {Type} shoe.";
    }
}
