using System.Collections.Generic;
using System.Linq;
using Autofac;
using CalculatorApplicationCore.ApplicationServices;
using CalculatorApplicationCore.Operations;
using CalculatorApplicationCore.ResultBuilder;

namespace CalculatorInfrastructure
{
    public class CalculatorIoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CalculateOperatorService>().As<ICalculateOperatorService>();
            builder.RegisterType<CalculatorApplicationService>().As<ICalculatorApplicationService>();

            builder.RegisterType<Plus>().As<ICalculateOperation>();
            builder.RegisterType<Minus>().As<ICalculateOperation>();
            builder.RegisterType<Divide>().As<ICalculateOperation>();
            builder.RegisterType<Multiply>().As<ICalculateOperation>();

            builder.RegisterType<CalculateResultBuilderNumber>().As<ICalculateResultBuilder>();
            builder.RegisterType<CalculateResultBuilderColor>().As<ICalculateResultBuilder>();
            builder.RegisterType<CalculateResultBuilderParity>().As<ICalculateResultBuilder>();

            var container = builder.Build();
            builder.Register(ctx =>
                {
                    var operations = container.Resolve<IEnumerable<ICalculateOperation>>()
                        .ToDictionary(x => x.Type.ToString());
                    return operations;
                })
                .As<IDictionary<string, ICalculateOperation>>().SingleInstance();


            builder.Register((ctx) =>
                {
                    var result = container.Resolve<IEnumerable<ICalculateResultBuilder>>()
                        .ToDictionary(x => x.Type.ToString());
                    return result;
                })
                .As<IDictionary<string, ICalculateOperation>>().SingleInstance();
        }
    }
}
