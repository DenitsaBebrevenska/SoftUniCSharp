using SoftuniDi.Loggers.Contracts;

namespace SoftuniDi.Loggers;
public class FileLogger : ILogger
{
    public void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter("../../../logs.txt", true))
        {
            writer.WriteLine($"{DateTime.Now}:{message}");
        }
    }
}
