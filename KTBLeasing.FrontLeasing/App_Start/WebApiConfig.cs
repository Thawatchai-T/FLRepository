using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.WebHost;

namespace KTBLeasing.FrontLeasing
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           /** [20141118] woody add config for custom function in webapi */
            config.Routes.MapHttpRoute(
                name: "ApiById",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^[0-9]+$" }
            );

            config.Routes.MapHttpRoute(
                name: "ApiByName",
                routeTemplate: "api/{controller}/{action}/{name}",
                defaults: null,
                constraints: new { name = @"^[a-z]+$" }
            );

            config.Routes.MapHttpRoute(
                name: "ApiByAction",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = "Get" }
            );
            //config.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
            //new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
