using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;

namespace KTBLeasing.FrontLeasing
{
    public class TimeShareAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext context)
        {
            IPrincipal principal = Thread.CurrentPrincipal;
            // If principal.IsInRole("TimeSharer")
            // Check if current time is between allocated slot start and end times
            // If not, return false
            return true;
        }

        // If 401 – Unauthorized is okay for you, no need to override
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }
    }
}