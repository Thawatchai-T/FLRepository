using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using log4net;
using System.Reflection;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class ApplicationDetailController : ApiController
    {
        private IApplicationDetailRepository ApplicationDetailRepository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // GET api/contact
        public List<ApplicationDetailModel> Get()
        {
            try
            {
                return new ApplicationDetailModel().Dummy();
                //return ApplicationDetailRepository.GetAll(0, 30, 1);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        // GET api/contact/5
        public string Get(int id)
        {
            return "value";
        }

        public List<ApplicationDetailModel> DoPost(ApplicationDetailModel entity)
        {
            try
            {
                var a = entity;
               // ApplicationDetailRepository.SaveOrUpdate(entity);
                List<ApplicationDetailModel> obj = new List<ApplicationDetailModel>();
                obj.Add(entity);
                return obj;
            }
            catch(Exception e)
            {
                Logger.Error(e);
            }
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
