using MyLogger.Core.Enums;
using MyLogger.Core.Layouts.Contracts;
using MyLogger.Core.Models;

namespace MyLogger.Core.Appenders.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }
        int MessagesAppended { get; }
        void AppendMessage(Message message);
    }
}
