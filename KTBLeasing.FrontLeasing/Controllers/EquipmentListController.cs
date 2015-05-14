using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;
using log4net;
using System.Reflection;
using NHibernate.Criterion;
using NHibernate.Transform;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class EquipmentListController : ApiController
    {
        private IEquipmentListRepository EquipmentListRepository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        // GET api/contact

        public List<EquipmentListModel> Get()
        {
            return new EquipmentListModel().Dummy();
            //return EquipmentListRepository.GetAll(0, 5, id);
            //return EquipmentListRepository.GetAll();
        }

        public List<EquipmentList> Get(int page, int start, int limit, long id)
        {
            //return new EquipmentListModel().Dummy();
            return EquipmentListRepository.GetAll(0, 5, id);
        }

        // GET api/contact/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/contact
        public void Post(EquipmentList entity)
        {
            entity.ApplicationDetail.Id = entity.AppId;
            EquipmentListRepository.Insert(entity);
        }

        // PUT api/contact/5
        public void Put(long id, EquipmentList entity)
        {
            EquipmentListRepository.Update(entity);
        }

        // DELETE api/contact/5
        public void Delete(long id)
        {
            //EquipmentListRepository.Delete(id);
        }
    }
}
