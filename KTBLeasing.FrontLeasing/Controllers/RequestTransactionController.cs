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
    public class RequestTransactionController : ApiController
    {
        private IInformationIndicationRepository InformationIndicationRepository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public List<RequestTransaction> Get()
        {
            return new List<RequestTransaction>();
        }

        public List<RequestTransaction> Get(int page, int start, int limit, long infoId)
        {
            return InformationIndicationRepository.GetRequestTransaction(infoId);
        }

        public string Get(int id)
        {
            return "value";
        }
        
        public void Post(RequestTransaction entity)
        {
            entity.InformationIndication.Id = entity.InformationId;
            InformationIndicationRepository.Insert(entity);
        }

        public void Put(long id, RequestTransaction entity)
        {
            InformationIndicationRepository.Update(entity);
        }

        public void Delete(long id)
        {
            //RequestTransactionRepository.Delete(id);
        }
    }
}
