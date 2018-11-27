namespace CalculatorCompositionApplicationCore.ResultBuilder
{
    public class CalculateResultColor : ICalculateResult
    {
        public CalculateResultColor(double calculationResult)
        {
            Result = calculationResult;
        }

        public string Type
        {
            get { return CalculateResultType.Color.ToString(); }
        }

        public double Result { get; set; }

        public string Color { get; set; }
    }
}