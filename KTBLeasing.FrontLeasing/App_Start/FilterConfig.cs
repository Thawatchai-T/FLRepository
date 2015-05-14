using System.Web;
using System.Web.Mvc;
//using Thinktecture.IdentityModel.Authorization.WebApi;
using System;

namespace KTBLeasing.FrontLeasing
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //try
            //{
            //    filters.Add(new ClaimsAuthorizeAttribute());
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}

           // filters.Add(new AuthorizeAttribute());

        }
    }
}