using System.Collections.Generic;
using System.Linq;
using Autofac;
using Calculator.Application.Service;
using Calculator.Operation.Domain.Service;
using Calculator.ResultBuilder.Domain.Service;

namespace CalculatorInfrastructure
{
    public class CalculatorIoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CalculateOperatorService>().As<ICalculateOperatorService>();
            builder.RegisterType<CalculateResultTypeService>().As<ICalculateResultTypeService>();
            builder.RegisterType<CalculatorApplicationService>().As<ICalculatorApplicationService>();

            builder.RegisterType<Plus>().As<ICalculateOperation>();
            builder.RegisterType<Minus>().As<ICalculateOperation>();
            builder.RegisterType<Divide>().As<ICalculateOperation>();
            builder.RegisterType<Multiply>().As<ICalculateOperation>();

            builder.RegisterType<CalculateResultBuilderNumber>().As<ICalculateResultBuilder>();
            builder.RegisterType<CalculateResultBuilderColor>().As<ICalculateResultBuilder>();
            builder.RegisterType<CalculateResultBuilderParity>().As<ICalculateResultBuilder>();

            builder.Register(ctx =>
                {
                    var operations = ctx.Resolve<IEnumerable<ICalculateOperation>>()
                        .ToDictionary(x => x.Type.ToString());
                    return operations;
                })
                .As<IDictionary<string, ICalculateOperation>>();//.SingleInstance();


            builder.Register((ctx) =>
                {
                    var result = ctx.Resolve<IEnumerable<ICalculateResultBuilder>>()
                        .ToDictionary(x => x.Type.ToString());
                    return result;
                })
                .As<IDictionary<string, ICalculateResultBuilder>>();//.SingleInstance();
        }
    }
}
