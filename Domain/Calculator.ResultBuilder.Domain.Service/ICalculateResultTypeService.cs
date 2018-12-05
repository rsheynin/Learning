using System.Collections.Generic;

namespace Calculator.ResultBuilder.Domain.Service
{
    public interface ICalculateResultTypeService
    {
        IEnumerable<string> Get();
    }
}