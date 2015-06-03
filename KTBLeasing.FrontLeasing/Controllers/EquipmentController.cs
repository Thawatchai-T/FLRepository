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
    public class EquipmentController : ApiController
    {
        IIndicationEquipmentRepository IndicationEquipmentRepository { get; set; }
        // GET api/contact
        public List<Equipment> Get(int page, int start, int limit, long indicationId)
        {
            return IndicationEquipmentRepository.GetEquipment(indicationId);
        }

        // GET api/contact/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/contact
        public void Post(Equipment entity)
        {
            IndicationEquipmentRepository.SaveOrUpdate<Equipment>(entity);
        }

        // PUT api/contact/5
        public void Put(int id, Equipment entity)
        {
            IndicationEquipmentRepository.Update<Equipment>(entity);
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
        }
    }
}
