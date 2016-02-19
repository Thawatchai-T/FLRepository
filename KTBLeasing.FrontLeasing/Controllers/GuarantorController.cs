using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;
using Newtonsoft.Json;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class GuarantorController : ApiController
    {
        IGuarantorRepository GuarantorRepository { get; set; }
        // GET api/contact
        public PagingModel<GuarantorModel> Get(string filter)
        {
            List<FilterModel> listFilters = JsonConvert.DeserializeObject<List<FilterModel>>(filter);

            return this.Get(1, 25, Convert.ToInt64(listFilters[0].value));
        }

        public PagingModel<GuarantorModel> Get(int start,int limit)
        {
            PagingModel<GuarantorModel> list = new PagingModel<GuarantorModel>();
            list.data = GuarantorRepository.GetList(start, limit);
            list.total = GuarantorRepository.Count();
            return list;
        }

        public PagingModel<GuarantorModel> Get(int start, int limit, long cl_id)
        {
            PagingModel<GuarantorModel> list = new PagingModel<GuarantorModel>();
            list.data = GuarantorRepository.GetList(start, limit, cl_id);
            list.total = GuarantorRepository.Count(cl_id);
            return list;
        }

        // GET api/contact/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/contact
        public void Post(List<GuarantorModel> list)
        {
            foreach (GuarantorModel value in list)
            {
                value.CreateDate = DateTime.Now;

                GuarantorRepository.Insert<GuarantorModel>(value);
            }
        }

        // PUT api/contact/5
        public void Put(int id, List<GuarantorModel> list)
        {
            foreach (GuarantorModel value in list)
            {
                value.UpdateDate = DateTime.Now;

                GuarantorRepository.Update<GuarantorModel>(value);
            }
        }

        // DELETE api/contact/5
        public void Delete(int id, List<GuarantorModel> list)
        {
            foreach (GuarantorModel value in list)
            {
                value.UpdateDate = DateTime.Now;

                GuarantorRepository.Update<GuarantorModel>(value);
            }
        }
    }
}
