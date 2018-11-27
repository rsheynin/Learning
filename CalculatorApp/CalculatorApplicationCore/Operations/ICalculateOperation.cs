namespace CalculatorApplicationCore.Operations
{
    public interface ICalculateOperation
    {
        string Type { get; }

        double Calculate(CalculateOperationDto calculateOperationDto);
    }
}