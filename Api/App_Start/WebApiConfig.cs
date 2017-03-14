using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Api
{
    using System.Net.Http.Formatting;

    using Newtonsoft.Json;

    /// <summary>
    /// The web API config.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(formatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
