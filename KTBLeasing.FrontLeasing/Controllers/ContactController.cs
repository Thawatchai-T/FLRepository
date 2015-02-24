using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class ContactController : ApiController
    {
        private IContactRepository ContactRepository { get; set; }

        // GET api/contact
        public IEnumerable<Contact> Get(int custId, int page, int start, int limit)
        {
            try
            {
                return ContactRepository.GetByPage(custId, start, limit);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET api/contact/5
        public string Get(int id)
        {
            return "value";
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
        public bool DoPost(Contact form)
        {
            try
            {
                this.ContactRepository.SaveOrUpdate(form);
                //this.ContactRepository.Insert(form);
                return true;
            }
            catch (Exception ex)
            {
                
                throw;
                
                     
            }
            
        }
    }
}
