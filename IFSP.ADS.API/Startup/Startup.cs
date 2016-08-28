using System.Web.Http;
using IFSP.ADS.API.Middlewares;
using IFSP.ADS.API.Startup;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using StructureMap;

[assembly: OwinStartup(typeof(Startup))]

namespace IFSP.ADS.API.Startup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var container = ConfigureDependencies(config);
            ConfigureWebApi(app, config, container);
            ConfigureJsonSettings(config);
        }

        private void ConfigureWebApi(IAppBuilder app, HttpConfiguration config, IContainer container)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.Use<RequestIdMiddleware>();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
            ConfigureDependencies(config);

        }

        private void ConfigureJsonSettings(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.JsonFormatter;
            config.Formatters.Remove(jsonFormatter);
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            config.Formatters.Insert(0, jsonFormatter);
        }
    }

}