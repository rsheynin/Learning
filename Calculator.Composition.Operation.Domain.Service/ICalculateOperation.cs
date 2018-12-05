namespace Calculator.Composition.Operation.Domain.Service
{
    public interface ICalculateOperation
    {
        string Type { get; }

        double Calculate(CalculateOperationCompositionDto calculateOperationDto);
    }
}