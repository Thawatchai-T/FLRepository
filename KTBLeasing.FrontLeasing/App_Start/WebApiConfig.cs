using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace KTBLeasing.FrontLeasing
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           /** [20141117] woody add config for custom function in webapi */ 
            
            // Route for POST method
            config.Routes.MapHttpRoute(
            name: "DefaultApi2",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            //   Route  GET method
            config.Routes.MapHttpRoute(
               name: "DefaultApi1",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { action = "get", id = RouteParameter.Optional }
            );
        }
    }
}
