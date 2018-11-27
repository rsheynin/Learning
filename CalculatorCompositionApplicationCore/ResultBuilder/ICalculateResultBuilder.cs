namespace CalculatorCompositionApplicationCore.ResultBuilder
{
    public interface ICalculateResultBuilder
    {
        CalculateResultType Type { get; }
        ICalculateResult Build(double calculationResult);
    }
}