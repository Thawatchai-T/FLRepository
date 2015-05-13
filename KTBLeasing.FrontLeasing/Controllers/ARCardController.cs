using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualBasic;
using KTBLeasing.FrontLeasing.PolymathCoreDllService;
using KTBLeasing.FrontLeasing.Models;
using Com.Ktbl.Database.DB2.Domain;
using Com.Ktbl.Database.DB2.Repository;
using log4net;
using System.Reflection;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class ARCardController : ApiController
    {           
        private IPolymathCoreDllService _objIPolymathCoreDll { get; set; }
        //public List<CustomerDomain> ListCustomer { get; set; }
        public  static List<CustomerDomain> ListCustomer { get; set; }
        public Repository DB2Repository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ARCardController()
        {
            //if (ListAgrCode == null)
            //{
            //    ListAgrCode = DB2Repository.GetAgrCodeAll();
            //}
            //else if (ListAgrCode.Count < 1)
            //{
            //    ListAgrCode = DB2Repository.GetAgrCodeAll();
            //}

            //if (ListCustomer == null)
            //{
            //    ListCustomer = DB2Repository.GetCustomerName();
            //}
            //else if (ListCustomer.Count < 1)
            //{
            //    ListCustomer = DB2Repository.GetCustomerName();
            //}
        }

        // GET api/installment
        public void Get()
        {
            
            //return new List<ARCardModel>();
        }

        // GET api/installment/5
        public ARCardModel Get(string agrcode)
        {
            return this.ARCard(agrcode);
        }

        // POST api/installment
        public void Post([FromBody]string value)
        {
        }

        // PUT api/installment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/installment/5
        public void Delete(int id)
        {
        }

        private ARCardModel ARCard(string agrcode)
        {
            try
            {
                BuildCardRequest request = new BuildCardRequest();
                //DI

                //var objIPolymathCoreDll = new PolymathCoreDllServiceClient();
                _objIPolymathCoreDll = new PolymathCoreDllServiceClient();

                request.AgrCode = agrcode;
                request.AppName = "app";
                request.AsOfDate = DateTime.Now;

                //var test = _objIPolymathCoreDll.GetName();

                var buildcardata = _objIPolymathCoreDll.GetBuildCard(request).BuildCard;

                return this.ARCard(buildcardata);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        private ARCardModel ARCard(ResultBuildCard BuildCard)
        {
            ARCardModel model = new ARCardModel();

            //สัญญา
            model.Agreement = BuildCard.agrcode;
            //ชื่อลูกค้า
            model.Customer = this.GetCustomerNameWithAgrCode(BuildCard.cuscode).NameTh;// BuildCard.cuscode;
            //จำนวนวัน
            model.Day = int.Parse(BuildCard.late_max);
            //Debit Note ค้างชำระ
            model.DebitNote = Convert.ToDecimal(BuildCard.dn_outs) + Convert.ToDecimal(BuildCard.dn_vat_outs);
            //อัตราดอกเบี้ย
            model.FlatRate = Convert.ToDecimal(BuildCard.eff1);
            //ดอกเบี้ย
            model.Interest = Convert.ToDecimal(BuildCard.int_quo);
            //เงินต้นคงเหลือ
            model.OS_PR = Convert.ToDecimal(BuildCard.os_ar);
            //ค้างชำระเบี้ยปรับ+ค่าใช้จ่าย
            model.Penalty = Convert.ToDecimal(BuildCard.penalty);
            //Unpaid VAT for Restructure
            model.UnpaidVAT = Convert.ToDecimal(BuildCard.unpaid_vat);
            //model.Customers = this.GetCustomerNameWithAgrCode(BuildCard.agrcode);
            return model;
        }

        private CustomerDomain GetCustomerNameWithAgrCode(string CusCode)
        {
            try
            {
                ListCustomer = (ListCustomer == null)? DB2Repository.GetCustomerName(): ListCustomer;

//                ListAgrCode = DB2Repository.GetCuscodeWithAgrCode(agrcode);

                //var agrentity = ListAgrCode.FirstOrDefault();
                
                var result = ListCustomer.Where(x => x.CusCode == CusCode).FirstOrDefault();
                //var result = DB2Repository.GetCustomerNameWithCusCode(CusCode).FirstOrDefault();
                return result;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                throw e;
            }
            
        }
    }
}
