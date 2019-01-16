using System;
using System.Collections.Generic;

namespace Calculator.ResultBuilder.Domain.Service
{
    public class CalculateResultTypeService : ICalculateResultTypeService
    {

        public IEnumerable<string> Get()
        {
            var results = Enum.GetNames(typeof(CalculateResultType));

            return results;
        }
    }
}