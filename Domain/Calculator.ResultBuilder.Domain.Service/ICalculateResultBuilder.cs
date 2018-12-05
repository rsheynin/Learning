namespace Calculator.ResultBuilder.Domain.Service
{
    public interface ICalculateResultBuilder
    {
        CalculateResultType Type { get; }
        ICalculateResult Build(double calculationResult);
    }
}