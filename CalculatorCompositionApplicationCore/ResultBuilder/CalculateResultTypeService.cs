using System;
using System.Collections.Generic;

namespace CalculatorCompositionApplicationCore.ResultBuilder
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