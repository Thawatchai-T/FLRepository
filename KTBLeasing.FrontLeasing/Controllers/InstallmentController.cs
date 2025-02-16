﻿using System;
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
using System.Threading;

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
        //public List<Installment> Get(string Agreement, int SEQ, int marketing_group)
        //{
        //    var result = installmentRepository.Get(Agreement, SEQ, marketing_group);

        //    return (result != null) ? result : new List<Installment>();
        //}
        public List<Installment> Get(long Res_Id)
        {
            var result = installmentRepository.Get(Res_Id);

            return (result != null) ? result : new List<Installment>();
        }

        // POST api/installment
        public void Post(Installment entity)
        {
            try
            {
                installmentRepository.SaveOrUpdate(entity);
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

        public double GetPmtRate(double Rate, double NPer, double PV)
        {
            return Microsoft.VisualBasic.Financial.Pmt((Rate / 100) / 12, NPer, -PV);
        }
    }
}
