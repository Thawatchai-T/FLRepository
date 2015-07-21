using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;
using Newtonsoft.Json.Linq;
using KTBLeasing.FrontLeasing.Domain;
using log4net;
using System.Reflection;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using Newtonsoft.Json;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class JobController : ApiController
    {
        private IJobRepository jobRepository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // GET api/job
        public JobModel Get(int start, int limit)
        {
            try
            {
                JobModel model = new JobModel();
                model.data = jobRepository.Get(start, limit);
                model.total = jobRepository.Count();

                return model;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        // POST api/job
        public void Post(Job entity)
        {
            jobRepository.SaveOrUpdate(entity);
        }

        // PUT api/job/5
        public void Put(long id, Job entity)
        {
            jobRepository.Update(entity);
        }

        // DELETE api/job/5
        public void Delete(int id)
        {
        }
    }
}
