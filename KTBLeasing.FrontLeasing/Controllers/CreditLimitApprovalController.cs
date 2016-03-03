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
using KTBLeasing.FrontLeasing.Domain.ViewModel;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class CreditLimitApprovalController : ApiController
    {
        private ICreditLimitRepository CreditLimitRepository { get; set; }

        // GET api/creditlimit
        public PagingModel<CreditLimitMasterView> Get(int start, int limit)
        {
            PagingModel<CreditLimitMasterView> list = new PagingModel<CreditLimitMasterView>();
            list.data = CreditLimitRepository.GetApproval(start, limit);
            list.total = CreditLimitRepository.CountApproval();

            return list;
        }

        public CreditLimitApproval Get(long id)
        {
            return CreditLimitRepository.GetApproval(id);
        }

        public PagingModel<CreditLimitMasterView> Get(int start, int limit, string filter)
        {
            List<FilterModel> listFilters = JsonConvert.DeserializeObject<List<FilterModel>>(filter);

            PagingModel<CreditLimitMasterView> list = new PagingModel<CreditLimitMasterView>();
            list.data = CreditLimitRepository.GetApproval(start, limit, listFilters);
            list.total = CreditLimitRepository.CountApproval(listFilters);

            return list;
        }

        public List<CreditLimitMasterView> Get(long customer_id, long limit_type, DateTime start_date, DateTime end_date)
        {
            return CreditLimitRepository.findDupCustomerInRange(customer_id, limit_type, start_date, end_date);
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

            CreditLimitRepository.Delete(value);
        }

        //public void Delete(int id, CreditLimitApproval value)
        //{
        //    value.UpdateDate = DateTime.Now;

        //    CreditLimitRepository.Update(value);
        //}
    }
}
