using MyLogger.Core.Enums;
using MyLogger.Core.IO.Contracts;
using MyLogger.Core.Layouts.Contracts;
using MyLogger.Core.Models;

namespace MyLogger.Core.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, ILogFile logfile, ReportLevel reportLevel = ReportLevel.Info)
        : base(layout, reportLevel)
        {
            LogFile = logfile;
        }
        public ILogFile LogFile { get; private set; }
        public override void AppendMessage(Message message)
        {
            string content = string.Format(Layout.Format, message.DateAndTime, message.ReportLevel, message.Text) + Environment.NewLine;
            File.AppendAllText(LogFile.FullPath, content);
            MessagesAppended++;
        }

        public override string ToString() => base.ToString() + $", File size {LogFile.Size}";
    }
}
