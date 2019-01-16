using System.Collections.Generic;
using Calculate.Common.Const;
using Calculator.Application.Service;
using Calculator.Operation.Domain.Service;
using Calculator.ResultBuilder.Domain.Service;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace Tests
{
    [TestClass]
    public class CalculatorApplicationServiceTest
    {
        private const int CALCULATE_OPERATION_RESULT = 100;

        private CalculatorApplicationService _target;

        private ICalculateOperation _stubOperation;
        private IDictionary<string, ICalculateOperation> _stubOperations;
        private ICalculateResultBuilder _stubResultBuilder;
        private IDictionary<string, ICalculateResultBuilder> _stubResultBuilders;

        private ICalculateResult _expected;

        private readonly CalculateOperationDto _fakeCalculationOperationDto = new CalculateOperationDto
        {
            Operator = CalculatorConst.PLUS,
            ResultType = CalculateResultType.Number.ToString()
        };
        private readonly ICalculateResult _fakeCalculateResult = new CalculateResultNumber(CALCULATE_OPERATION_RESULT);

        [TestInitialize]
        public void InIt()
        {
            _stubOperation = A.Fake<ICalculateOperation>();
            _stubOperations = A.Fake<IDictionary<string,ICalculateOperation>>();
            A.CallTo(() => _stubOperations[CalculatorConst.PLUS]).Returns(_stubOperation);

            _stubResultBuilder = A.Fake<ICalculateResultBuilder>();
            _stubResultBuilders = A.Fake<IDictionary<string,ICalculateResultBuilder>>();
            A.CallTo(() => _stubResultBuilders[CalculateResultType.Number.ToString()]).Returns(_stubResultBuilder);

            _target = new CalculatorApplicationService(_stubOperations,_stubResultBuilders);

        }

        [TestMethod]
        public void Calculate_PlusTwoArguments_OperationHappened()
        {
            _target.Calculate(_fakeCalculationOperationDto);

            A.CallTo(() => _stubOperation.Calculate(_fakeCalculationOperationDto)).MustHaveHappened();
        }

        [TestMethod]
        public void Calculate_PlusTwoArguments_ResultBuilderHappened()
        {
            A.CallTo(() => _stubOperation
                    .Calculate(_fakeCalculationOperationDto))
                .Returns(CALCULATE_OPERATION_RESULT);

           _target.Calculate(_fakeCalculationOperationDto);

            A.CallTo(() => _stubResultBuilder.Build(CALCULATE_OPERATION_RESULT)).MustHaveHappened();
        }


        [TestMethod]
        public void Calculate_PlusTwoArguments_CalculatedResult()
        {
            A.CallTo(() => _stubOperation
                .Calculate(_fakeCalculationOperationDto))
                .Returns(CALCULATE_OPERATION_RESULT);

            A.CallTo(() => _stubResultBuilder
                    .Build(CALCULATE_OPERATION_RESULT))
                .Returns(_fakeCalculateResult);

           _expected = new CalculateResultNumber(CALCULATE_OPERATION_RESULT);

            var actual = _target.Calculate(_fakeCalculationOperationDto);
            
            //actual.Should().BeEquivalentTo(_expected, options => options.IncludingFields());
            CompareReferenceObjects.Assert(_expected,actual);
        }
    }
}
