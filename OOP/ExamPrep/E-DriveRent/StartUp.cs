namespace EDriveRent
{
    using EDriveRent.Core;
    using EDriveRent.Core.Contracts;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
