namespace Cars
{
    public interface ICar
    {
        string Model { set; }
        string Color { set; }

        string Start();
        string Stop();
    }
}
