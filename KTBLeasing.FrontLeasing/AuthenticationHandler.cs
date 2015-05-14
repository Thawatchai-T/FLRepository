using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Thinktecture.IdentityModel.Tokens.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace KTBLeasing.FrontLeasing
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken)
        {
                // Inspect and do your stuff with request here
                 
                // If you are not happy for any reason,
                // you can reject the request right here like this
 
                bool isBadRequest = false;
                if (isBadRequest)
                {
                        return Task<HttpResponseMessage>.Factory.StartNew(() =>
                        {
                                return request.CreateResponse(HttpStatusCode.BadRequest);
                        });
                }
                return base.SendAsync(request, cancellationToken)
                           .ContinueWith((task) =>
                           {
                               var response = task.Result;

                               // Inspect and do your stuff with response here
                               return response;
                           });
        }

        //HttpAuthentication _authN;

        //public AuthenticationHandler(
        //AuthenticationConfiguration configuration)
        //{
        //    _authN = new HttpAuthentication(configuration);
        //}

        //protected override Task<HttpResponseMessage> SendAsync(
        //HttpRequestMessage request,
        //CancellationToken cancellationToken)
        //{
        //    Thread.CurrentPrincipal = _authN.Authenticate(request);
        //    return base.SendAsync(request, cancellationToken);
        //}
    }
}
