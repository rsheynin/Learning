using CalculatorApplicationCore.Const;

namespace CalculatorApplicationCore.Operations
{
    public class Multiply : ICalculateOperation
    {
        public string Type
        {
            get { return CalculatorConst.MULTIPLY; }
        }
        public double Calculate(CalculateOperationDto calculateOperationDto)
        {
            var result = calculateOperationDto.A * calculateOperationDto.B;
            return result;
        }
    }
}