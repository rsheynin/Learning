namespace Calculator.ResultBuilder.Domain.Service
{
    public class CalculateResultBuilderNumber : ICalculateResultBuilder
    {
        public CalculateResultType Type
        {
            get { return CalculateResultType.Number; }
        }
        public ICalculateResult Build(double calculationResult)
        {
            var result = new CalculateResultNumber(calculationResult);
            return result;
        }
    }
}