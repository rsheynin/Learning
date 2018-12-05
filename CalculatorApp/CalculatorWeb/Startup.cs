using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Multitenant;
using Calculator.Application.Service;
using Calculator.Operation.Domain.Service;
using Calculator.ResultBuilder.Domain.Service;
using CalculatorInfrastructure;
using CalculatorWeb.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CalculatorWeb
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }

        public IContainer ApplicationContainer { get; set; }
        
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public /*IServiceProvider*/ void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    //.AddControllersAsServices()
                    .AddJsonOptions(opt => opt
                            .SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore) //ignores self reference object 
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1); //validate api rules

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot/clientapp/dist";
            });


            #region Controllers

            //// If you want to set up a controller for, say, property injection
            //// you can override the controller registration after populating services.
            //builder.RegisterType<CalculateController>().PropertiesAutowired();
            //builder.RegisterType<CalculateResultTypeController>().PropertiesAutowired();
            //builder.RegisterType<OperatorController>().PropertiesAutowired();

            #endregion

            //IoCRegistration(services);
            //var serviceProvider = IoCContainerInitializer.Initialize(services);

            //return serviceProvider;
        }


        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you. If you
        // need a reference to the container, you need to use the
        // "Without ConfigureContainer" mechanism shown later.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new CalculatorIoCModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        //private static void IoCRegistration(IServiceCollection services)
        //{
        //    services.AddTransient<ICalculateOperatorService, CalculateOperatorService>();
        //    services.AddTransient<ICalculateResultTypeService, CalculateResultTypeService>();
        //    services.AddTransient<ICalculatorApplicationService, CalculatorApplicationService>();

        //    services.AddTransient<ICalculateOperation, Plus>();
        //    services.AddTransient<ICalculateOperation, Minus>();
        //    services.AddTransient<ICalculateOperation, Divide>();
        //    services.AddTransient<ICalculateOperation, Multiply>();

        //    services.AddTransient<ICalculateResultBuilder, CalculateResultBuilderNumber>();
        //    services.AddTransient<ICalculateResultBuilder, CalculateResultBuilderColor>();
        //    services.AddTransient<ICalculateResultBuilder, CalculateResultBuilderParity>();

        //    var serviceProvider = services.BuildServiceProvider();

        //    services.AddSingleton<IDictionary<string, ICalculateOperation>>((ctx) =>
        //    {
        //        var result = serviceProvider.GetServices<ICalculateOperation>().ToDictionary(x => x.Type);
        //        return result;
        //    });

        //    services.AddSingleton<IDictionary<string, ICalculateResultBuilder>>((ctx) =>
        //    {
        //        var result = serviceProvider.GetServices<ICalculateResultBuilder>().ToDictionary(x => x.Type.ToString());
        //        return result;
        //    });


        //}
    }
}
