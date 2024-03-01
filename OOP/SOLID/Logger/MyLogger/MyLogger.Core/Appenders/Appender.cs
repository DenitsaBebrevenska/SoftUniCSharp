using MyLogger.Core.Appenders.Contracts;
using MyLogger.Core.Enums;
using MyLogger.Core.Layouts.Contracts;
using MyLogger.Core.Models;

namespace MyLogger.Core.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            Layout = layout;
            ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }
        public ReportLevel ReportLevel { get; set; }
        public int MessagesAppended { get; protected set; }
        public abstract void AppendMessage(Message message);

        public override string ToString()
            => $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}," +
               $" Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesAppended}";
    }
}
