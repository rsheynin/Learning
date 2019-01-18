using System;
using System.Collections.Generic;
using TaxiFair.Domain;

namespace TaxiFairDummy
{
    public static class Dummy
    {
        public const string FAKE_LICENSE = "License";
        public const string DRIVER_NAME = "DriverName";
        public const string OWNER_NAME = "OwnerName";
        public const string COMPANY_NAME = "companyName";

        public const double DAY_RATE = 1.5;
        public const double NIGHT_RATE = 2;
        public const double COMPANY_FEE_5 = 5;
        public const double COMPANY_FEE_3 = 3;
        public const double DISTANCE = 10;

        public static FareRateDto FareRateDto;
        public static IEnumerable<FareRate> AllFareRates = new List<FareRate>();
        public static Car Car;
        public static CompanyFee Fee;
        public static TaxiFairDto TaxiFairDto;

        public static TimeSpan DayTimeSpan = new TimeSpan(13, 0, 0);
        public static TimeSpan NightTimeSpan = new TimeSpan(23, 0, 0);

        public static readonly TimeSpan MorningTimeSpan = new TimeSpan(8, 0, 0);
        public static readonly TimeSpan EveningTimeStamp = new TimeSpan(20, 0, 0);

        public static DateTime DayDate = new DateTime(2019, 01, 15, 15, 00, 00);
        private static DateTime NightDate = new DateTime(2019, 01, 23, 15, 00, 00);

        public static readonly FareRate FareRateDay =
            new FareRate("Day", 1.5, MorningTimeSpan, EveningTimeStamp);

        public static readonly FareRate FareRateNight =
            new FareRate("Day", 2, EveningTimeStamp, MorningTimeSpan);

    }
}
