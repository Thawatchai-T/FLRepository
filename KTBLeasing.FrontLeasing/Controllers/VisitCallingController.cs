using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class VisitCallingController : ApiController
    {
        // GET api/visitcalling
        public IEnumerable<VisistCallModel> Get()
        {
            return new VisistCallModel().GenDummyData();
        }

        // GET api/visitcalling/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/visitcalling
        public void Post([FromBody]string value)
        {
        }

        // PUT api/visitcalling/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/visitcalling/5
        public void Delete(int id)
        {
        }
    }
}
