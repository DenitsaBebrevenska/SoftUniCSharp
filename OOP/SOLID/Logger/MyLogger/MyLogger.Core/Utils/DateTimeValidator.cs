using System.Globalization;

namespace MyLogger.Core.Utils
{
    public static class DateTimeValidator
    {
        private static readonly ISet<string> Formats = new HashSet<string> { "M/dd/yyyy h:mm:ss tt" };
        //could be extended - add private method for adding formats, keep them in file so they don`t get erased when closing the program
        public static bool ValidateDateTimeFormat(string dateAndTime)
        {
            foreach (var format in Formats)
            {
                if (DateTime.TryParseExact(dateAndTime, format,
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
