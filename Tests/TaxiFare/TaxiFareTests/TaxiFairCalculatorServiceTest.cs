using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiFair.Domain;
using TaxiFair.Domain.Services;

namespace TaxiFareTests
{
    [TestClass]
    public class TaxiFairCalculatorServiceTest
    {
        private TaxiFairCalculatorService _target;
        private double FAKE_RATE_2 = 2;
        private double FAKE_FEE_3 = 3;
        private TaxiFairDto _fakeTaxiFairDto;
        private double FAKE_DISTANCE_4 = 4;
        private double FAKE_DISTANCE_0 = 0;
        private double TAXI_FAIR_RESULT_3 = 3;
        private double FAKE_RATE_0 = 0;
        private const double TAXI_FAIR_RESULT_11 = 11;

        [TestInitialize]
        public void InIt()
        {
            _target = new TaxiFairCalculatorService();
        }

        [TestMethod]
        public void Calculate_DistanceZero_ReturnFair()
        {
            _fakeTaxiFairDto = new TaxiFairDto(FAKE_RATE_2, FAKE_FEE_3, FAKE_DISTANCE_0);

            var actual = _target.Calculate(_fakeTaxiFairDto);
            actual.Should().Be(TAXI_FAIR_RESULT_3);
        }

        [TestMethod]
        public void Calculate_FareRateZero_ReturnFair()
        {
            _fakeTaxiFairDto = new TaxiFairDto(FAKE_RATE_0, FAKE_FEE_3, FAKE_DISTANCE_4);

            var actual = _target.Calculate(_fakeTaxiFairDto);
            actual.Should().Be(TAXI_FAIR_RESULT_3);
        }

        [TestMethod]
        public void Calculate_RateAndFeeAndDistance_ReturnFair()
        {
            _fakeTaxiFairDto = new TaxiFairDto(FAKE_RATE_2,FAKE_FEE_3,FAKE_DISTANCE_4);

            var actual = _target.Calculate(_fakeTaxiFairDto);
            actual.Should().Be(TAXI_FAIR_RESULT_11);
        }


        //[TestMethod]
        //public void GetFee_ExistingLicense_ReturnFee()
        //{
        //    var actual = _target.GetFee(FAKE_LICENSE_1);
        //    actual.Should().Be(COMPANY_FEE_1);
        //}

        //[ExpectedException(typeof(ArgumentException))]
        //[TestMethod]
        //public void GetFee_DaytimeMissingFareRateTimeRange_Throw()
        //{
        //    var actual = _target.GetFee(FAKE_LICENSE_1);
        //}
    }
}