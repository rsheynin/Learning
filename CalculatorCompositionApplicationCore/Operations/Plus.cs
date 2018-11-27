using System.Collections.Generic;
using CalculatorCompositionApplicationCore.Const;

namespace CalculatorCompositionApplicationCore.Operations
{
    public class Plus : CalculateOperationBase
    {
        public override string Type
        {
            get { return CalculatorConst.PLUS; }
        }

        public Plus(IDictionary<string, ICalculateOperation> operations) 
            : base(operations){}

        protected override double CalculateOperation(double operand, CalculateOperationDto calculateOperationDto)
        {
            var result = operand + calculateOperationDto.Operand;
            return result;
        }
    }
}