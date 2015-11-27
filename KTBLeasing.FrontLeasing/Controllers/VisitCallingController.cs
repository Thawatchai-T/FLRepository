using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class VisitCallingController : ApiController
    {
        public IVisitInformationRepository VisitInformationRepository { get; set; }
        public ICommonDataRepository CommonDataRepository { get; set; }

        // GET api/visitcalling
        public IEnumerable<VisistCallModel> Get()
        {
           //VisitInformationRepository
            return new VisistCallModel().GenDummyData();
        }

        // GET api/visitcalling/5
        public string Get(int id)
        {
            VisitInformationDomain result = VisitInformationRepository.GetBYID(id);
            
            return "value";
        }

        public List<VisitInformationDomain> Get(int page, int start,int limit)
        {
            return VisitInformationRepository.Get(start, limit);
        }

        public List<VisitInformationDomain> Get(int page, int start, int limit, long jobId)
        {
            return VisitInformationRepository.Get(start, limit, jobId);
        }

        // POST api/visitcalling
        public void Post(VisitInformationDomain value)
        {
            VisitInformationRepository.Insert(value);
        }

        // PUT api/visitcalling/5
        public void Put(int id, VisitInformationDomain value)
        {
            VisitInformationRepository.Update(value);
        }

        // DELETE api/visitcalling/5
        public void Delete(int id)
        {
        }

        public bool DoPost(VisistCallModel form)
        {
            try
            {
                var model = form;
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw;
            }
        }


        private void GetMapAddress(int id)
        {
                     
        }

        private void GetMapContactPerson(int id)
        {

        }

        private void FinancialPolicyModel(string final)
        {

        }
    }
}
