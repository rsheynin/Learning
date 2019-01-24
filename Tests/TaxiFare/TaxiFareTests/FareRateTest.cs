using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiFair.Domain.Services;
using TaxiFairDummy;

namespace TaxiFareTests
{
    [TestClass]
    public class FareRateTest
    {
        private FareRateService _target;
        private double _expectedDayFareRate = 1.5;
        private double _expectedNightFareRate = 2;


        [TestInitialize]
        public void InIt()
        {
            _target = new FareRateService();
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetRate_DaytimeMissingFareRateTimeRange_Throw()
        {
            _target.GetRate(Dummy.DayTimeSpan, Dummy.FareRatesEmptyList);
        }
        
        [TestMethod]
        public void GetRate_Daytime_ReturnRate()
        {
            var actual = _target.GetRate(Dummy.DayTimeSpan, Dummy.AllFareRates);

            actual.Should().Be(_expectedDayFareRate);
        }

        [TestMethod]
        public void GetRate_NightAndDayRateNightTime_ReturnNightRate()
        {
            var actual = _target.GetRate(Dummy.NightTimeSpan, Dummy.AllFareRates);

            actual.Should().Be(_expectedNightFareRate);
        }
    }
}