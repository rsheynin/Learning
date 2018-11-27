using CalculatorApplicationCore.Const;

namespace CalculatorApplicationCore.ResultBuilder
{
    public class CalculateResultBuilderColor : ICalculateResultBuilder
    {
        public CalculateResultType Type
        {
            get { return CalculateResultType.Color; }
        }
        public ICalculateResult Build(double calculationResult)
        {
            var result = new CalculateResultColor(calculationResult);
            var parity = calculationResult % 2 == 0;

            if (parity)
            {
                result.Color = CalculatorConst.COLOR_RESULT_GREEN;
            }
            else
            {
                result.Color = CalculatorConst.COLOR_RESULT_RED;
            }
            return result;
        }
    }
}