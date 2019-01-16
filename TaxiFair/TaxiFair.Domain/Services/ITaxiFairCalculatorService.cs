namespace TaxiFair.Domain.Services
{
    public interface ITaxiFairCalculatorService
    {
        double Calculate(TaxiFairDto taxiFairDto);
    }
}