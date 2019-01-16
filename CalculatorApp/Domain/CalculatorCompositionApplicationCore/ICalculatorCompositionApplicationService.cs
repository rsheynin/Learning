using Calculator.Composition.Operation.Domain.Service;
using Calculator.ResultBuilder.Domain.Service;

namespace Calculator.Composition.Application.Service
{
    public interface ICalculatorCompositionApplicationService
    {
        ICalculateResult Calculate(CalculateActionDto actionDto);
    }
}