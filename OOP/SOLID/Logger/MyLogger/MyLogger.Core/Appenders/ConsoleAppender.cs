using MyLogger.Core.Enums;
using MyLogger.Core.Layouts.Contracts;
using MyLogger.Core.Models;

namespace MyLogger.Core.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
            : base(layout, reportLevel)
        {
        }
        public override void AppendMessage(Message message)
        {
            Console.WriteLine(string.Format(Layout.Format, message.DateAndTime, message.ReportLevel, message.Text));
            MessagesAppended++;
        }


    }
}
