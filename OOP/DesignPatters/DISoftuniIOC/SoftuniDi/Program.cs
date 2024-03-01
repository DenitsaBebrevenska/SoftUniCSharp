using SoftuniDi.Loggers;
using SoftuniDi.Loggers.Contracts;
using SoftuniDi.Models;
using SoftuniDi.Models.Contracts;
using SoftuniDi.Renderers;
using SoftuniDi.Renderers.Contracts;

ServiceCollection collection = new ServiceCollection();

collection.AddSingleton<ILogger, ConsoleLogger>();
collection.AddSingleton<DB, DB>();
collection.AddSingleton(typeof(IRenderer), typeof(ConsoleRenderer));
collection.AddSingleton<DateTime, DateTime>((IServiceProviderr sp) =>
{
    return new DateTime(1997, 11, 10);
});
IServiceProviderr provider = collection.BuildServiceProvider();


ILogger logger = provider.GetRequiredService<ILogger>();

logger.Log("Hello from logger");


for (int i = 0; i < 10; i++)
{
    Console.WriteLine(provider.GetRequiredService<DB>().Guid);
}

class DB
{
    public Guid Guid { get; set; }

    public DB()
    {
        Guid = Guid.NewGuid();
    }
}