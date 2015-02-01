using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using xpan.plantDesign.ApplicationServices;
using xpan.plantDesign.Repository;

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
            builder.RegisterType<PlantSummaryRepository>().As<IPlantSummaryRepository>().SingleInstance();
            builder.RegisterType<LibraryService>().As<ILibraryService>().InstancePerRequest();
            builder.RegisterType<PlantSummaryService>().As<IPlantSummaryService>().InstancePerRequest();

            builder.RegisterType<VariableTypeRepository>()
                .As<IVariableTypeRepository>()
                .OnActivating(e => e.Instance.Initialize())
                .SingleInstance();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
}
