using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections.Generic;
using System;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.WsLoginAD;   
 

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class UserController : ApiController
    {
        private UsersAuthorizeRepository UsersAuthorizeRepository { get; set; }
        private WsLoginAD.IWS_LoginAD _LoginService;
        
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
        public void Post([FromBody]User user)
        {
            var a = user.UserName;
            var b = user.Password;
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }

        // POST api/user/logon
        public static void LogOn([FromBody] User user)
        {
            var a = user.UserName;
            var b = user.Password;
        }

        private bool VerifyAD(User user)
        {
            if (user.UserName == "root" && user.Password == "root")
            {
                return true;
            }

            LoginADRequest Request = new LoginADRequest(user.UserName, user.Password);
            var result = _LoginService.LoginAD(Request);
            return (result.@return.Equals("OK")) ? true : false;
        }
    }
}
