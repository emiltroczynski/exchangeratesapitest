using System;

namespace TaskFromGain.Helpers
{
    class DateHelper
    {
        internal static DateTime GetLastBusinessDay(DateTime dateTime)
        {
            if (dateTime.Hour < 16)
            {
                dateTime = dateTime.AddDays(-1);
            }

            dateTime = dateTime.Date;

            if (dateTime.Month == 12 && dateTime.Day == 25)
            {
                dateTime = dateTime.AddDays(-1);
            }

            if (dateTime.Month == 12 && dateTime.Day == 26)
            {
                dateTime = dateTime.AddDays(-2);
            }

            if (dateTime.DayOfWeek == DayOfWeek.Saturday)
            {
                dateTime = dateTime.AddDays(-1);
            }

            if (dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                dateTime = dateTime.AddDays(-2);
            }

            //TODO: add holidays
            /* 
             * for 2020 there are 6 closing days:
             * New Year's Day* 	1 January 2020
             * Good Friday* 10 April 2020
             * Easter Monday* 13 April 2020
             * Labour Day* 1 May 2020
             * Christmas Day* 25 December 2020
             * Christmas Holiday* 26 December 2020
             * Some days are fixed, some are random.
             * I added validation for Christmas, 
             * but I think better solution would be a list with holidays
             */
            return dateTime;
        }
    }
}
