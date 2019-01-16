using TaxiFair.Domain;

namespace TaxiFair.Application
{
    public interface ITaxiFairApplicationService
    {
        double Calculate(FareRateDto fareRateDto);
    }
}