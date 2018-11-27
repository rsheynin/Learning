using CalculatorApplicationCore.ApplicationServices;
using CalculatorApplicationCore.Operations;
using CalculatorApplicationCore.ResultBuilder;
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