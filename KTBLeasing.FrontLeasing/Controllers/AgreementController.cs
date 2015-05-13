using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Com.Ktbl.Database.DB2.Domain;
using Com.Ktbl.Database.DB2.Repository;
using log4net;
using System.Reflection;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class AgreementController : ApiController
    {
        public List<AgrCodeDomain> ListAgrCode { get; set; }
        public Repository DB2Repository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // GET api/agreement
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/agreement/5
        public List<AgrCodeDomain> Get(string text)
        {
            List<AgrCodeDomain> result = new List<AgrCodeDomain>();

            //result.Add(new AgrCodeDomain {
            //    AgrCode = "H01010003833",
            //    ComId = "1",
            //    CusCode =""
            //});

            //return result;
            try
            {
                if (!string.IsNullOrEmpty(text))
                    result = DB2Repository.GetAgrCodeAll(text);
                    
                return result;
                //DB2Repository.DbAuth.GetOleDBConnetion();
                //return new List<AgrCodeDomain>();
            }
            catch (Exception e)
            {

                Logger.Error(e);
                Logger.ErrorFormat("{0} {1} {2} {3} {4}", DB2Repository.DbAuth._DATABASE, DB2Repository.DbAuth._Password, DB2Repository.DbAuth._Provider, DB2Repository.DbAuth._SERVER, DB2Repository.DbAuth._UserID);
                throw e;
            }
        }

        // POST api/agreement
        public void Post([FromBody]string value)
        {
        }

        // PUT api/agreement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/agreement/5
        public void Delete(int id)
        {
        }
    }
}
