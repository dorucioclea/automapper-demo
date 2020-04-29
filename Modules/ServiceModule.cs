using Autofac;
using AutofacDemoConsole.Services;

namespace AutofacDemoConsole {
    public class ServicesModule : Module 
    {
        protected override void Load (ContainerBuilder builder) {
            builder.RegisterType<TestService> ().As<ITestService> ().InstancePerLifetimeScope ();
            builder.RegisterType<AddressFormattingService>().As<IAddressFormattingService>().InstancePerLifetimeScope();
            builder.RegisterType<App> ().SingleInstance ();
        }
    }
}