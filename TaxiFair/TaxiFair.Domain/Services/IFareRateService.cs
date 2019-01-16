using System;
using System.Collections.Generic;

namespace TaxiFair.Domain.Services
{
    public interface IFareRateService
    {
        double GetRate(TimeSpan timeSpan, IEnumerable<FareRate> fareRates);
    }
}