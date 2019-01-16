namespace TaxiFair.Domain.Services
{
    public class TaxiFairCalculatorService : ITaxiFairCalculatorService
    {
        public double Calculate(TaxiFairDto taxiFairDto)
        {
            var result = taxiFairDto.Rate * taxiFairDto.Distance + taxiFairDto.CompanyFee;

            return result;
        }
    }
}