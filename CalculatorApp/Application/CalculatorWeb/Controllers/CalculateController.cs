using Calculator.Application.Service;
using Calculator.Operation.Domain.Service;
using Calculator.ResultBuilder.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWeb.Controllers
{
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
}