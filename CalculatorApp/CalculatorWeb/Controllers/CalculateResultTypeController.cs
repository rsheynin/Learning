using System.Collections.Generic;
using CalculatorApplicationCore.ResultBuilder;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWeb.Controllers
{
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
}