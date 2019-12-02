using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace PlaygroundAutofac
{
    public class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<SomethingService>().AsSelf().AsImplementedInterfaces();



            //RegisterEventDetailLoaders(builder);


            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(type => type.IsAssignableTo<IEventTypeStrategyFinder>())
                .MultiKeyed<IEventTypeStrategyFinder>(type => type.GetCustomAttributes<EventTypeAttribute>().Select(a => a.EventTypeId))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }


        private static void RegisterEventDetailLoaders(ContainerBuilder builder)
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsAssignableTo<IEventTypeStrategyFinder>()))
            {
                var attrs = type.GetCustomAttributes<EventTypeAttribute>();
                foreach (var attr in attrs)
                {
                    builder.RegisterType(type).Keyed<IEventTypeStrategyFinder>(attr.EventTypeId)
                        .AsImplementedInterfaces()
                        .AsSelf()
                        .InstancePerLifetimeScope();
                }
            }
        }
    }
}