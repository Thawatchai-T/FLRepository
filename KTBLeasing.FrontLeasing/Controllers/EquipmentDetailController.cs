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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class EquipmentDetailController : ApiController
    {
        private IEquipmentDetailRepository EquipmentDetailRepository { get; set; }
        private IApplicationDetailRepository ApplicationDetailRepository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        // GET api/contact
        public JArray Get(int page, int start, int limit, long id)
        {
            //return new EquipmentDetailModel().Dummy();
            //return EquipmentDetailRepository.GetAll(0, 15, id);
            var listEquipmentDetail = ApplicationDetailRepository.GetAll<EquipmentDetail>(0, 30, id, new EquipmentDetail(), "EquipmentList");
            var json = JsonConvert.SerializeObject(listEquipmentDetail);
            var result = JArray.Parse(json);
            return result;
        }

        // GET api/contact/5
        public EquipmentDetail GetLoad(int id, string entity)
        {

            return new EquipmentDetail();
        }

        public List<EquipmentDetailModel> DoPost(EquipmentDetailModel form)
        {
            return null;
        }

        // POST api/contact
        public void Post([FromBody]string value)
        {
        }

        public void DoPost(EquipmentDetail entity)
        {
            try
            {
                EquipmentDetailRepository.SaveOrUpdate(entity);

            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
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
