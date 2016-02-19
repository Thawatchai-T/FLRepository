using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class CreditLimitDetailController : ApiController
    {
        private ICreditLimitRepository CreditLimitRepository { get; set; }

        // GET api/creditlimit
        public PagingModel<CreditLimitDetail> Get()
        {
            PagingModel<CreditLimitDetail> list = new PagingModel<CreditLimitDetail>();
            list.data = new List<CreditLimitDetail>();
            list.total = 0;

            return list;
        }

        // GET api/creditlimit/5
        public PagingModel<CreditLimitDetail> Get(int start, int limit, long id)
        {
            PagingModel<CreditLimitDetail> list = new PagingModel<CreditLimitDetail>();
            list.data = CreditLimitRepository.GetDetail(start, limit, id);
            list.total = CreditLimitRepository.CountDetail(id);

            return list;
        }
        
        //// POST api/creditlimit
        //public long Post(CreditLimitDetail value)
        //{
        //    value.CreateDate = DateTime.Now;

        //    return CreditLimitRepository.Insert(value);
        //}

        //// PUT api/creditlimit/5
        //public void Put(int id, CreditLimitDetail value)
        //{
        //    value.UpdateDate = DateTime.Now;

        //    CreditLimitRepository.Update(value);
        //}

        //// DELETE api/creditlimit/5
        //public void Delete(int id, CreditLimitDetail value)
        //{
        //    value.UpdateDate = DateTime.Now;

        //    CreditLimitRepository.Update(value);
        //}

        // POST api/cusinfo
        public long Post(List<CreditLimitDetail> list)
        {
            long result = 0;

            foreach (CreditLimitDetail value in list)
            {
                value.CreateDate = DateTime.Now;

                result = CreditLimitRepository.Insert<CreditLimitDetail>(value);
            }

            return result;
        }

        // PUT api/cusinfo/5
        public void Put(int id, List<CreditLimitDetail> list)
        {
            foreach (CreditLimitDetail value in list)
            {
                value.UpdateDate = DateTime.Now;

                CreditLimitRepository.Update<CreditLimitDetail>(value);
            }
        }

        // DELETE api/cusinfo/5
        public void Delete(int id, List<CreditLimitDetail> list)
        {
            foreach (CreditLimitDetail value in list)
            {
                value.UpdateDate = DateTime.Now;

                CreditLimitRepository.Update<CreditLimitDetail>(value);
            }
        }
    }
}
