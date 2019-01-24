using Autofac;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiFair.Application;
using TaxiFair.Application.IoC;
using TaxiFair.Domain.Repository;
using TaxiFair.Domain.Services;
using TaxiFair.Infrastructure;
using TaxiFairDummy;

namespace TaxiFareIntegrationTests
{
    [TestClass]
    public class TaxiFairApplicationServiceTest
    {
        private TaxiFairApplicationService _target;

        private IFareRateService _fareRateService;
        private ITaxiFairCalculatorService _taxiFairCalculatorService;

        private IFareRateRepository _fakeFareRateRepository;
        private ICompanyFeeRepository _fakeCompanyFeeRepository;
        private ICarRepository _fakeCarRepository;
        private IDateTimeWrapper _fakeDateTimeWrapper;

        [TestInitialize]
        public void InIt()
        {

            var builder = new ContainerBuilder();

            builder.RegisterModule(new TaxiFairIoCModule());
            var container = builder.Build();

            _fareRateService = container.Resolve<IFareRateService>();
            _taxiFairCalculatorService = container.Resolve<ITaxiFairCalculatorService>();

            _fakeFareRateRepository = A.Fake<IFareRateRepository>();
            _fakeCompanyFeeRepository = A.Fake<ICompanyFeeRepository>();
            _fakeCarRepository = A.Fake<ICarRepository>();
            _fakeDateTimeWrapper = A.Fake<IDateTimeWrapper>();

            _target = new TaxiFairApplicationService(_fakeFareRateRepository,
                _fakeCompanyFeeRepository,
                _fakeCarRepository,
                _fareRateService,
                _taxiFairCalculatorService,
                _fakeDateTimeWrapper);
        }

        [TestMethod]
        public void Calculate_DayRate_ReturnRate()
        {
            A.CallTo(() => _fakeDateTimeWrapper.Now()).Returns(Dummy.DayDate);

            A.CallTo(() => _fakeFareRateRepository.GetAll()).Returns(Dummy.AllFareRates);

            A.CallTo(() => _fakeCarRepository.Get(Dummy.LICENSE1)).Returns(Dummy.Car1);

            A.CallTo(() => _fakeCompanyFeeRepository.Get(Dummy.COMPANY_NAME1)).Returns(Dummy.CompanyFee1);

            var actual = _target.Calculate(Dummy.FareRateDto_Distance_10_Licence_1);

            var expected = 16;

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Calculate_NightRate_ReturnRate()
        {
            A.CallTo(() => _fakeDateTimeWrapper.Now()).Returns(Dummy.NightDate);

            A.CallTo(() => _fakeCarRepository.Get(Dummy.LICENSE2)).Returns(Dummy.Car2);

            A.CallTo(() => _fakeFareRateRepository.GetAll()).Returns(Dummy.AllFareRates);

            A.CallTo(() => _fakeCompanyFeeRepository.Get(Dummy.COMPANY_NAME2)).Returns(Dummy.CompanyFee2);

            var actual = _target.Calculate(Dummy.FareRateDto_Distance_10_Licence_2);

            var expected = 22;

            actual.Should().Be(expected);
        }


        [TestMethod]
        public void Calculate_NightRateCompanyFeeZero_ReturnRate()
        {
            A.CallTo(() => _fakeDateTimeWrapper.Now()).Returns(Dummy.NightDate);

            A.CallTo(() => _fakeCarRepository.Get(Dummy.LICENSE)).Returns(Dummy.Car);

            A.CallTo(() => _fakeFareRateRepository.GetAll()).Returns(Dummy.AllFareRates);

            A.CallTo(() => _fakeCompanyFeeRepository.Get(Dummy.COMPANY_NAME)).Returns(Dummy.CompanyFee3);

            var actual = _target.Calculate(Dummy.FareRateDto_Distance_10);

            var expected = 20;

            actual.Should().Be(expected);
        }


        [TestMethod]
        public void Calculate_NightRateFareRateZero_ReturnRate()
        {
            A.CallTo(() => _fakeDateTimeWrapper.Now()).Returns(Dummy.DayDate);

            A.CallTo(() => _fakeCarRepository.Get(Dummy.LICENSE1)).Returns(Dummy.Car1);

            A.CallTo(() => _fakeFareRateRepository.GetAll()).Returns(Dummy.AllFareRatesDayIsZero);

            A.CallTo(() => _fakeCompanyFeeRepository.Get(Dummy.COMPANY_NAME1)).Returns(Dummy.CompanyFee1);

            var actual = _target.Calculate(Dummy.FareRateDto_Distance_10_Licence_1);

            var expected = 1;

            actual.Should().Be(expected);
        }
    }
}
