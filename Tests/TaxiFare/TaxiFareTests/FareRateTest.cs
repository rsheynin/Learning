using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiFair.Domain;
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

        private readonly List<FareRate> _fakeFareRates = new List<FareRate>();

        [TestInitialize]
        public void InIt()
        {
            _target = new FareRateService();
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetRate_DaytimeMissingFareRateTimeRange_Throw()
        {
            _target.GetRate(Dummy.DayTimeSpan, _fakeFareRates);
        }
        
        [TestMethod]
        public void GetRate_Daytime_ReturnRate()
        {
            _fakeFareRates.Add(Dummy.FareRateDay);
            
            var actual = _target.GetRate(Dummy.DayTimeSpan, _fakeFareRates);

            actual.Should().Be(_expectedDayFareRate);
        }

        [TestMethod]
        public void GetRate_NightAndDayRateHightTime_ReturnNightRate()
        {
            _fakeFareRates.Add(Dummy.FareRateDay);
            _fakeFareRates.Add(Dummy.FareRateNight);
            
            var actual = _target.GetRate(Dummy.NightTimeSpan, _fakeFareRates);

            actual.Should().Be(_expectedNightFareRate);
        }
    }
}