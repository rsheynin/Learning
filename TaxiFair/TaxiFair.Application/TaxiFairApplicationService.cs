using TaxiFair.Domain;
using TaxiFair.Domain.Repository;
using TaxiFair.Domain.Services;
using TaxiFair.Infrastructure;
using IFareRateService = TaxiFair.Domain.Services.IFareRateService;

namespace TaxiFair.Application
{
    public class TaxiFairApplicationService : ITaxiFairApplicationService
    {
        private readonly IFareRateRepository _fareRateRepository;
        private readonly ICompanyFeeRepository _companyFeeRepository;
        private readonly ICarRepository _carRepository;
        private readonly IFareRateService _fareRateService;
        private readonly ITaxiFairCalculatorService _taxiFairCalculatorService;
        private readonly IDateTimeWrapper _dateTimeWrapper;

        /// <inheritdoc />
        public TaxiFairApplicationService(
            IFareRateRepository fareRateRepository, 
            ICompanyFeeRepository companyFeeRepository, 
            ICarRepository carRepository, 
            IFareRateService fareRateService, 
            ITaxiFairCalculatorService taxiFairCalculatorService,
            IDateTimeWrapper dateTimeWrapper)
        {
            _fareRateRepository = fareRateRepository;
            _fareRateService = fareRateService;
            _companyFeeRepository = companyFeeRepository;
            _carRepository = carRepository;
            _taxiFairCalculatorService = taxiFairCalculatorService;
            _dateTimeWrapper = dateTimeWrapper;
        }

        public double Calculate(FareRateDto fareRateDto)
        {
            var date = _dateTimeWrapper.Now();

            var fareRates = _fareRateRepository.GetAll();
            
            var car = _carRepository.Get(fareRateDto.License);
            var companyFee = _companyFeeRepository.Get(car.CompanyName);

            var rate = _fareRateService.GetRate(date.TimeOfDay, fareRates);

            var taxiFairDto = new TaxiFairDto(rate, companyFee.Fee, fareRateDto.Distance);
            var fair = _taxiFairCalculatorService.Calculate(taxiFairDto);

            return fair;
        }
    }
}