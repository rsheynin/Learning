namespace Calculator.Composition.Operation.Domain.Service
{
    public class CalculateActionDto
    {
        public string ResultType { get; set; }

        public CalculateOperationCompositionDto OperationDto { get; set; }
    }
}