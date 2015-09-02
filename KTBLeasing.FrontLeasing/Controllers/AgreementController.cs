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
using KTBLeasing.FrontLeasing.Helpers;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class AgreementController : ApiController
    {
        public static List<AgrCodeDomain> ListAgrCode { get; set; }
        public Repository DB2Repository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public List<AgrCodeDomain> GetListAgrCode()
        {
            ListAgrCode = (ListAgrCode == null) ? new List<AgrCodeDomain>() : ListAgrCode;
            try
            {
                
                //ListAgrCode = this.DB2Repository.GetAgrCodeAll();
                //[20150827] add by Woody
                ListAgrCode = CommonHelps.ListAgrCodeDomain; 
                return ListAgrCode;

            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public List<AgrCodeDomain> GetFindAgrCode(string agrcode)
        {
            ListAgrCode = (ListAgrCode == null) ? this.GetListAgrCode() : ListAgrCode;
            try
            {
                List<AgrCodeDomain> result = ListAgrCode.Where(x => x.AgrCode == agrcode).Select(x => new AgrCodeDomain { AgrCode = x.AgrCode.Trim(), ComId = x.ComId, CusCode = x.CusCode.Trim() }).ToList();
                return result;

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw ex;
            }
        }

        // GET api/agreement
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/agreement/5
        public List<AgrCodeDomain> Get(string text)
        {
            List<AgrCodeDomain> result = new List<AgrCodeDomain>();

            try
            {
                ListAgrCode = (ListAgrCode == null) ? this.GetListAgrCode() : ListAgrCode;

                if (!string.IsNullOrEmpty(text))
                {
                    result = ListAgrCode.Where(x => x.AgrCode.Contains(text)).Select(x => new AgrCodeDomain { AgrCode = x.AgrCode.Trim(), ComId = x.ComId, CusCode = x.CusCode.Trim() }).ToList();
                }     
                return result;
            }
            catch (Exception e)
            {
                Logger.Error(e);
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
