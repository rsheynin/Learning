using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorInfrastructure
{
    public static class IoCContainerInitializer
    {
        public static IServiceProvider Initialize(IServiceCollection services)
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.Populate(services);

            
            var appContainer = builder.Build();

            return new AutofacServiceProvider(appContainer);
        }
    }
}