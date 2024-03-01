namespace Composite.Shapes;
public class Line : Shape
{
    public Line(Position position, int size) : base(position)
    {
        Size = size;
    }

    public int Size { get; set; }
    public override void Draw()
    {
        base.Draw();

        SetCursorPosition();

        for (int i = 0; i < Size; i++)
        {
            Console.Write("-");

        }
    }
}
