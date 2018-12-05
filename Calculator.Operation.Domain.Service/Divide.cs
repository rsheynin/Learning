using Calculate.Common.Const;

namespace Calculator.Operation.Domain.Service
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