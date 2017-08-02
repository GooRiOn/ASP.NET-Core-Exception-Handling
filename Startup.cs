using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ExceptionHandling.ExceptionHandlers;
using ExceptionHandling.Exceptions;
using ExceptionHandling.Executors;
using ExceptionHandling.IoC;
using ExceptionHandling.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ExceptionHandling
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; }

       
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {			
			services.AddMvc();

			var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterType<CustomDependencyResolver>().As<ICustomDependencyResolver>();
            containerBuilder.RegisterType<ExceptionHandlerExecutor>().As<IExceptionHandlerExecutor>();
            containerBuilder.RegisterType<NoValuesFoundExceptionHandler>().As<IExceptionHandler<NoValuesFoundException>>();
            ApplicationContainer = containerBuilder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var executor = ApplicationContainer.Resolve<IExceptionHandlerExecutor>();
            app.UseMiddleware<ErrorHandlerMiddleware>(executor);
            app.UseMvc();
        }
    }
}
