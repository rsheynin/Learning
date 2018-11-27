using System.Collections.Generic;

namespace CalculatorCompositionApplicationCore.ResultBuilder
{
    public interface ICalculateResultTypeService
    {
        IEnumerable<string> Get();
    }
}