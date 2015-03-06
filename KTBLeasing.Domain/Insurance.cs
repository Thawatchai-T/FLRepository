using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Insurance : BaseDomain
    {
        public Insurance()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual int InsuranceCompany { get; set; }
        public virtual int PaymentCondition { get; set; }
        public virtual string Equipment1 { get; set; }
        public virtual int BorneBy1 { get; set; }
        public virtual string Equipment2 { get; set; }
        public virtual int BorneBy2 { get; set; }
        public virtual string ExceptEquipment { get; set; }
        public virtual string Remark { get; set; } 

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
