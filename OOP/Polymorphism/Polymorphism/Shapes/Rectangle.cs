namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea() => height * width;
        public override double CalculatePerimeter() => 2 * width + 2 * height;

        public override string Draw() => base.Draw() + nameof(Rectangle);
    }
}
