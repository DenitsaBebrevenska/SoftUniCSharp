using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int GetDifferenceInDays(string firstDate, string secondDate)
        {
            TimeSpan difference = DateTime.ParseExact(firstDate, "yyyy MM dd", null) -
                                  DateTime.ParseExact(secondDate, "yyyy MM dd", null);

            return Math.Abs(difference.Days);
        }
    }
}
