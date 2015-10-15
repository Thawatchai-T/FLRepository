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
    public class InformationIndicationController : ApiController
    {
        private IInformationIndicationRepository InformationIndicationRepository { get; set; }
        // GET api/contact
        public List<InformationIndication> Get(int page, int start, int limit)
        {
            //return new InformationIndicationModel().Dummy();
            var result = InformationIndicationRepository.GetAll();

            return result;
        }

        public List<Background> GetBackground(long infoId)
        {
            return InformationIndicationRepository.GetBackground(infoId);
        }

        // GET api/contact/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/contact
        public void Post(InformationIndication entity)
        {
            InformationIndicationRepository.Insert<InformationIndication>(entity);
        }

        // PUT api/contact/5
        public void Put(int id, InformationIndication entity)
        {
            InformationIndicationRepository.Update<InformationIndication>(entity);
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
        }
    }
}
