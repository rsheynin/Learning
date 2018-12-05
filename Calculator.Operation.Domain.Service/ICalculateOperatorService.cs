using System.Collections.Generic;

namespace Calculator.Operation.Domain.Service
{
    public interface ICalculateOperatorService
    {
        IEnumerable<string> Get();
    }
}