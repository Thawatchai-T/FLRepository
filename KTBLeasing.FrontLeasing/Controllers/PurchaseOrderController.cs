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
    public class PurchaseOrderController : ApiController
    {
        public IPurchaseOrderRepository PurchaseOrderRepository { get; set; }
        // GET api/contact
        public IEnumerable<PurchaseOrderModel> Get()
        {
            return new PurchaseOrderModel().Dummy();
        }

        // GET api/contact/5
        public string Get(int id)
        {
            return "value";
        }

        public List<PurchaseOrderModel> DoPost(PurchaseOrderModel form)
        {
            return null;
        }

        // POST api/contact
        public void Post(PurchaseOrder entity)
        {
            entity.ApplicationDetail.Id = entity.AppId;
            PurchaseOrderRepository.SaveOrUpdate(entity);
        }

        // PUT api/contact/5
        public void Put(long id, PurchaseOrder entity)
        {
            PurchaseOrderRepository.SaveOrUpdate(entity);
        }

        // DELETE api/contact/5
        public void Delete(long id)
        {
            //PurchaseOrderRepository.Delete(id);
        }
    }
}
