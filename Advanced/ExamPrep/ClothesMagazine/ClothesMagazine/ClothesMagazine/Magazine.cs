using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public string Type { get; private set; }
        public int Capacity { get; private set; }
        public List<Cloth> Clothes { get; private set; }

        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            Cloth cloth = Clothes.FirstOrDefault(c => c.Color == color);

            if (cloth != null)
            {
                Clothes.Remove(cloth);
                return true;
            }

            return false;
        }

        public Cloth GetSmallestCloth() => Clothes.OrderBy(c => c.Size).First();
        public Cloth GetCloth(string color) => Clothes.FirstOrDefault(c => c.Color == color);
        public int GetClothCount() => Clothes.Count;

        public string Report()
        {
            StringBuilder reportBuilder = new();
            reportBuilder.AppendLine($"{Type} magazine contains:");

            foreach (var cloth in Clothes.OrderBy(c => c.Size))
            {
                reportBuilder.AppendLine(cloth.ToString());
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }
}
