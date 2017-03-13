using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace OMDB.Api.Adapter
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // Web API configuration and services
            var builder = new ContainerBuilder();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterDependencies();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            
        }
    }
}
