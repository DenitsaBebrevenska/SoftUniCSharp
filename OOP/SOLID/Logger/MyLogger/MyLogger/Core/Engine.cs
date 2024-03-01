using MyLogger.Core.Appenders.Contracts;
using MyLogger.Core.Contracts;
using MyLogger.Core.Enums;
using MyLogger.Core.IO;
using MyLogger.Core.IO.Contracts;
using MyLogger.Core.Layouts.Contracts;
using MyLogger.Core.Loggers;
using MyLogger.Core.Loggers.Contracts;
using MyLogger.Factories;
using MyLogger.Factories.Contracts;
using System.Text;

namespace MyLogger.Core
{
    public class Engine : IEngine
    {
        private readonly IAppenderFactory appenderFactory;
        private readonly ILayoutFactory layoutFactory;
        private readonly ICollection<IAppender> appenders;
        private ILogger logger;

        public Engine()
        {
            appenderFactory = new AppenderFactory();
            layoutFactory = new LayoutFactory();
            appenders = new HashSet<IAppender>();
        }
        public void Run()
        {
            CreateAppenders();
            logger = new Logger(appenders);

            LogMessages();

            Console.WriteLine(GetLoggerInfo());
        }

        private void CreateAppenders()
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfAppenders; i++)
            {
                try
                {
                    string[] appenderDetails = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string type = appenderDetails[0];
                    string layoutType = appenderDetails[1];

                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    ReportLevel reportLevel = ReportLevel.Info;

                    if (appenderDetails.Length == 3)
                    {
                        bool isValidReportLevel = Enum.TryParse(appenderDetails[2], true, out reportLevel);

                        if (!isValidReportLevel)
                        {
                            throw new InvalidOperationException("Report level is not valid!");
                        }
                    }

                    IAppender appender = null;

                    if (type == "FileAppender")
                    {
                        ILogFile logFile = new LogFile("xml");
                        appender = appenderFactory.CreateAppender(type, layout, reportLevel, logFile);
                    }
                    else
                    {
                        appender = appenderFactory.CreateAppender(type, layout, reportLevel);
                    }

                    appenders.Add(appender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void LogMessages()
        {
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split('|');
                string reportLevel = commandArgs[0];
                string dateAndTime = commandArgs[1];
                string message = commandArgs[2];

                try
                {
                    switch (reportLevel)
                    {
                        case "INFO":
                            logger.Info(dateAndTime, message);
                            break;
                        case "WARNING":
                            logger.Warning(dateAndTime, message);
                            break;
                        case "ERROR":
                            logger.Error(dateAndTime, message);
                            break;
                        case "CRITICAL":
                            logger.Critical(dateAndTime, message);
                            break;
                        case "FATAL":
                            logger.Fatal(dateAndTime, message);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string GetLoggerInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");

            foreach (var appender in appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
