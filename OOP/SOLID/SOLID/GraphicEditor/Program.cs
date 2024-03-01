namespace GraphicEditor
{
    public class Program
    {
        static void Main()
        {
            List<IShape> shapes = new List<IShape>()
            {
                new Circle(),
                new Square(),
                new Rectangle()
            };

            GraphicEditor ge = new GraphicEditor();

            foreach (var shape in shapes)
            {
                ge.DrawShape(shape);
            }
        }
    }
}
