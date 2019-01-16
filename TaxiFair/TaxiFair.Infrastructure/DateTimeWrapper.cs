using System;

namespace TaxiFair.Infrastructure
{
    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}