using Autofac;

namespace AutofacDemoConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = Container.Configure();
            using var scope = container.BeginLifetimeScope();
            var application = scope.Resolve<App>();

            application.Run();
        }
    }
}
