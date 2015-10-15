using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class RequestTransaction : BaseDomain
    {
        public RequestTransaction()
        {
            InformationIndication = new InformationIndication();
        }
        public virtual long Id { get; set; }
        public virtual long InformationId { get; set; }
        public virtual int EquipmentTypeCode { get; set; }
        public virtual string EquipmentName { get; set; }
        public virtual int Amount { get; set; }
        public virtual int Term { get; set; }
        public virtual int RVFrom { get; set; }
        public virtual int RVTo { get; set; }
        public virtual decimal IRR { get; set; }
        public virtual decimal FinalIRR { get; set; }
        public virtual int InsuranceCode { get; set; }
        public virtual int ConditionLeaseCode { get; set; }
        public virtual string Comment { get; set; }
        public virtual DateTime Delivery { get; set; }
        public virtual string Competitor { get; set; }

        public virtual InformationIndication InformationIndication { get; set; }
    }
}
