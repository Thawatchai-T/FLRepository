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
    public class EquipmentDetailController : ApiController
    {
        //private IEquipmentDetailRepository EquipmentDetailRepository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        // GET api/contact
        public List<EquipmentDetailModel> Get()
        {
            return new EquipmentDetailModel().Dummy();
            //return EquipmentDetailRepository.GetAll(0, 5, 1);
        }

        // GET api/contact/5
        public string Get(int id)
        {
            return "value";
        }

        public List<EquipmentDetailModel> DoPost(EquipmentDetailModel form)
        {
            return null;
        }

        // POST api/contact
        public void Post([FromBody]string value)
        {
        }

        // PUT api/contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
        }
    }
}
