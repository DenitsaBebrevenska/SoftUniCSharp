using MyLogger.Core.Appenders;
using MyLogger.Core.Appenders.Contracts;
using MyLogger.Core.Enums;
using MyLogger.Core.IO.Contracts;
using MyLogger.Core.Layouts.Contracts;
using MyLogger.Factories.Contracts;

namespace MyLogger.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel, ILogFile logFile = null)
        {
            switch (type)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, reportLevel);
                case "FileAppender":
                    return new FileAppender(layout, logFile, reportLevel);
                default:
                    throw new InvalidOperationException("Invalid appender type");
            }
        }
    }
}
