namespace MyLogger.Core.Loggers.Contracts
{
    public interface ILogger
    {
        void Info(string dateAndTime, string text);
        void Warning(string dateAndTime, string text);
        void Error(string dateAndTime, string text);
        void Critical(string dateAndTime, string text);
        void Fatal(string dateAndTime, string text);

    }
}
