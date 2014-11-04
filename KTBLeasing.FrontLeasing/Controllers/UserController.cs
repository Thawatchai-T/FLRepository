using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;   
 

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class UserController : ApiController
    {
        private UsersAuthorizeRepository UsersAuthorizeRepository { get; set; }
        
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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
