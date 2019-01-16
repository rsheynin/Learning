using System;

namespace TaxiFair.Domain
{
    public class FareRateDto
    {
        public FareRateDto(double distance,string license)
        {
            Distance = distance;
            License = license;
        }

        public FareRateDto(FareRateDto fareRateDto, DateTime date)
        {
            Distance = fareRateDto.Distance;
            License = fareRateDto.License;
            Date = date;
        }

        public FareRateDto(double distance, string license, DateTime date) : this(distance,license)
        {
            Date = date;
        }

        public double Distance { get; }

        public string License { get; }

        public DateTime Date { get; set; }
    }
}