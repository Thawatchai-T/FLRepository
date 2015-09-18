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
using Com.Ktbl.Database.DB2.Repository;
using KTBLeasing.Helpers;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class RestructureController : ApiController
    {
        private IRestructureRepository restructureRepository { get; set; }
        private Repository DB2Repository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        // GET api/restructure
        public RestructureListModel Get(int start, int limit, string user_id, string user_group, int marketing_group)
        {
            try
            {
                RestructureListModel model = new RestructureListModel();
                model.data = restructureRepository.Get(start, limit, user_id, user_group, marketing_group);
                model.total = restructureRepository.Count(user_id, user_group, marketing_group);

                return model;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        // GET api/restructure/5
        public RestructureListModel Get(int start, int limit, string user_id, string user_group, int marketing_group, string agrcode)
        {
            try
            {
                RestructureListModel model = new RestructureListModel();
                model.data = restructureRepository.Get(start, limit, user_id, user_group, marketing_group, agrcode);
                model.total = restructureRepository.Count(user_id, user_group, marketing_group, agrcode);

                return model;
            }
            catch (Exception ex)
            { 
                Logger.Error(ex);
                return null;
            }
        }

        // POST api/restructure
        public long Post(Restructure entity)
        {
            if (entity.Id == 0)
            {
                var id = restructureRepository.Insert(entity);
                return id;
            }
            else
            {
                restructureRepository.Update(entity);
                return entity.Id;
            }
        }

        // PUT api/restructure/5
        public void Put(long id, Restructure entity)
        {
            restructureRepository.Update(entity);
        }

        // DELETE api/restructure/5
        public void Delete(int id)
        {
        }

        /// <summary>
        /// [20150914] Add by Woody Method GetReleaseSql, Use for update db2
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string Sql</returns>
        public HttpResponseMessage  GetRelease(long id)
        {

            try
            {
                var lsql = this.restructureRepository.GetSQLRelease(id);
                var result = DB2Repository.UpdateRelease(lsql);
                return this.Request.CreateResponse(HttpStatusCode.OK, new { Message = "", Status = result });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return this.Request.CreateResponse(HttpStatusCode.OK, new { Message = ex.Message, Status = false });
            }
        }
    }
}
