﻿using Calculate.Common.Const;

namespace Calculator.Operation.Domain.Service
{
    public class Plus : ICalculateOperation
    {
        public string Type
        {
            get { return CalculatorConst.PLUS; }
        }

        public double Calculate(CalculateOperationDto calculateOperationDto)
        {
            var result = calculateOperationDto.A + calculateOperationDto.B;
            return result;
        }
    }
}