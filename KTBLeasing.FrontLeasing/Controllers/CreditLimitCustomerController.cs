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
    public class CreditLimitCustomerController : ApiController
    {
        private ICreditLimitRepository CreditLimitRepository { get; set; }

        // GET api/creditlimit
        public PagingModel<CreditLimitCustomerView> Get(int start, int limit, long id)
        {
            PagingModel<CreditLimitCustomerView> list = new PagingModel<CreditLimitCustomerView>();
            list.data = CreditLimitRepository.GetCustomer(start, limit, id);
            list.total = 0;

            return list;
        }

        //// POST api/creditlimit
        //public long Post(CreditLimitCustomer value)
        //{
        //    value.CreateDate = DateTime.Now;

        //    return CreditLimitRepository.Insert(value);
        //}

        //// PUT api/creditlimit/5
        //public void Put(int id, CreditLimitCustomer value)
        //{
        //    value.UpdateDate = DateTime.Now;

        //    CreditLimitRepository.Update(value);
        //}

        //// DELETE api/creditlimit/5
        //public void Delete(int id, CreditLimitCustomer value)
        //{
        //    value.UpdateDate = DateTime.Now;

        //    CreditLimitRepository.Update(value);
        //}

        // POST api/cusinfo
        public long Post(List<CreditLimitCustomer> list)
        {
            long result = 0;

            foreach (CreditLimitCustomer value in list)
            {
                value.CreateDate = DateTime.Now;

                result = CreditLimitRepository.Insert<CreditLimitCustomer>(value);
            }

            return result;
        }

        // PUT api/cusinfo/5
        public void Put(int id, List<CreditLimitCustomer> list)
        {
            foreach (CreditLimitCustomer value in list)
            {
                value.UpdateDate = DateTime.Now;

                CreditLimitRepository.Update<CreditLimitCustomer>(value);
            }
        }

        // DELETE api/cusinfo/5
        public void Delete(int id, List<CreditLimitCustomer> list)
        {
            foreach (CreditLimitCustomer value in list)
            {
                value.UpdateDate = DateTime.Now;

                CreditLimitRepository.Delete<CreditLimitCustomer>(value);
            }
        }

        //public void Delete(int id, List<CreditLimitCustomer> list)
        //{
        //    foreach (CreditLimitCustomer value in list)
        //    {
        //        value.UpdateDate = DateTime.Now;

        //        CreditLimitRepository.Update<CreditLimitCustomer>(value);
        //    }
        //}
    }
}
