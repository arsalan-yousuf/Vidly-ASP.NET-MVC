using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FirstWebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var camelSettings = config.Formatters.JsonFormatter.SerializerSettings;
            camelSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            camelSettings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
