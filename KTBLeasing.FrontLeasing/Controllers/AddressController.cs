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
    public class AddressController : ApiController
    {
        private ComboboxRepository comboboxRepository { get; set; }
        // GET api/address
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/address/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/address
        public void Post([FromBody]string value)
        {
        }

        // PUT api/address/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/address/5
        public void Delete(int id)
        {
        }

        public List<Province> GetProvince()
        {
            try
            {
                return comboboxRepository.GetProvince();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
