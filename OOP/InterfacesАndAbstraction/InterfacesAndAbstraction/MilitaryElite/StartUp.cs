using MilitaryElite.Core;
using MilitaryElite.Core.Contracts;

namespace MilitaryElite
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
