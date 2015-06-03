using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using log4net;
using System.Reflection;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class ThirdPartyController : ApiController
    {
        private IThirdPartyRepository ThirdPartyRepository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // GET api/contact
        public List<ThirdParty> Get()
        {
            return ThirdPartyRepository.GetAll();
        }

        // GET api/contact/5
        public string Get(int id)
        {
            return "value";
        }

        public List<ThirdPartyModel> DoPost(ThirdPartyModel form)
        {
            return null;
        }

        // POST api/contact
        public void Post([FromBody]string value)
        {
        }

        // PUT api/contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
        }
    }
}
