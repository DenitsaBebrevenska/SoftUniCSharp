using MyLogger.Core;
using MyLogger.Core.Contracts;

namespace MyLogger
{
    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
