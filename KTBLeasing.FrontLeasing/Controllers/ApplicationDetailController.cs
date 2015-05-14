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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class ApplicationDetailController : ApiController
    {
        private IApplicationDetailRepository ApplicationDetailRepository { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        

        // GET api/contact
        public List<ApplicationDetailModel> Get()
        public List<ApplicationDetail> Get()
        {
            try
            {
                return new ApplicationDetailModel().Dummy();
                //return ApplicationDetailRepository.GetAll(0, 30, 1);
                //return new ApplicationDetailModel().Dummy();
                return ApplicationDetailRepository.GetAll();
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        // GET api/contact/5
        public string Get(int id)
        //// GET api/contact/5
        //public List<ApplicationDetail> Get(long id)
        //{
        //    List<ApplicationDetail> list = new List<ApplicationDetail>();
        //    var result = ApplicationDetailRepository.Get(id);
        //    list.Add(result);
        //    return list;
        //}

        public JArray Get(long id, ApplicationDetailChildEnum name)
        {
            return "value";
            try
            {
                string json = string.Empty;
                var result = ApplicationDetailModule(id, name, ref json);
                return result;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        public void DoPost(ApplicationDetail entity)
        private JArray ApplicationDetailModule(long id, ApplicationDetailChildEnum name, ref string json)
        {
            switch (name)
            {
                case ApplicationDetailChildEnum.ApplicationDetail:
                    List<ApplicationDetail> listApplicationDetail = new List<ApplicationDetail>();
                    var _obj = ApplicationDetailRepository.Get(id);
                    listApplicationDetail.Add(_obj);
                    json = JsonConvert.SerializeObject(listApplicationDetail);
                    break;
                case ApplicationDetailChildEnum.Commission:
                    var listCommission = ApplicationDetailRepository.GetAll<Commission>(0, 30, id, new Commission());
                    json = JsonConvert.SerializeObject(listCommission);
                    break;
                case ApplicationDetailChildEnum.Funding:
                    var listFunding = ApplicationDetailRepository.GetAll<Funding>(0, 30, id, new Funding());
                    json = JsonConvert.SerializeObject(listFunding);
                    break;
                case ApplicationDetailChildEnum.Guarantor:
                    var listGuarantor = ApplicationDetailRepository.GetAll<Guarantor>(0, 30, id, new Guarantor());
                    json = JsonConvert.SerializeObject(listGuarantor);
                    break;
                case ApplicationDetailChildEnum.Insurance:
                    var listInsurance = ApplicationDetailRepository.GetAll<Insurance>(0, 30, id, new Insurance());
                    json = JsonConvert.SerializeObject(listInsurance);
                    break;
                case ApplicationDetailChildEnum.Maintenance:
                    var listMaintenance = ApplicationDetailRepository.GetAll<Maintenance>(0, 30, id, new Maintenance());
                    json = JsonConvert.SerializeObject(listMaintenance);
                    break;
                case ApplicationDetailChildEnum.MethodPayment:
                    var listMethodPayment = ApplicationDetailRepository.GetAll<MethodPayment>(0, 30, id, new MethodPayment());
                    json = JsonConvert.SerializeObject(listMethodPayment);
                    break;
                case ApplicationDetailChildEnum.OptionEndLeaseTerm:
                    var listOptionEndLeaseTerm = ApplicationDetailRepository.GetAll<OptionEndLeaseTerm>(0, 30, id, new OptionEndLeaseTerm());
                    json = JsonConvert.SerializeObject(listOptionEndLeaseTerm);
                    break;
                case ApplicationDetailChildEnum.StampDuty:
                    var listStampDuty = ApplicationDetailRepository.GetAll<StampDuty>(0, 30, id, new StampDuty());
                    json = JsonConvert.SerializeObject(listStampDuty);
                    break;
                case ApplicationDetailChildEnum.StipulateLoss:
                    var listStipulateLoss = ApplicationDetailRepository.GetAll<StipulateLoss>(0, 30, id, new StipulateLoss());
                    json = JsonConvert.SerializeObject(listStipulateLoss);
                    break;
                case ApplicationDetailChildEnum.TermCondition:
                    var listTermCondition = ApplicationDetailRepository.GetAll<TermCondition>(0, 30, id, new TermCondition());
                    json = JsonConvert.SerializeObject(listTermCondition);
                    break;
                case ApplicationDetailChildEnum.WaiveDocument:
                    var listWaiveDocument = ApplicationDetailRepository.GetAll<WaiveDocument>(0, 30, id, new WaiveDocument());
                    json = JsonConvert.SerializeObject(listWaiveDocument);
                    break;
                case ApplicationDetailChildEnum.EquipmentList:
                    var listEquipmentList = ApplicationDetailRepository.GetAll<EquipmentList>(0, 30, id, new EquipmentList());
                    json = JsonConvert.SerializeObject(listEquipmentList);
                    break;
                case ApplicationDetailChildEnum.Seller:
                    var listSeller = ApplicationDetailRepository.GetAll<Seller>(0, 30, id, new Seller());
                    json = JsonConvert.SerializeObject(listSeller);
                    break;
                case ApplicationDetailChildEnum.AnnualTax:
                    var listAnnualTax = ApplicationDetailRepository.GetAll<AnnualTax>(0, 30, id, new AnnualTax());
                    json = JsonConvert.SerializeObject(listAnnualTax);
                    break;
                case ApplicationDetailChildEnum.InsuranceEquipment:
                    var listInsuranceEquipment = ApplicationDetailRepository.GetAll<InsuranceEquipment>(0, 30, id, new InsuranceEquipment());
                    json = JsonConvert.SerializeObject(listInsuranceEquipment);
                    break;
                case ApplicationDetailChildEnum.GuarantorList:
                    var listGuarantorList = ApplicationDetailRepository.GetAll<GuarantorList>(0, 30, id, new GuarantorList());
                    json = JsonConvert.SerializeObject(listGuarantorList);
                    break;
                case ApplicationDetailChildEnum.CollectionSchedule:
                    var listCollectionSchedule = ApplicationDetailRepository.GetAll<CollectionSchedule>(0, 30, id, new CollectionSchedule());
                    json = JsonConvert.SerializeObject(listCollectionSchedule);
                    break;
                case ApplicationDetailChildEnum.MaintenanceList:
                    var listMaintenanceList = ApplicationDetailRepository.GetAll<MaintenanceList>(0, 30, id, new MaintenanceList());
                    json = JsonConvert.SerializeObject(listMaintenanceList);
                    break;
                case ApplicationDetailChildEnum.EquipmentDetail:
                    var listEquipmentDetail = ApplicationDetailRepository.GetAll<EquipmentDetail>(0, 30, id, new EquipmentDetail(), "EquipmentList");
                    json = JsonConvert.SerializeObject(listEquipmentDetail);
                    break;
                case ApplicationDetailChildEnum.PurchaseOrder:
                    var listPurchaseOrder = ApplicationDetailRepository.GetAll<PurchaseOrder>(0, 30, id, new PurchaseOrder());
                    json = JsonConvert.SerializeObject(listPurchaseOrder);
                    break;
                case ApplicationDetailChildEnum.Unknow:
                    break;
            }

            var result = JArray.Parse(json);
            return result;
        }

        public void DoPost(object obj, ApplicationDetailChildEnum name)
        {
            try
            {
                ApplicationDetailRepository.SaveOrUpdate(entity);



                var typeEntity = Activator.CreateInstance("KTBLeasing.Domain", string.Format("KTBLeasing.FrontLeasing.Domain.{0}", name)).Unwrap().GetType();
                var entity = JsonConvert.DeserializeObject(obj.ToString(), typeEntity);

                //ApplicationDetailRepository.SaveOrUpdate<object>(entity);

            }
            catch(Exception e)
            {
                Logger.Error(e);
            }
        }

        // POST api/contact
        public void Post([FromBody]string value)
        public void Post(object obj, ApplicationDetailChildEnum name)
        {
            var typeEntity = Activator.CreateInstance("KTBLeasing.Domain", string.Format("KTBLeasing.FrontLeasing.Domain.{0}", name)).Unwrap().GetType();
            var entity = JsonConvert.DeserializeObject(obj.ToString(), typeEntity);

            ApplicationDetailRepository.Insert<object>(entity);
        }

        // PUT api/contact/5
        public void Put(int id, [FromBody]string value)
        public void Put(int id, object obj, ApplicationDetailChildEnum name)
        {
            var typeEntity = Activator.CreateInstance("KTBLeasing.Domain", string.Format("KTBLeasing.FrontLeasing.Domain.{0}", name)).Unwrap().GetType();
            var entity = JsonConvert.DeserializeObject(obj.ToString(), typeEntity);

            ApplicationDetailRepository.Update<object>(entity);
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
        }
    }
    }    

}
