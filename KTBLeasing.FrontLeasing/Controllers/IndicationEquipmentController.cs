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
    public class IndicationEquipmentController : ApiController
    {
        IIndicationEquipmentRepository IndicationEquipmentRepository { get; set; }
        // GET api/contact
        public List<IndicationEquipment> Get(int page, int start, int limit, long jobId)
        {
            return IndicationEquipmentRepository.GetAll(start, limit, jobId);
        }

        // GET api/contact/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/contact
        public void Post(IndicationEquipment entity)
        {
            IndicationEquipmentRepository.Insert<IndicationEquipment>(entity);
        }

        // PUT api/contact/5
        public void Put(int id, IndicationEquipment entity)
        {
            IndicationEquipmentRepository.Update<IndicationEquipment>(entity);
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
        }
    }
}
