using SoftuniDi.Loggers.Contracts;
using SoftuniDi.Renderers.Contracts;

namespace SoftuniDi.Loggers;
public class ConsoleLogger : ILogger
{
    public ConsoleLogger(IRenderer renderer, DateTime datetime)
    {
        renderer.WriteLine("Console Logger created!!!");
    }
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{DateTime.Now}:{message}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}