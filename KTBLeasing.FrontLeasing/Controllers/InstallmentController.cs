using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualBasic;
using KTBLeasing.FrontLeasing.Models;
using Newtonsoft.Json.Linq;
using log4net;
using System.Reflection;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class InstallmentController : ApiController
    {
        private IInstallmentRepository installmentRepository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // GET api/installment
        public List<Installment> Get()
        {
            return new List<Installment>();
        }

        // GET api/installment/5
        public List<Installment> Get(string Agreement, int SEQ)
        {
            var result = installmentRepository.Get(Agreement, SEQ);

            return (result != null) ? result : new List<Installment>();
        }

        // POST api/installment
        public void Post(Installment entity)
        {
            try
            {
                installmentRepository.Insert(entity);
            }
            catch (Exception e)
            {

            }
        }

        // PUT api/installment/5
        public void Put(long id, Installment entity)
        {
            installmentRepository.Update(entity);
        }

        // DELETE api/installment/5
        public void Delete(int id)
        {
        }

        public double PostEffectiveRate(double[] values)
        {
            double guess = 0.05;

            return Microsoft.VisualBasic.Financial.IRR(ref values, guess) * 100 * 12;
        }
    }
}
