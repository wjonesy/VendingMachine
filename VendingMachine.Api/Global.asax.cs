using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using VendingMachine.Infrastructure;

namespace VendingMachine.Api
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // map default api routes
            GlobalConfiguration.Configuration.Routes.MapHttpRoute("Default",
                "{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });

            

            // enable cors globally for this example
            GlobalConfiguration.Configuration.EnableCors();

            // remove the xml formatter
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            // set camel case formatting
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.None;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var builder = DIConfig.ConfigureContainer(new ContainerBuilder());
            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

 

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}