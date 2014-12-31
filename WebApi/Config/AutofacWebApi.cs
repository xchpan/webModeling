using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using xpan.plantDesign.ApplicationServices;

namespace xpan.plantDesign.WebApi.Config
{
    public class AutofacWebApi
    {
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Services
            builder.RegisterType<LibraryService>().As<ILibraryService>().InstancePerRequest();
            builder.RegisterType<PlantSummaryService>().As<IPlantSummaryService>().InstancePerRequest();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
}
