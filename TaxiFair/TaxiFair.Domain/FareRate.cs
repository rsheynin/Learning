using System;

namespace TaxiFair.Domain
{
    public class FareRate
    {
        public FareRate(string name,double rate,
            TimeSpan startTime, TimeSpan endTime)
        {
            Name = name;
            Rate = rate;
            StartTime = startTime;
            EndTime = endTime;
        }

        public string Name { get; }

        public double Rate { get; }

        public TimeSpan StartTime { get; }

        public TimeSpan EndTime { get; }
    }
}