namespace CalculatorCompositionApplicationCore.Operations
{
    public class CalculateOperationDto
    {
        public string ResultType { get; set; }

        public string Operator { get; set; }

        public double Operand { get; set; }

        public CalculateOperationDto ChildOperation { get; set; }
    }
}