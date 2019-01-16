using System;
using System.Collections.Generic;

namespace TaxiFair.Domain.Services
{
    public class FareRateService : IFareRateService
    {
        public double GetRate(TimeSpan timeSpan, IEnumerable<FareRate> fareRates)
        {
            foreach (var fareRate in fareRates)
            {
                if (fareRate.EndTime > fareRate.StartTime)
                {
                    if (timeSpan >= fareRate.StartTime &&
                        timeSpan <= fareRate.EndTime)
                    {
                        return fareRate.Rate;
                    }
                }
                else
                {
                    if (timeSpan >= fareRate.EndTime ||
                        timeSpan <= fareRate.StartTime)
                    {
                        return fareRate.Rate;
                    }
                }
            }
            
            throw new ArgumentException("Wrong Date or missing fare rate time range.");
        }
    }
}