using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        public double Length
        {
            get => length;
            private set
            {
                CheckInputPropertyValue(value, nameof(Length));

                length = value;
            }
        }

        private double width;
        public double Width
        {
            get => width;
            private set
            {
                CheckInputPropertyValue(value, nameof(Width));
                width = value;
            }
        }

        private double height;
        public double Height
        {
            get => height;
            private set
            {
                CheckInputPropertyValue(value, nameof(Height));
                height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        private double SurfaceArea() => 2 * length * width + 2 * length * height + 2 * width * height;

        private double LateralSurfaceArea() => 2 * length * height + 2 * width * height;

        private double Volume() => length * width * height;

        private static void CheckInputPropertyValue(double value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{propertyName} cannot be zero or negative.");
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {Volume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
