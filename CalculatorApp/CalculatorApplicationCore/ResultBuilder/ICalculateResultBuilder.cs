namespace CalculatorApplicationCore.ResultBuilder
{
    public interface ICalculateResultBuilder
    {
        CalculateResultType Type { get; }
        ICalculateResult Build(double calculationResult);
    }
}