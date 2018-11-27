using System.Collections.Generic;

namespace CalculatorApplicationCore.Operations
{
    public interface ICalculateOperatorService
    {
        IEnumerable<string> Get();
    }
}