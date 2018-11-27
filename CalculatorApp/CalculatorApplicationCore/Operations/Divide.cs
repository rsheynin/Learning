using CalculatorApplicationCore.Const;

namespace CalculatorApplicationCore.Operations
{
    public class Divide : ICalculateOperation
    {
        public string Type
        {
            get { return CalculatorConst.DIVIDE; }
        }
        public double Calculate(CalculateOperationDto calculateOperationDto)
        {
            var result = calculateOperationDto.A / calculateOperationDto.B;
            return result;
        }
    }
}