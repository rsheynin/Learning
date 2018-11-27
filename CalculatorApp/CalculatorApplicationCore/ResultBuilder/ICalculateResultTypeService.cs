using System.Collections.Generic;

namespace CalculatorApplicationCore.ResultBuilder
{
    public interface ICalculateResultTypeService
    {
        IEnumerable<string> Get();
    }
}