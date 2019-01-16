using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperatorController : Controller
    {
        private readonly ICalculateOperatorService _operatorService;

        public OperatorController(ICalculateOperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        [HttpGet()]
        public IEnumerable<string> Operators()
        {
            var operators = _operatorService.Get();
            return operators;
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class CalculateResultTypeController : Controller
    {
        private readonly ICalculateResultTypeService _resultTypeService;

        public CalculateResultTypeController(ICalculateResultTypeService resultTypeService)
        {
            _resultTypeService = resultTypeService;
        }

        [HttpGet()]
        public IEnumerable<string> ResultType()
        {
            var operators = _resultTypeService.Get();
            return operators;
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class CalculateController : Controller
    {
        private readonly ICalculatorApplicationService _calculatorApplicationService;

        public CalculateController(ICalculatorApplicationService calculatorApplicationService)
        {
            _calculatorApplicationService = calculatorApplicationService;
        }

        [HttpPost()]
        public ICalculateResult Calculate([FromBody]CalculateOperationDto operationDto)
        {
            var operators = _calculatorApplicationService.Calculate(operationDto);
            return operators;
        }
    }

    public class CalculateOperationDto
    {
        public string ResultType { get; set; }

        public string Operator { get; set; }

        public double A { get; set; }

        public double B { get; set; }

        //public CalculateOperationDto ChildCalculateOperationDto { get; set; }
    }

    public enum CalculateResultType
    {
        Number,
        Color,
        Parity
    }
    
    public interface ICalculateResult
    {
        string Type { get;}
    }

    public class CalculateResultParity : ICalculateResult
    {
        public CalculateResultParity(double calculationResult)
        {
            Result = calculationResult;
        }

        public string Type
        {
            get { return CalculateResultType.Parity.ToString(); }
        }

        public string Parity { get; set; }

        public double Result { get; set; }
    }

    public class CalculateResultColor : ICalculateResult
    {
        public CalculateResultColor(double calculationResult)
        {
            Result = calculationResult;
        }

        public string Type
        {
            get { return CalculateResultType.Color.ToString(); }
        }

        public double Result { get; set; }

        public string Color { get; set; }
    }

    public class CalculateResultNumber : ICalculateResult
    {
        public CalculateResultNumber(double calculationResult)
        {
            Result = calculationResult;
        }

        public string Type
        {
            get { return CalculateResultType.Number.ToString(); }
        }

        public double Result { get; set; }
    }

    public interface ICalculateResultTypeService
    {
        IEnumerable<string> Get();
    }

    public class CalculateResultTypeService : ICalculateResultTypeService
    {
       
        public IEnumerable<string> Get()
        {
            var results = Enum.GetNames(typeof(CalculateResultType));

            return results;
        }
    }

    public interface ICalculateOperatorService
    {
        IEnumerable<string> Get();
    }

    public class CalculateOperatorService : ICalculateOperatorService
    {
        private readonly IDictionary<string, ICalculateOperation> _calculateOperations;

        public CalculateOperatorService(IDictionary<string, ICalculateOperation> calculateOperations)
        {
            _calculateOperations = calculateOperations;
        }

        public IEnumerable<string> Get()
        {
            var calculateOperationsKeys = _calculateOperations.Keys;
            return calculateOperationsKeys;
        }
    }


    public interface ICalculatorApplicationService
    {
        ICalculateResult Calculate(CalculateOperationDto actionDto);
    }

    public class CalculatorApplicationService : ICalculatorApplicationService
    {
        //private readonly IDictionary<string,ICalculateValidator> _validators;
        private readonly IDictionary<string, ICalculateOperation> _operations;
        private readonly IDictionary<string, ICalculateResultBuilder> _resultBilders;

        public CalculatorApplicationService(
            //IDictionary<string, ICalculateValidator> validators, 
            IDictionary<string, ICalculateOperation> operations,
            IDictionary<string, ICalculateResultBuilder> resultBilders)
        {
            // _validators = validators;
            _operations = operations;
            _resultBilders = resultBilders;
        }

        public ICalculateResult Calculate(CalculateOperationDto actionDto)
        {

            //var validationObjects = _validators[actionDto.Operator].Validate(actionDto);
            //if (validationObjects.Any())
            //{
            //    //var result = new 
            //}

            var calculationResult = _operations[actionDto.Operator].Calculate(actionDto);

            var result = _resultBilders[actionDto.ResultType].Build(calculationResult);
            return result;
        }
    }

    public interface ICalculateResultBuilder
    {
        CalculateResultType Type { get; }
        ICalculateResult Build(double calculationResult);
    }

    public class CalculateResultBuilderParity : ICalculateResultBuilder
    {
        public CalculateResultType Type
        {
            get { return CalculateResultType.Parity; }
        }
        public ICalculateResult Build(double calculationResult)
        {
            var result = new CalculateResultParity(calculationResult);

            var parity = calculationResult % 2 == 0;

            if (parity)
            {
                result.Parity = CalculatorConst.PARITY_RESULT_EVEN;
            }
            else
            {
                result.Parity = CalculatorConst.PARITY_RESULT_ODD;
            }

            return result;
        }
    }

    public class CalculateResultBuilderColor : ICalculateResultBuilder
    {
        public CalculateResultType Type
        {
            get { return CalculateResultType.Color; }
        }
        public ICalculateResult Build(double calculationResult)
        {
            var result = new CalculateResultColor(calculationResult);
            var parity = calculationResult % 2 == 0;

            if (parity)
            {
                result.Color = CalculatorConst.COLOR_RESULT_GREEN;
            }
            else
            {
                result.Color = CalculatorConst.COLOR_RESULT_RED;
            }
            return result;
        }
    }

    public class CalculateResultBuilderNumber : ICalculateResultBuilder
    {
        public CalculateResultType Type
        {
            get { return CalculateResultType.Number; }
        }
        public ICalculateResult Build(double calculationResult)
        {
            var result = new CalculateResultNumber(calculationResult);
            return result;
        }
    }


    public interface ICalculateOperation
    {
        string Type { get; }

        double Calculate(CalculateOperationDto calculateOperationDto);
    }

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

    public static class CalculatorConst
    {
        public const string PLUS = "+";
        public const string MINUS = "-";
        public const string DIVIDE = "/";
        public const string MULTIPLY = "*";

        public const string PARITY_RESULT_ODD = "odd";
        public const string PARITY_RESULT_EVEN = "even";

        public const string COLOR_RESULT_GREEN = "green";
        public const string COLOR_RESULT_RED = "red";
    }
}