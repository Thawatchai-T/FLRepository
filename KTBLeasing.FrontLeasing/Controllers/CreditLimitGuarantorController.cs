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
    public class CreditLimitGuarantorController : ApiController
    {
        private ICreditLimitRepository CreditLimitRepository { get; set; }

        // GET api/creditlimit
        public PagingModel<CreditLimitGuarantorView> Get(int start, int limit, long id)
        {
            PagingModel<CreditLimitGuarantorView> list = new PagingModel<CreditLimitGuarantorView>();
            list.data = CreditLimitRepository.GetGuarantor(start, limit, id);
            list.total = 0;

            return list;
        }

        //// POST api/creditlimit
        //public long Post(CreditLimitGuarantor value)
        //{
        //    value.CreateDate = DateTime.Now;

        //    return CreditLimitRepository.Insert(value);
        //}

        //// PUT api/creditlimit/5
        //public void Put(int id, CreditLimitGuarantor value)
        //{
        //    value.UpdateDate = DateTime.Now;

        //    CreditLimitRepository.Update(value);
        //}

        //// DELETE api/creditlimit/5
        //public void Delete(int id, CreditLimitGuarantor value)
        //{
        //    value.UpdateDate = DateTime.Now;

        //    CreditLimitRepository.Update(value);
        //}

        // POST api/cusinfo
        public long Post(List<CreditLimitGuarantor> list)
        {
            long result = 0;

            foreach (CreditLimitGuarantor value in list)
            {
                value.CreateDate = DateTime.Now;

                result = CreditLimitRepository.Insert<CreditLimitGuarantor>(value);
            }

            return result;
        }

        // PUT api/cusinfo/5
        public void Put(int id, List<CreditLimitGuarantor> list)
        {
            foreach (CreditLimitGuarantor value in list)
            {
                value.UpdateDate = DateTime.Now;

                CreditLimitRepository.Update<CreditLimitGuarantor>(value);
            }
        }

        // DELETE api/cusinfo/5
        public void Delete(int id, List<CreditLimitGuarantor> list)
        {
            foreach (CreditLimitGuarantor value in list)
            {
                value.UpdateDate = DateTime.Now;

                CreditLimitRepository.Delete<CreditLimitGuarantor>(value);
            }
        }

        //public void Delete(int id, List<CreditLimitGuarantor> list)
        //{
        //    foreach (CreditLimitGuarantor value in list)
        //    {
        //        value.UpdateDate = DateTime.Now;

        //        CreditLimitRepository.Update<CreditLimitGuarantor>(value);
        //    }
        //}
    }
}
