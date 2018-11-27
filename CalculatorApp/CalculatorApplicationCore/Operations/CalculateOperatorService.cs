using System.Collections.Generic;

namespace CalculatorApplicationCore.Operations
{
    public class CalculateOperatorService : ICalculateOperatorService
    {
        private readonly IDictionary<string, ICalculateOperation> _calculateOperations;

        public CalculateOperatorService(IDictionary<string, ICalculateOperation> calculateOperations)
        {
            _calculateOperations = calculateOperations;
        }

        public IEnumerable<string> Get()
        {
            var calculateOperationsKeys = _calculateOperations.Keys;
            return calculateOperationsKeys;
        }
    }
}