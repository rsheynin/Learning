using Calculator.Operation.Domain.Service;
using Calculator.ResultBuilder.Domain.Service;

namespace Calculator.Application.Service
{
    public interface ICalculatorApplicationService
    {
        ICalculateResult Calculate(CalculateOperationDto actionDto);
    }
}