using System;
using System.Collections.Generic;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiFair.Application;
using TaxiFair.Domain;
using TaxiFair.Domain.Repository;
using TaxiFair.Domain.Services;
using TaxiFair.Infrastructure;
using TestHelper;

namespace TaxiFareTests
{
    [TestClass]
    public class TaxiFairApplicationServiceTest
    {
        private TaxiFairApplicationService _target;
        private IFareRateRepository _stubFareRateRepository;
        private ICompanyFeeRepository _stubCompanyFeeRepository;
        private ICarRepository _stubCarRepository;
        private ITaxiFairCalculatorService _stubTaxiFairCalculatorService;
        private IFareRateService _stubFareRateService;
        private FareRateDto _fakeFareRateDto;
        private IEnumerable<FareRate> _fakeAllFareRates = new List<FareRate>();
        private Car _fakeCar;
        private CompanyFee _fakeFee;
        private TaxiFairDto _fakeTaxiFairDto;
        private double EXPECTED_FAIR = 10;
        private IDateTimeWrapper _stubDateTimeWrapper;
        private DateTime _fakeDayDate = new DateTime(2019,01,15,15,00,00);
        private DateTime _fakeNightDate = new DateTime(2019,01,23,15,00,00);
        private const double DAY_RATE = 1.5;
        private const double NIGHT_RATE = 2;
        private const double COMPANY_FEE = 5;
        private const double DISTANCE = 10;

        private const string FAKE_LICENSE = "License";
        private const string DRIVER_NAME = "DriverName";
        private const string OWNER_NAME = "OwnerName";
        private const string COMPANY_NAME = "companyName";

        [TestInitialize]
        public void InIt()
        {
            _stubFareRateRepository = A.Fake<IFareRateRepository>();
            _stubCompanyFeeRepository = A.Fake<ICompanyFeeRepository>();
            _stubCarRepository = A.Fake<ICarRepository>();
            _stubTaxiFairCalculatorService = A.Fake<ITaxiFairCalculatorService>();
            _stubFareRateService  = A.Fake<IFareRateService>();
            _stubDateTimeWrapper = A.Fake<IDateTimeWrapper>();

            _target = new TaxiFairApplicationService(
                _stubFareRateRepository, _stubCompanyFeeRepository, 
                _stubCarRepository, _stubFareRateService, 
                _stubTaxiFairCalculatorService, _stubDateTimeWrapper);
        }

        [TestMethod]
        public void Calculate_FareRateRepositoryWasCalled_ReturnFair()
        {
            _fakeFareRateDto = new FareRateDto(DISTANCE, FAKE_LICENSE);
            var actual = _target.Calculate(_fakeFareRateDto);

            A.CallTo(() => _stubFareRateRepository.GetAll()).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_CarRepositoryWasCalledWithLicense_ReturnFair()
        {
            _fakeFareRateDto = new FareRateDto(DISTANCE, FAKE_LICENSE);
            var actual = _target.Calculate(_fakeFareRateDto);

            A.CallTo(() => _stubCarRepository.Get(_fakeFareRateDto.License)).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_CompanyFeeRepositoryCalledWithCompanyNAme_ReturnFair()
        {
            _fakeFareRateDto = new FareRateDto(DISTANCE, FAKE_LICENSE);
            _fakeCar = new Car(_fakeFareRateDto.License, DRIVER_NAME, OWNER_NAME, COMPANY_NAME);

            A.CallTo(() => _stubCarRepository.Get(_fakeFareRateDto.License)).Returns(_fakeCar);

            var actual = _target.Calculate(_fakeFareRateDto);

            A.CallTo(() => _stubCompanyFeeRepository.Get(_fakeCar.CompanyName)).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_FareRateServiceCalledWithDayDate_ReturnFair()
        {
            _fakeFareRateDto = new FareRateDto(DISTANCE, FAKE_LICENSE, _fakeDayDate);
            _fakeCar = new Car(_fakeFareRateDto.License, DRIVER_NAME, OWNER_NAME, COMPANY_NAME);
            _fakeFee = new CompanyFee(COMPANY_NAME,COMPANY_FEE);

            A.CallTo(() => _stubDateTimeWrapper.Now()).Returns(_fakeDayDate);

            A.CallTo(() => _stubFareRateRepository.GetAll()).Returns(_fakeAllFareRates);

            A.CallTo(() => _stubCarRepository.Get(_fakeFareRateDto.License)).Returns(_fakeCar);

            A.CallTo(() => _stubCompanyFeeRepository.Get(_fakeCar.CompanyName)).Returns(_fakeFee);

            var actual = _target.Calculate(_fakeFareRateDto);

            A.CallTo(() => _stubFareRateService.GetRate(_fakeFareRateDto.Date.TimeOfDay,_fakeAllFareRates)
            ).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_TaxiFairCalculateDayDate_ReturnFair()
        {
            _fakeFareRateDto = new FareRateDto(DISTANCE, FAKE_LICENSE, _fakeDayDate);
            _fakeCar = new Car(_fakeFareRateDto.License, DRIVER_NAME, OWNER_NAME, COMPANY_NAME);
            _fakeFee = new CompanyFee(COMPANY_NAME, COMPANY_FEE);

            A.CallTo(() => _stubDateTimeWrapper.Now()).Returns(_fakeDayDate);

            A.CallTo(() => _stubFareRateRepository.GetAll()).Returns(_fakeAllFareRates);

            A.CallTo(() => _stubCarRepository.Get(_fakeFareRateDto.License)).Returns(_fakeCar);

            A.CallTo(() => _stubCompanyFeeRepository.Get(_fakeCar.CompanyName)).Returns(_fakeFee);

            A.CallTo(() => _stubFareRateService.GetRate(_fakeFareRateDto.Date.TimeOfDay, _fakeAllFareRates)
            ).Returns(DAY_RATE);


            _fakeTaxiFairDto = new TaxiFairDto(DAY_RATE,COMPANY_FEE,DISTANCE);

            A.CallTo(() => _stubTaxiFairCalculatorService
                .Calculate(A<TaxiFairDto>.That
                    .Matches(a => CompareReferenceObjects.Compare(_fakeTaxiFairDto,a))))
                .Returns(EXPECTED_FAIR);
            var actual = _target.Calculate(_fakeFareRateDto);

            Assert.AreEqual(EXPECTED_FAIR,actual);
        }

    }
}
