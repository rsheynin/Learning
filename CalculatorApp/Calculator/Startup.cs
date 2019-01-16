
using System.Collections.Generic;
using System.Linq;
using Calculator.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Calculator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore) //ignores self reference object 
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1); //validate api rules

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot/clientapp/dist";
            });

            IoCRegistration(services);
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

        private static void IoCRegistration(IServiceCollection services)
        {
            services.AddTransient<ICalculateOperatorService, CalculateOperatorService>();
            services.AddTransient<ICalculateResultTypeService, CalculateResultTypeService>();
            services.AddTransient<ICalculatorApplicationService, CalculatorApplicationService>();

            services.AddTransient<ICalculateOperation, Plus>();
            services.AddTransient<ICalculateOperation, Minus>();
            services.AddTransient<ICalculateOperation, Divide>();
            services.AddTransient<ICalculateOperation, Multiply>();

            services.AddTransient<ICalculateResultBuilder, CalculateResultBuilderNumber>();
            services.AddTransient<ICalculateResultBuilder, CalculateResultBuilderColor>();
            services.AddTransient<ICalculateResultBuilder, CalculateResultBuilderParity>();

            var serviceProvider = services.BuildServiceProvider();

            services.AddSingleton<IDictionary<string, ICalculateOperation>>((ctx) =>
            {
                var result = serviceProvider.GetServices<ICalculateOperation>().ToDictionary(x => x.Type);
                return result;
            });

            services.AddSingleton<IDictionary<string, ICalculateResultBuilder>>((ctx) =>
            {
                var result = serviceProvider.GetServices<ICalculateResultBuilder>().ToDictionary(x => x.Type.ToString());
                return result;
            });


        }
    }
}
