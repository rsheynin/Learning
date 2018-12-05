using System.Collections.Generic;
using Calculate.Common.Const;

namespace Calculator.Composition.Operation.Domain.Service
{
    public class Minus : CalculateOperationBase
    {
        public override string Type
        {
            get { return CalculatorConst.MINUS; }
        }

        public Minus(IDictionary<string, ICalculateOperation> operations) 
            : base(operations){}

        protected override double CalculateOperation(double operand, CalculateOperationCompositionDto calculateOperationDto)
        {
            var result = operand - calculateOperationDto.Operand;
            return result;
        }
    }
}