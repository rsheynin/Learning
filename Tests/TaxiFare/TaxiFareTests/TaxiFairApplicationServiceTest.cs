using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiFair.Application;
using TaxiFair.Domain;
using TaxiFair.Domain.Repository;
using TaxiFair.Domain.Services;
using TaxiFair.Infrastructure;
using TaxiFairDummy;
using TestHelper;

namespace TaxiFareTests
{
    [TestClass]
    public class TaxiFairApplicationServiceTest
    {
        private TaxiFairApplicationService _target;
        private IFareRateRepository _fakeFareRateRepository;
        private ICompanyFeeRepository _fakeCompanyFeeRepository;
        private ICarRepository _fakeCarRepository;
        private ITaxiFairCalculatorService _fakeTaxiFairCalculatorService;
        private IFareRateService _fakeFareRateService;
        private IDateTimeWrapper _fakeDateTimeWrapper;

        private double EXPECTED_FAIR = 10;


        [TestInitialize]
        public void InIt()
        {
            _fakeFareRateRepository = A.Fake<IFareRateRepository>();
            _fakeCompanyFeeRepository = A.Fake<ICompanyFeeRepository>();
            _fakeCarRepository = A.Fake<ICarRepository>();
            _fakeTaxiFairCalculatorService = A.Fake<ITaxiFairCalculatorService>();
            _fakeFareRateService  = A.Fake<IFareRateService>();
            _fakeDateTimeWrapper = A.Fake<IDateTimeWrapper>();

            _target = new TaxiFairApplicationService(
                _fakeFareRateRepository, _fakeCompanyFeeRepository, 
                _fakeCarRepository, _fakeFareRateService, 
                _fakeTaxiFairCalculatorService, _fakeDateTimeWrapper);
        }

        [TestMethod]
        public void Calculate_FareRateRepositoryWasCalled_ReturnFair()
        {
            _target.Calculate(Dummy.FareRateDto_Distance_10);

            A.CallTo(() => _fakeFareRateRepository.GetAll()).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_CarRepositoryWasCalledWithLicense_ReturnFair()
        {
            _target.Calculate(Dummy.FareRateDto_Distance_10);

            A.CallTo(() => _fakeCarRepository.Get(Dummy.FareRateDto_Distance_10.License)).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_CompanyFeeRepositoryCalledWithCompanyNAme_ReturnFair()
        {
           A.CallTo(() => _fakeCarRepository.Get(Dummy.FareRateDto_Distance_10.License)).Returns(Dummy.Car);

            var actual = _target.Calculate(Dummy.FareRateDto_Distance_10);

            A.CallTo(() => _fakeCompanyFeeRepository.Get(Dummy.Car.CompanyName)).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_FareRateServiceCalledWithDayDate_ReturnFair()
        {
           A.CallTo(() => _fakeDateTimeWrapper.Now())
                .Returns(Dummy.DayDate);

            A.CallTo(() => _fakeFareRateRepository.GetAll())
                .Returns(Dummy.AllFareRates);

            A.CallTo(() => _fakeCarRepository
                .Get(Dummy.FareRateDto_Distance_10_Licence_1.License))
                .Returns(Dummy.Car1);

            A.CallTo(() => _fakeCompanyFeeRepository
                .Get(Dummy.Car1.CompanyName))
                .Returns(Dummy.CompanyFee1);

            var actual = _target.Calculate(Dummy.FareRateDto_Distance_10_Licence_1);

            A.CallTo(() => _fakeFareRateService.GetRate(Dummy.DayTimeSpan, Dummy.AllFareRates)
            ).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_TaxiFairCalculateDayDate_ReturnFair()
        {
           A.CallTo(() => _fakeDateTimeWrapper.Now())
               .Returns(Dummy.DayDate);

            A.CallTo(() => _fakeFareRateRepository.GetAll())
                .Returns(Dummy.AllFareRates);

            A.CallTo(() => _fakeCarRepository
                .Get(Dummy.FareRateDto_Distance_10_Licence_1.License))
                .Returns(Dummy.Car1);

            A.CallTo(() => _fakeCompanyFeeRepository
                    .Get(Dummy.Car1.CompanyName))
                .Returns(Dummy.CompanyFee1);

            A.CallTo(() => _fakeFareRateService
                .GetRate(Dummy.DayTimeSpan, Dummy.AllFareRates))
                .Returns(Dummy.DAY_RATE);

            Dummy.TaxiFairDto = 
                new TaxiFairDto(Dummy.DAY_RATE, 
                    Dummy.COMPANY_FEE1, Dummy.DISTANCE);

            A.CallTo(() => _fakeTaxiFairCalculatorService
                .Calculate(A<TaxiFairDto>.That
                    .Matches(a => CompareReferenceObjects.Compare(Dummy.TaxiFairDto,a))))
                .Returns(EXPECTED_FAIR);

            var actual = _target.Calculate(Dummy.FareRateDto_Distance_10_Licence_1);

            actual.Should().Be(EXPECTED_FAIR);
        }

    }
}
