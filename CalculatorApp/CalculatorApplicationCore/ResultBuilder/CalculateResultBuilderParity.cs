using CalculatorApplicationCore.Const;

namespace CalculatorApplicationCore.ResultBuilder
{
    public class CalculateResultBuilderParity : ICalculateResultBuilder
    {
        public CalculateResultType Type
        {
            get { return CalculateResultType.Parity; }
        }
        public ICalculateResult Build(double calculationResult)
        {
            var result = new CalculateResultParity(calculationResult);

            var parity = calculationResult % 2 == 0;

            if (parity)
            {
                result.Parity = CalculatorConst.PARITY_RESULT_EVEN;
            }
            else
            {
                result.Parity = CalculatorConst.PARITY_RESULT_ODD;
            }

            return result;
        }
    }
}