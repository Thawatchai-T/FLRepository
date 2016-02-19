using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using System.Collections;
using Newtonsoft.Json;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class CreditLimitApprovalController : ApiController
    {
        private ICreditLimitRepository CreditLimitRepository { get; set; }

        // GET api/creditlimit
        public PagingModel<CreditLimitApproval> Get(int start, int limit)
        {
            PagingModel<CreditLimitApproval> list = new PagingModel<CreditLimitApproval>();
            list.data = CreditLimitRepository.GetApproval(start, limit);
            list.total = CreditLimitRepository.CountApproval();

            return list;
        }

        public CreditLimitApproval Get(long id)
        {
            return CreditLimitRepository.GetApproval(id);
        }

        public PagingModel<CreditLimitApproval> Get(int start, int limit, string filter)
        {
            List<FilterModel> listFilters = JsonConvert.DeserializeObject<List<FilterModel>>(filter);
            
            PagingModel<CreditLimitApproval> list = new PagingModel<CreditLimitApproval>();
            list.data = CreditLimitRepository.GetApproval(start, limit, listFilters);
            list.total = CreditLimitRepository.CountApproval(listFilters);

            return list;
        }

        // GET api/creditlimit/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/creditlimit
        public long Post(CreditLimitApproval value)
        {
            value.CreateDate = DateTime.Now;

            return CreditLimitRepository.Insert(value);
        }

        // PUT api/creditlimit/5
        public void Put(int id, CreditLimitApproval value)
        {
            value.UpdateDate = DateTime.Now;

            CreditLimitRepository.Update(value);
        }

        // DELETE api/creditlimit/5
        public void Delete(int id, CreditLimitApproval value)
        {
            value.UpdateDate = DateTime.Now;

            CreditLimitRepository.Update(value);
        }
    }
}
