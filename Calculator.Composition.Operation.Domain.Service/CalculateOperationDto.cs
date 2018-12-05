namespace Calculator.Composition.Operation.Domain.Service
{
    public class CalculateOperationCompositionDto
    {
        public string Operator { get; set; }

        public double Operand { get; set; }

        public CalculateOperationCompositionDto ChildOperation { get; set; }
    }
}