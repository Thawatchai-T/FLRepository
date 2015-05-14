using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.Domain
{
    public class ApplicationDetailViewModel: ApplicationDetail
    {
        public List<ApplicationDetail> ApplicationDetail { get; set; }
        public ApplicationDetailViewModel()
            : base()
        {
            this.ApplicationDetail = new List<ApplicationDetail>();
            this.WaiveDocument = new List<WaiveDocument>();
            this.Guarantor = new List<Guarantor>();
            this.OptionEndLeaseTerm = new List<OptionEndLeaseTerm>();
            this.MethodPayment = new List<MethodPayment>();
            this.Maintenance = new List<Maintenance>();
            this.Insurance = new List<Insurance>();
            this.Commission = new List<Commission>();
            this.StampDuty = new List<StampDuty>();
            this.StipulateLoss = new List<StipulateLoss>();
            this.Funding = new List<Funding>();
            this.TermCondition = new List<TermCondition>();

            #region store
            //this.AnnualTax = new List<AnnualTax>();
            //this.CollectionSchedule = new List<CollectionSchedule>();
            //this.EquipmentList = new List<EquipmentList>();
            //this.Seller = new List<Seller>();
            //this.PurchaseOrder = new List<PurchaseOrder>();
            //this.InsuranceEquipment = new List<InsuranceEquipment>();
            //this.MaintenanceList = new List<MaintenanceList>();
            #endregion
        }

        public ApplicationDetailViewModel(ApplicationDetail obj)
            : base(obj)
        {
            List<ApplicationDetail> list = new List<ApplicationDetail>();
            list.Add(obj);
            this.ApplicationDetail = list;
        }

		public List<MethodPayment> MethodPayment { get; set; }
        public List<Maintenance> Maintenance { get; set; }
        public List<Insurance> Insurance { get; set; }
        public List<Commission> Commission { get; set; }
        public List<StampDuty> StampDuty { get; set; }
        public List<StipulateLoss> StipulateLoss { get; set; }
        public List<Funding> Funding { get; set; }
        public List<TermCondition> TermCondition { get; set; }

        #region store
        //public List<AnnualTax> AnnualTax { get; set; }
        //public List<CollectionSchedule> CollectionSchedule { get; set; }
        ////public List<Seller> Seller { get; set; }
        //public List<EquipmentList> EquipmentList { get; set; }
        //public List<PurchaseOrder> PurchaseOrder { get; set; }
        //public List<InsuranceEquipment> InsuranceEquipment { get; set; }
        //public List<MaintenanceList> MaintenanceList { get; set; }
        #endregion    }
}
