using Autofac;
using VideoBlock.Data.Implementation;
using VideoBlock.Data.Interface;

namespace VideoBlock.Business
{
    public class BusinessLogicModules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //base.Load(builder);

            // optional: chain ServiceModule with other modules for going deeper down in the architecture: 
            //builder.RegisterModule<RepositoryModule>();

            builder.RegisterType<ClienteRepository>().As<IClienteRepository>();
            builder.RegisterType<TablasGeneralesRepository>().As<ITablasGeneralesRepository>();
            builder.RegisterType<SeguridadRepository>().As<ISeguridadRepository>();
            builder.RegisterType<PeliculaRepository>().As<IPeliculaRepository>();

            // ... register more services for that layer
        }
    }
}
