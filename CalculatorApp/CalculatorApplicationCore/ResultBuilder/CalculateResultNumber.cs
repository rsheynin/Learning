namespace CalculatorApplicationCore.ResultBuilder
{
    public class CalculateResultNumber : ICalculateResult
    {
        public CalculateResultNumber(double calculationResult)
        {
            Result = calculationResult;
        }

        public string Type
        {
            get { return CalculateResultType.Number.ToString(); }
        }

        public double Result { get; set; }
    }
}