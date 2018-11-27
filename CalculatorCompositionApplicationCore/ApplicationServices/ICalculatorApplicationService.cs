using CalculatorCompositionApplicationCore.Operations;

namespace CalculatorCompositionApplicationCore.ApplicationServices
{
    public interface ICalculatorApplicationService
    {
        ResultBuilder.ICalculateResult Calculate(CalculateOperationDto actionDto);
    }
}