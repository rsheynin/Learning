namespace Calculator.Operation.Domain.Service
{
    public interface ICalculateOperation
    {
        string Type { get; }

        double Calculate(CalculateOperationDto calculateOperationDto);
    }
}