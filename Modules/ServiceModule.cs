using Autofac;
using AutofacDemoConsole;
using AutofacDemoConsole.Services;

public class ServicesModule : Module
{
    protected override void Load(ContainerBuilder builder) 
    {
        builder.RegisterType<TestService>().As<ITestService>().InstancePerLifetimeScope();
        builder.RegisterType<App>().SingleInstance();
    }
}