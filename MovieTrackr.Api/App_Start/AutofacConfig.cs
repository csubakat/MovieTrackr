using Autofac;
using OMDB.Api.Adapter.Clients;

namespace OMDB.Api.Adapter
{
    public static class AutofacConfig
    {
        public static void RegisterDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<OmdbClient>().As<IOmdbClient>().SingleInstance();
        }
    }
}