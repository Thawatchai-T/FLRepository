using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class CusInfoController : ApiController
    {
        // GET api/cusinfo
        public IEnumerable<CusInfoModel> Get()
        {
            return new CusInfoModel().Dummy();
        }

        // GET api/cusinfo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/cusinfo
        public void Post([FromBody]string value)
        {
        }

        // PUT api/cusinfo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/cusinfo/5
        public void Delete(int id)
        {
        }
    }
}
