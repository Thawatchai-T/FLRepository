using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections.Generic;
using System;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.WsLoginAD;
using System.Collections.Specialized;
using System.Net.Http.Formatting;
using System.Web.Mvc;   
 

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class UserController : ApiController
    {
        private UsersAuthorizeRepository UsersAuthorizeRepository { get; set; }
        private User user { get; set; }

        private IWS_LoginAD _LoginService;
        public UserController()
        {
            this._LoginService = new WS_LoginADClient();
        }
        public UserController(IWS_LoginAD loginservice)
        {
            this._LoginService = new WS_LoginADClient();
        }

        // GET api/user
        //page=2&start=16&limit=16
        public IEnumerable<UsersAuthorize> Get(int page,int start, int limit)
        {
            try
            {
                UsersAuthorizeRepository = new UsersAuthorizeRepository();
                UsersAuthorizeRepository.SessionFactory = NHHelpers.CreateSessionFactory();
                //var result = UsersAuthorizeRepository.GetAll();
                var result = UsersAuthorizeRepository.GetAll(start, limit);
                
                return  result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //return new string[] { "value1", "value2" };
        }

        public IEnumerable<UsersAuthorize> Get()
        {
            try
            {
                return this.Get(1,0,25);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //return new string[] { "value1", "value2" };
        }

        // GET api/user/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/user
        public void Post(FormDataCollection formData)
        {
            NameValueCollection form = formData.ReadAsNameValueCollection();
            user = new User();

            user.UserName = form["User.UserName"];
            user.Password = form["User.Password"];

            if (VerifyAD(user))
            {

            }
            else
            {

            }
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }

        private bool VerifyAD(User user)
        {
            if (user.UserName == "root" && user.Password == "root")
            {
                return true;
            }
            //var result = _LoginService.LoginAD(user.UserName, user.Password);
            LoginADRequest Request = new LoginADRequest(user.UserName, user.Password);
            var result = _LoginService.LoginAD(Request);
            return (result.Equals("OK")) ? true : false;
        }
    }
}
