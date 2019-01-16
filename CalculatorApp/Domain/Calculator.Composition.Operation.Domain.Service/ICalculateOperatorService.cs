using System.Collections.Generic;

namespace Calculator.Composition.Operation.Domain.Service
{
    public interface ICalculateOperatorService
    {
        IEnumerable<string> Get();
    }
}