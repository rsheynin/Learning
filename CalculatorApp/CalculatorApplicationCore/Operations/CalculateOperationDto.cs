namespace CalculatorApplicationCore.Operations
{
    public class CalculateOperationDto
    {
        public string ResultType { get; set; }

        public string Operator { get; set; }

        public double A { get; set; }

        public double B { get; set; }
    }
}