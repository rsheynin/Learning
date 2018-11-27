﻿using System.Collections.Generic;

namespace CalculatorCompositionApplicationCore.Operations
{
    public abstract class CalculateOperationBase : ICalculateOperation
    {
        private readonly IDictionary<string,ICalculateOperation> _operations;

        protected CalculateOperationBase(IDictionary<string, ICalculateOperation> operations)
        {
            _operations = operations;
        }

        public abstract string Type { get; }

        public double Calculate(CalculateOperationDto calculateOperationDto)
        {
            double operand;
            if (calculateOperationDto.ChildOperation.Operator == null ||
                calculateOperationDto.ChildOperation.ChildOperation == null)
            {
                operand = calculateOperationDto.Operand;
            }
            else
            {
                operand = _operations[calculateOperationDto.ChildOperation.Operator]
                    .Calculate(calculateOperationDto.ChildOperation);
            }

            var result = CalculateOperation(operand, calculateOperationDto);

            return result;
        }

        protected abstract double CalculateOperation(double operand, CalculateOperationDto calculateOperationDto);
    }
}