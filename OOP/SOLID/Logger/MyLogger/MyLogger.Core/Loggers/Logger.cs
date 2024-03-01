using MyLogger.Core.Appenders.Contracts;
using MyLogger.Core.Enums;
using MyLogger.Core.Loggers.Contracts;
using MyLogger.Core.Models;

namespace MyLogger.Core.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string dateAndTime, string text)
            => AppendAll(dateAndTime, text, ReportLevel.Info);

        public void Warning(string dateAndTime, string text)
            => AppendAll(dateAndTime, text, ReportLevel.Warning);

        public void Error(string dateAndTime, string text)
            => AppendAll(dateAndTime, text, ReportLevel.Error);

        public void Critical(string dateAndTime, string text)
        => AppendAll(dateAndTime, text, ReportLevel.Critical);

        public void Fatal(string dateAndTime, string text)
            => AppendAll(dateAndTime, text, ReportLevel.Fatal);

        private void AppendAll(string dateAndTime, string text, ReportLevel reportLevel)
        {
            Message message = new(dateAndTime, text, reportLevel);

            foreach (var appender in appenders)
            {
                if (message.ReportLevel >= appender.ReportLevel)
                {
                    appender.AppendMessage(message);
                }
            }
        }
    }
}
