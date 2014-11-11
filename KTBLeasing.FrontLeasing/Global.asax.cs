using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
<<<<<<< HEAD
using Spring.Web.Mvc;
using Newtonsoft.Json.Serialization;
=======
using KTBLeasing.FrontLeasing.Infrastucture;
>>>>>>> 3fb9ef84a38df9e0e9b729d65660aa776e3b5d78
using KTBLeasing.FrontLeasing.Infrastucture;

namespace KTBLeasing.FrontLeasing
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : SpringMvcApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
<<<<<<< HEAD

            //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            DI.Initialize();
        }

        protected override System.Web.Http.Dependencies.IDependencyResolver BuildWebApiDependencyResolver()
        {
            //get the 'default' resolver, populated from the 'main' config metadata
            var resolver = base.BuildWebApiDependencyResolver();
            
            //check if its castable to a SpringWebApiDependencyResolver
            var springResolver = resolver as SpringWebApiDependencyResolver;

            //if it is, add additional config sources as needed
            if (springResolver != null)
            {
                //springResolver.AddChildApplicationContextConfigurationLocation("file://~/Config/child_controllers.xml");
            }

            //return the fully-configured resolver
            return resolver;
=======
            DI.Initialize();
>>>>>>> 3fb9ef84a38df9e0e9b729d65660aa776e3b5d78
        }
    }
}