using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.Domain;
using Common.Logging;
using System.Reflection;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class SignerController : ApiController
    {
        private ICustomerSignerRepository CustomerSignerRepository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        // GET api/signer
        public IEnumerable<CustomerSignerDomain> Get(string custId, int page, int start, int limit)
        {
            try
            {
                return CustomerSignerRepository.GetAll(int.Parse(custId),start,limit);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        // GET api/signer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/signer
        public void Post([FromBody]string value)
        {
        }

        public bool DoPost(CustomerSignerDomain entity)
        {
            try
            {
                Logger.Debug(entity.SpouseFirstNameEng);
                return CustomerSignerRepository.SaveOrUpdate(entity);
            }
            catch(Exception e)
            {
                Logger.Error(e);
                return false;
            }

        }
        // PUT api/signer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/signer/5
        public void Delete(int id)
        {
        }
    }
}
