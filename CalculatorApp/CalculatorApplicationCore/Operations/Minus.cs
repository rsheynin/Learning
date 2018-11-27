using CalculatorApplicationCore.Const;

namespace CalculatorApplicationCore.Operations
{
    public class Minus : ICalculateOperation
    {
        public string Type
        {
            get { return CalculatorConst.MINUS; }
        }
        public double Calculate(CalculateOperationDto calculateOperationDto)
        {
            var result = calculateOperationDto.A - calculateOperationDto.B;
            return result;
        }
    }
}