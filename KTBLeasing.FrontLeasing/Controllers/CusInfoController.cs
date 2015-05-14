using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KTBLeasing.FrontLeasing.Models;
using log4net;
using System.Reflection;
using System.Web;
using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain.ViewCommonData;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class CusInfoController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private ICustomerRepository CustomerRepository { get; set; }

        private ICommonDataRepository CommonDataRepository { get; set; }
        public enum Test
        {
            a,
            b
        }

        #region Default 

        // GET api/cusinfo
        public List<CusInfoModel> Get(int page,
             int start,
             int limit)
        {
            try
            {
                var result =  this.CustomerRepository.GetWihtPage(start,
                     limit);
                var viewmodel =  result.Select(x => new CusInfoModel
                {
                        CustomerId = x.Id ,
                        //PositionId= data.PositionId,
                        TypeCustomer = x.TypeCustomer ,
                        IndustryCode = x.IndustryCode,
                        NatureCust = x.NatureCust,
                        TypeCust = x.TypeCust,
                        CustomerThaiType = x.TitleCustNameTh,
                        CustomerEngType = x.TitleCustNameEng,
                        KTBIsicCode = x.TsicCode,
                        CustomerThaiName = x.NameTh,
                        CustomerEngName = x.NameEng,
                        ParentCompany = x.ParentId,
                        GroupCust = x.GroupCust,
                        TaxNo = x.TaxNo,
                        VAT = x.Vat,
                        MarketingOfficer = x.MarketingOfficer,
                        Telephone = x.PhoneNo,
                        Fax = x.FaxNo,
                        KTBCustType = x.KTBCustType,
                        Email = x.Email
                }).ToList<CusInfoModel>();
                //return new CusInfoModel().Dummy();
                return viewmodel;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        // GET api/cusinfo/5
        public string Get(Test id)
        {
            return id.ToString();
        }

        // POST api/cusinfo
        public void Post([FromBody] string value)
        {
        }

        // PUT api/cusinfo/5
        public void Put(int id,
        [FromBody] string value)
        {
        }

        // DELETE api/cusinfo/5
        public void Delete(int id)
        {
        }

        public bool DoPost(CusInfoModel data)
        {
            try
            {
                Customer entity = new Customer
                {
                     Id = data.CustomerId,
                     //PositionId= data.PositionId,
                     TypeCustomer = data.TypeCustomer,
                     IndustryCode = data.IndustryCode,
                     NatureCust = data.NatureCust,
                     TypeCust = data.TypeCust,
                     TitleCustNameTh = data.CustomerThaiType,
                     TitleCustNameEng = data.CustomerEngType,
                     TsicCode = data.KTBIsicCode,
                     //CustType= data.,
                     NameTh = data.CustomerThaiName,
                     NameEng = data.CustomerEngName,
                     ParentId = data.ParentCompany,
                     //VsAreaProvince= data.,
                     //VsAreaIndEstate= data.,
                     GroupCust = data.GroupCust,
                     TaxNo = data.TaxNo,
                     Vat = data.VAT,
                     MarketingOfficer = data.MarketingOfficer,
                     Remark = "test insert",
                     Active = 1,
                     PhoneNo = data.Telephone,
                     FaxNo = data.Fax,
                     Email = data.Email,
                     KTBCustType = data.KTBCustType

                };
                this.CustomerRepository.SaveOrUpdate(entity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //public List<CusInfoModel> Get()
        //{
        //    //return new CusInfoModel().Dummy();
        //}

        #endregion

        #region CommonData

        public List<CommonCustomerDomain> GetCommonCustomerPopup(int page, int start, int limit)
        {
            try
            {
                var result = CommonDataRepository.GetCustomerInfoPopup(start,
                     limit);
                var totalpage = CommonDataRepository.CountCommonCustomerPopup();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new List<CommonCustomerDomain>();
            }
        }

        #endregion

    }
}
