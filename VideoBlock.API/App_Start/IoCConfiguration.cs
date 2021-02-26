using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using VideoBlock.Business;
using VideoBlock.Business.Implementation;
using VideoBlock.Business.Interface;

namespace VideoBlock.API.App_Start
{
    public static class IoCConfiguration
    {
        public static IContainer Container;

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
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ClienteBusiness>()
                   .As<IClienteBusiness>()
                   .InstancePerRequest();
            //.SingleInstance();

            builder.RegisterType<TablasGeneralesBusiness>()
                   .As<ITablasGeneralesBusiness>()
                   .InstancePerRequest();

            builder.RegisterType<SeguridadBusiness>()
                   .As<ISeguridadBusiness>()
                   .InstancePerRequest();

            //builder.RegisterGeneric(typeof(ClienteBusiness<>))
            //       .As(typeof(IClienteBusiness<>))
            //       .InstancePerRequest();

            //registrar las servicios, repositorios de otras capas/proyectos de la solución
            builder.RegisterModule<BusinessLogicModules>();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}