using System.Collections.Generic;

namespace CalculatorCompositionApplicationCore.Operations
{
    public interface ICalculateOperatorService
    {
        IEnumerable<string> Get();
    }
}