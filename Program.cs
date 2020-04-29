using System;
using Autofac;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AutofacDemoConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = Container.Configure();
            using var scope = container.BeginLifetimeScope();

            ValidateMapperConfiguration(scope);

            RunApp(scope);
        }

        private static void ValidateMapperConfiguration(ILifetimeScope scope)
        {

            var logger = scope.Resolve<ILogger<Program>>();

           try 
           {
                var mapperConfiguration = scope.Resolve<MapperConfiguration>();
                mapperConfiguration.AssertConfigurationIsValid();
                logger.LogDebug("Automapper Configuration is valid");
           } catch
           {
                logger.LogError("Automapper Configuration is not valid");     
           }
        }

        private static void RunApp(ILifetimeScope scope)
        {
            var application = scope.Resolve<App>();

            application.Run();
        }
    }
}
