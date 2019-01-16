using System;
using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiFair.Domain;
using TaxiFair.Domain.Repository;
using TaxiFair.Domain.Services;

namespace TaxiFareTests
{
    [TestClass]
    public class FareRateTest
    {
        private FareRateService _target;
        private readonly TimeSpan _fakeDayTimeSpan = new TimeSpan(13,0,0);
        private readonly TimeSpan _fakeNightTimeSpan = new TimeSpan(23,0,0);
        private double _expectedDayFareRate = 1.5;
        private double _expectedNightFareRate = 2;
        private IFareRateRepository _stubFareRateRepository;

        private static readonly TimeSpan _fakeMorningTimeSpan = new TimeSpan(8,0,0);
        private static readonly TimeSpan _fakeEveningTimeStamp = new TimeSpan(20, 0, 0);

        private static readonly FareRate _fareRateDay = 
            new FareRate("Day", 1.5, _fakeMorningTimeSpan, _fakeEveningTimeStamp);
        private static readonly FareRate _fareRateNight = 
            new FareRate("Day", 2, _fakeEveningTimeStamp, _fakeMorningTimeSpan);

        private readonly List<FareRate> _fakeFareRates = new List<FareRate>();
        
        [TestInitialize]
        public void InIt()
        {
            _stubFareRateRepository = A.Fake<IFareRateRepository>();

            _target = new FareRateService();
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetRate_DaytimeMissingFareRateTimeRange_Throw()
        {
            _target.GetRate(_fakeDayTimeSpan, _fakeFareRates);
        }
        
        [TestMethod]
        public void GetRate_Daytime_ReturnRate()
        {
            _fakeFareRates.Add(_fareRateDay);
            
            var actual = _target.GetRate(_fakeDayTimeSpan, _fakeFareRates);

            actual.Should().Be(_expectedDayFareRate);
        }

        [TestMethod]
        public void GetRate_NightAndDayRateHightTime_ReturnNightRate()
        {
            _fakeFareRates.Add(_fareRateDay);
            _fakeFareRates.Add(_fareRateNight);
            
            var actual = _target.GetRate(_fakeNightTimeSpan, _fakeFareRates);

            actual.Should().Be(_expectedNightFareRate);
        }
    }
}