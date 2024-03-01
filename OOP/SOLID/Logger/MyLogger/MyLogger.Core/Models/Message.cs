using MyLogger.Core.Enums;
using MyLogger.Core.Exceptions;
using MyLogger.Core.Utils;

namespace MyLogger.Core.Models
{
    public class Message
    {
        private string dateAndTime;
        private string text;

        public Message(string dateAndTime, string text, ReportLevel reportLevel)
        {
            DateAndTime = dateAndTime;
            Text = text;
            ReportLevel = reportLevel;
        }

        public string DateAndTime
        {
            get => dateAndTime;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DataAndTimeEmptyException();
                }

                if (!DateTimeValidator.ValidateDateTimeFormat(value))
                {
                    throw new InvalidDateTimeFormatException();
                }
                dateAndTime = value;
            }
        }

        public string Text
        {
            get => text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyMessageTextException();
                }
                text = value;
            }
        }

        public ReportLevel ReportLevel { get; set; }
    }
}
