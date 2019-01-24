using System;
using System.Collections.Generic;
using TaxiFair.Domain;

namespace TaxiFairDummy
{
    public static class Dummy
    {
        public const string LICENSE = "License";
        public const string LICENSE1 = "License1";
        public const string LICENSE2 = "License2";
        public const string DRIVER_NAME = "DriverName";
        public const string OWNER_NAME = "OwnerName";
        public const string COMPANY_NAME = "companyName";
        public const string COMPANY_NAME1 = "companyName1";
        public const string COMPANY_NAME2 = "companyName2";

        public const double DAY_RATE = 1.5;
        public const double NIGHT_RATE = 2;
        public const double COMPANY_FEE_5 = 5;
        public const double COMPANY_FEE_3 = 3;
        public const double COMPANY_FEE0 = 0;
        public const double COMPANY_FEE1 = 1;
        public const double COMPANY_FEE2 = 2;
        public const double DISTANCE = 10;

        public static FareRateDto FareRateDto;
        public static FareRateDto FareRateDto_Distance_10 = new FareRateDto(10, LICENSE);
        public static FareRateDto FareRateDto_Distance_10_Licence_1 = new FareRateDto(DISTANCE, LICENSE1);
        public static FareRateDto FareRateDto_Distance_10_Licence_2 = new FareRateDto(DISTANCE, LICENSE2);



        public static Car Car = new Car(LICENSE, DRIVER_NAME, OWNER_NAME, COMPANY_NAME);
        public static Car Car1 = new Car(LICENSE1,DRIVER_NAME,OWNER_NAME,COMPANY_NAME1);
        public static Car Car2 = new Car(LICENSE2, DRIVER_NAME, OWNER_NAME, COMPANY_NAME2);

        public static CompanyFee CompanyFee;
        public static CompanyFee CompanyFee1 = new CompanyFee(COMPANY_NAME1, COMPANY_FEE1);
        public static CompanyFee CompanyFee2 = new CompanyFee(COMPANY_NAME2, COMPANY_FEE2);
        public static CompanyFee CompanyFee3 = new CompanyFee(COMPANY_NAME, COMPANY_FEE0);

        public static IEnumerable<CompanyFee> CompanyFees = new List<CompanyFee>
        {
            CompanyFee1,CompanyFee2
        };


        public static TaxiFairDto TaxiFairDto;

        public static TimeSpan DayTimeSpan = new TimeSpan(15, 0, 0);
        public static TimeSpan NightTimeSpan = new TimeSpan(23, 0, 0);

        public static readonly TimeSpan MorningTimeSpan = new TimeSpan(8, 0, 0);
        public static readonly TimeSpan EveningTimeStamp = new TimeSpan(20, 0, 0);

        public static DateTime DayDate = new DateTime(2019, 01, 15, 15, 00, 00);
        public static DateTime NightDate = new DateTime(2019, 01, 23, 23, 00, 00);

        public static readonly FareRate FareRateDayZero =
            new FareRate("Day", 0, MorningTimeSpan, EveningTimeStamp);

        public static readonly FareRate FareRateDay =
            new FareRate("Day", 1.5, MorningTimeSpan, EveningTimeStamp);

        public static readonly FareRate FareRateNight =
            new FareRate("Night", 2, EveningTimeStamp, MorningTimeSpan);

        public static IEnumerable<FareRate> FareRatesEmptyList = new List<FareRate>();

        public static IEnumerable<FareRate> AllFareRates = new List<FareRate>
        {
            FareRateDay, FareRateNight
        };
        public static IEnumerable<FareRate> AllFareRatesDayIsZero = new List<FareRate>
        {
            FareRateDayZero, FareRateNight
        };

    }
}
