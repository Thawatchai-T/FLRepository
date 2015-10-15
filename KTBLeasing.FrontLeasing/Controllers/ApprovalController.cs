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
    public class ApprovalController : ApiController
    {
        private IInformationIndicationRepository InformationIndicationRepository { get; set; }

        // GET api/contact
        public List<ApprovalModel> Get()
        {
            return new ApprovalModel().Dummy();
        }

        // GET api/contact/5
        public List<Approval> Get(long infoId)
        {
            return InformationIndicationRepository.GetApproval(infoId);
        }

        // POST api/contact
        public void Post(Approval value)
        {

            value.InformationIndication.Id = value.InformationId;
            InformationIndicationRepository.Insert<Approval>(value);
        }

        // PUT api/contact/5
        public void Put(int id, Approval value)
        {
            InformationIndicationRepository.Update<Approval>(value);
        }

        // DELETE api/contact/5
        public void Delete(int id, Approval value)
        {
            InformationIndicationRepository.Delete<Approval>(value);
        }
    }
}
