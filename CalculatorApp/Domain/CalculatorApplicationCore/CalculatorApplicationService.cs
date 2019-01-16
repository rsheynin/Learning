using System.Collections.Generic;
using Calculator.Operation.Domain.Service;
using Calculator.ResultBuilder.Domain.Service;

namespace Calculator.Application.Service
{
    public class CalculatorApplicationService : ICalculatorApplicationService
    {
        //private readonly IDictionary<string,ICalculateValidator> _validators;
        private readonly IDictionary<string, ICalculateOperation> _operations;
        private readonly IDictionary<string, ICalculateResultBuilder> _resultBuilders;

        public CalculatorApplicationService(
            //IDictionary<string, ICalculateValidator> validators, 
            IDictionary<string, ICalculateOperation> operations,
            IDictionary<string, ICalculateResultBuilder> resultBuilders)
        {
            // _validators = validators;
            _operations = operations;
            _resultBuilders = resultBuilders;
        }

        public ICalculateResult Calculate(CalculateOperationDto actionDto)
        {

            //var validationObjects = _validators[actionDto.Operator].Validate(actionDto);
            //if (validationObjects.Any())
            //{
            //    //var result = new 
            //}

            var calculationResult = _operations[actionDto.Operator].Calculate(actionDto);

            var result = _resultBuilders[actionDto.ResultType].Build(calculationResult);

            return result;
        }
    }
}