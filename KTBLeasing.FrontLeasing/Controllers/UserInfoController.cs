using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class UserInfoController : ApiController
    {
        private IUserInfomationRepository UserInfomationRepository { get; set; }
        // GET api/userinfo
        public IEnumerable<UserInformation> Get()
        {
            return UserInfomationRepository.GetAll();
        }

        // GET api/userinfo/5
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/userinfo
        //public void Post([FromBody]string value)
        //{
        //    value += value;
        //}

        // POST api/userinfo
        public string DoPost([FromBody]string value)
        {
            value += value;
            return value.ToString();
        }

        // PUT api/userinfo/5
        public void Put(int id, [FromBody]string value)
        {
            value += value;
        }

        // DELETE api/userinfo/5
        public void Delete(int id)
        {
        }
    }
}
