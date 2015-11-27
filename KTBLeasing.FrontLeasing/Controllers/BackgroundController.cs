using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class BackgroundController : ApiController
    {
        private ICustomerRepository CustomerRepository { get; set; }
        // GET api/contact
        public IEnumerable<Background> Get()
        {
            //return new BackgroundModel().Dummy();
            return null;
        }

        public List<Background> Get(long custId)
        {
            return CustomerRepository.GetBackground(custId);
        }

        // GET api/contact/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/contact
        public void Post(Background entity)
        {
            CustomerRepository.Insert<Background>(entity);
        }

        // PUT api/contact/5
        public void Put(int id, Background entity)
        {
            CustomerRepository.Update<Background>(entity);
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
        }
    }
}
