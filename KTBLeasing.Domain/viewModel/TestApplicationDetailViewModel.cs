using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.Domain
{
    public class TestApplicationDetailViewModel : ApplicationDetail
    {
        private ApplicationDetail ApplicationDetail { get; set; }
        public TestApplicationDetailViewModel()
            : base()
        {
        }

        public TestApplicationDetailViewModel(ApplicationDetail obj)
            : base(obj)
        {
            this.ApplicationDetail = obj;
        }

        public WaiveDocument WaiveDocument { get; set; }
        public Guarantor Guarantor { get; set; }
        public OptionEndLeaseTerm OptionEndLeaseTerm { get; set; }
        public EquipmentList EquipmentList { get; set; }
        public MethodPayment MethodPayment { get; set; }
        public Maintenance Maintenance { get; set; }
        public Seller Seller { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public Insurance Insurance { get; set; }
        public Commission Commission { get; set; }
        public AnnualTax AnnualTax { get; set; }
        public StampDuty StampDuty { get; set; }
        public StipulateLoss StipulateLoss { get; set; }
        public CollectionSchedule CollectionSchedule { get; set; }
        public Funding Funding { get; set; }
        public TermCondition TermCondition { get; set; }
    }
}
