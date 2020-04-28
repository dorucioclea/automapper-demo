using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AutofacDemoConsole.Models;
using AutofacDemoConsole.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace AutofacDemoConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var container = ConfigureContainer(serviceCollection);

            using var scope = container.BeginLifetimeScope();

            var application = scope.Resolve<App>();

            application.Run();
        }

        private static IContainer ConfigureContainer(IServiceCollection serviceDescriptors) 
        {
            var autofacBuilder = new ContainerBuilder();
            autofacBuilder.Populate(serviceDescriptors);
            autofacBuilder.RegisterModule(new ServicesModule());
            var container = autofacBuilder.Build();
            return container;
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // build configuration
            var loggerFactory = LoggerFactory.Create(ConfigureLogging);

            // add logging
            serviceCollection.AddSingleton(loggerFactory);
            serviceCollection.AddLogging(); 

            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app-settings.json", false)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            ConfigureConsole(configuration);
        }

         private static void ConfigureLogging(ILoggingBuilder loggingBuilder) 
            {
                loggingBuilder
                    .AddFilter ("Microsoft", LogLevel.Warning)
                    .AddFilter ("System", LogLevel.Warning)
                    .AddFilter ("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole ()
                    .AddDebug ();
            }

        private static void ConfigureConsole(IConfigurationRoot configuration)
        {
            System.Console.Title = configuration.GetSection("AppSettings:ConsoleTitle").Value;        
        }
    }
}
