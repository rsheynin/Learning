using System.Collections.Generic;
using CalculatorCompositionApplicationCore.Const;

namespace CalculatorCompositionApplicationCore.Operations
{
    public class Multiply : CalculateOperationBase
    {
        public override string Type
        {
            get { return CalculatorConst.MULTIPLY; }
        }

        public Multiply(IDictionary<string, ICalculateOperation> operations)
            : base(operations){}
        
        protected override double CalculateOperation(double operand, CalculateOperationDto calculateOperationDto)
        {
            var result = operand * calculateOperationDto.Operand;
            return result;
        }
    }
}