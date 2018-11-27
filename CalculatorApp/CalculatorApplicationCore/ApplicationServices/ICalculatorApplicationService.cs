using CalculatorApplicationCore.Operations;
using CalculatorApplicationCore.ResultBuilder;

namespace CalculatorApplicationCore.ApplicationServices
{
    public interface ICalculatorApplicationService
    {
        ICalculateResult Calculate(CalculateOperationDto actionDto);
    }
}