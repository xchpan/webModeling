using System.Configuration;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using ModelViewModelConverterContracts;
using ModelViewModelConverters;
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
            var cassandraIp = ConfigurationManager.ConnectionStrings["cassandraStore"].ConnectionString;
            builder.RegisterType<PlantSummaryRepository>().As<IPlantSummaryRepository>().SingleInstance()
                .WithParameter(new NamedParameter("ip", cassandraIp));
            builder.RegisterType<LibraryService>().As<ILibraryService>().InstancePerRequest();
            builder.RegisterType<PlantSummaryService>().As<IPlantSummaryService>().InstancePerRequest();

            var mongoStore = ConfigurationManager.ConnectionStrings["mongoStore"].ConnectionString;
            builder.RegisterType<VariableTypeRepository>()
                .As<IVariableTypeRepository>()
                .OnActivating(e => e.Instance.Initialize(mongoStore))
                .SingleInstance();

            builder.RegisterType<FluidComponentTypeRepository>()
                .As<IFluidComponentTypeRepository>()
                .OnActivating(e => e.Instance.Initialize(mongoStore))
                .SingleInstance();

            builder.RegisterType<ModelToViewModel>()
                .As<IModelToViewModel>()
                .SingleInstance();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
}
