using FakeItEasy;
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
            Dummy.FareRateDto = new FareRateDto(Dummy.DISTANCE, Dummy.FAKE_LICENSE);
            var actual = _target.Calculate(Dummy.FareRateDto);

            A.CallTo(() => _fakeFareRateRepository.GetAll()).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_CarRepositoryWasCalledWithLicense_ReturnFair()
        {
            Dummy.FareRateDto = new FareRateDto(Dummy.DISTANCE, Dummy.FAKE_LICENSE);
            var actual = _target.Calculate(Dummy.FareRateDto);

            A.CallTo(() => _fakeCarRepository.Get(Dummy.FareRateDto.License)).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_CompanyFeeRepositoryCalledWithCompanyNAme_ReturnFair()
        {
            Dummy.FareRateDto = new FareRateDto(Dummy.DISTANCE, Dummy.FAKE_LICENSE);
            Dummy.Car = new Car(Dummy.FareRateDto.License, Dummy.DRIVER_NAME, Dummy.OWNER_NAME, Dummy.COMPANY_NAME);

            A.CallTo(() => _fakeCarRepository.Get(Dummy.FareRateDto.License)).Returns(Dummy.Car);

            var actual = _target.Calculate(Dummy.FareRateDto);

            A.CallTo(() => _fakeCompanyFeeRepository.Get(Dummy.Car.CompanyName)).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_FareRateServiceCalledWithDayDate_ReturnFair()
        {
            Dummy.FareRateDto = new FareRateDto(Dummy.DISTANCE, Dummy.FAKE_LICENSE, Dummy.DayDate);
            Dummy.Car = new Car(Dummy.FareRateDto.License, Dummy.DRIVER_NAME, Dummy.OWNER_NAME, Dummy.COMPANY_NAME);
            Dummy.Fee = new CompanyFee(Dummy.COMPANY_NAME, Dummy.COMPANY_FEE_5);

            A.CallTo(() => _fakeDateTimeWrapper.Now()).Returns(Dummy.DayDate);

            A.CallTo(() => _fakeFareRateRepository.GetAll()).Returns(Dummy.AllFareRates);

            A.CallTo(() => _fakeCarRepository.Get(Dummy.FareRateDto.License)).Returns(Dummy.Car);

            A.CallTo(() => _fakeCompanyFeeRepository.Get(Dummy.Car.CompanyName)).Returns(Dummy.Fee);

            var actual = _target.Calculate(Dummy.FareRateDto);

            A.CallTo(() => _fakeFareRateService.GetRate(Dummy.FareRateDto.Date.TimeOfDay, Dummy.AllFareRates)
            ).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_TaxiFairCalculateDayDate_ReturnFair()
        {
            Dummy.FareRateDto = new FareRateDto(Dummy.DISTANCE, Dummy.FAKE_LICENSE, Dummy.DayDate);
            Dummy.Car = new Car(Dummy.FareRateDto.License, Dummy.DRIVER_NAME, Dummy.OWNER_NAME, Dummy.COMPANY_NAME);
            Dummy.Fee = new CompanyFee(Dummy.COMPANY_NAME, Dummy.COMPANY_FEE_5);

            A.CallTo(() => _fakeDateTimeWrapper.Now()).Returns(Dummy.DayDate);

            A.CallTo(() => _fakeFareRateRepository.GetAll()).Returns(Dummy.AllFareRates);

            A.CallTo(() => _fakeCarRepository.Get(Dummy.FareRateDto.License)).Returns(Dummy.Car);

            A.CallTo(() => _fakeCompanyFeeRepository.Get(Dummy.Car.CompanyName)).Returns(Dummy.Fee);

            A.CallTo(() => _fakeFareRateService.GetRate(Dummy.FareRateDto.Date.TimeOfDay, Dummy.AllFareRates)
            ).Returns(Dummy.DAY_RATE);


            Dummy.TaxiFairDto = new TaxiFairDto(Dummy.DAY_RATE, Dummy.COMPANY_FEE_5, Dummy.DISTANCE);

            A.CallTo(() => _fakeTaxiFairCalculatorService
                .Calculate(A<TaxiFairDto>.That
                    .Matches(a => CompareReferenceObjects.Compare(Dummy.TaxiFairDto,a))))
                .Returns(EXPECTED_FAIR);
            var actual = _target.Calculate(Dummy.FareRateDto);

            Assert.AreEqual(EXPECTED_FAIR,actual);
        }

    }
}
