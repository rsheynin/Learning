using System;
using System.Collections.Generic;
using Autofac;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiFair.Application;
using TaxiFair.Application.IoC;
using TaxiFair.Domain;
using TaxiFair.Domain.Repository;
using TaxiFair.Domain.Services;
using TaxiFair.Infrastructure;

namespace TaxiFareIntegrationTests
{
    [TestClass]
    public class TaxiFairApplicationServiceTest
    {
        private TaxiFairApplicationService _target;
        private IFareRateRepository _stubFareRateRepository;
        private ICompanyFeeRepository _stubCompanyFeeRepository;
        private ICarRepository _stubCarRepository;
        private IFareRateService _fareRateService;
        private ITaxiFairCalculatorService _taxiFairCalculatorService;
        private IDateTimeWrapper _stubDateTimeWrapper;
        private FareRateDto _fakeFareRateDto = new FareRateDto(10, "license");

        private DateTime _fakeDayDate = new DateTime(2019, 01, 15, 15, 00, 00);
        private DateTime _fakeNightDate = new DateTime(2019, 01, 15, 23, 00, 00);


        private static readonly TimeSpan _fakeMorningTimeSpan = new TimeSpan(8, 0, 0);
        private static readonly TimeSpan _fakeEveningTimeStamp = new TimeSpan(20, 0, 0);

        private static FareRate _fakeDayFareRate = new FareRate("Day", 1, _fakeMorningTimeSpan, _fakeEveningTimeStamp);

        private static FareRate _fakeNightFareRate = new FareRate("Day", 1.5, _fakeEveningTimeStamp, _fakeMorningTimeSpan);
        
        private IEnumerable<FareRate> _fakeAllFareRates = new List<FareRate>
        {
            _fakeDayFareRate, _fakeNightFareRate
        };

        [TestInitialize]
        public void InIt()
        {

            var builder = new ContainerBuilder();

            builder.RegisterModule(new TaxiFairIoCModule());
            var container = builder.Build();

            _fareRateService = container.Resolve<IFareRateService>();
            _taxiFairCalculatorService = container.Resolve<ITaxiFairCalculatorService>();

            _stubFareRateRepository = A.Fake<IFareRateRepository>();
            _stubCompanyFeeRepository = A.Fake<ICompanyFeeRepository>();
            _stubCarRepository = A.Fake<ICarRepository>();
            _stubDateTimeWrapper = A.Fake<IDateTimeWrapper>();

            _target = new TaxiFairApplicationService(_stubFareRateRepository,
                _stubCompanyFeeRepository,
                _stubCarRepository,
                _fareRateService,
                _taxiFairCalculatorService,
                _stubDateTimeWrapper);
        }

        [TestMethod]
        public void Calculate_DayRate_ReturnRate()
        {
            A.CallTo(() => _stubDateTimeWrapper.Now()).Returns(_fakeDayDate);

            A.CallTo(() => _stubFareRateRepository.GetAll()).Returns(_fakeAllFareRates);

            var actual = _target.Calculate(_fakeFareRateDto);
            var expected = 10;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculate_NightRate_ReturnRate()
        {
            A.CallTo(() => _stubDateTimeWrapper.Now()).Returns(_fakeNightDate);

            A.CallTo(() => _stubFareRateRepository.GetAll()).Returns(_fakeAllFareRates);

            var actual = _target.Calculate(_fakeFareRateDto);
            var expected = 15;
            Assert.AreEqual(expected, actual);
        }
    }
}
