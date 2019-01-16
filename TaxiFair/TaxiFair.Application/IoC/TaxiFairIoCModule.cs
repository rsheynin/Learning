using Autofac;
using TaxiFair.Application.Repository;
using TaxiFair.Domain.Repository;
using TaxiFair.Domain.Services;
using TaxiFair.Infrastructure;

namespace TaxiFair.Application.IoC
{
    public class TaxiFairIoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FareRateService>().As<IFareRateService>();
            builder.RegisterType<TaxiFairCalculatorService>().As<ITaxiFairCalculatorService>();

            builder.RegisterType<FareRateRepository>().As<IFareRateRepository>();
            builder.RegisterType<CompanyFeeRepository>().As<ICompanyFeeRepository>();
            builder.RegisterType<CarRepository>().As<ICarRepository>();
            builder.RegisterType<DateTimeWrapper>().As<IDateTimeWrapper>();
        }
    }
}
