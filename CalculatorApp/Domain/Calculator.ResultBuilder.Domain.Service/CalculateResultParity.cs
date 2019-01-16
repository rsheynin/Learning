namespace Calculator.ResultBuilder.Domain.Service
{
    public class CalculateResultParity : ICalculateResult
    {
        public CalculateResultParity(double calculationResult)
        {
            Result = calculationResult;
        }

        public string Type
        {
            get { return CalculateResultType.Parity.ToString(); }
        }

        public string Parity { get; set; }

        public double Result { get; set; }
    }
}