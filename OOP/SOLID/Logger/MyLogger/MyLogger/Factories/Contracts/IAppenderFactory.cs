using MyLogger.Core.Appenders.Contracts;
using MyLogger.Core.Enums;
using MyLogger.Core.IO.Contracts;
using MyLogger.Core.Layouts.Contracts;

namespace MyLogger.Factories.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel, ILogFile logFile = null);
    }
}
