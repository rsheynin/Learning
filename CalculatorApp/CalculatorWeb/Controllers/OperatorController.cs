using System.Collections.Generic;
using Calculator.Operation.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWeb.Controllers
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
}