using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class IndicationEquipment : BaseDomain
    {
        public IndicationEquipment()
        {
            InformationIndication = new InformationIndication();
            Job = new Job();
        }

        public virtual long Id { get; set; }
        public virtual int Year { get; set; }
        public virtual string IndicationId { get; set; }
        public virtual DateTime? IndicationDate { get; set; }
        public virtual string InformationId { get; set; }
        public virtual string RequestType { get; set; }
        public virtual int ScheduleNo { get; set; }
        public virtual int LeaseType { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual string ContactPerson { get; set; }
        public virtual string CustomerFax { get; set; }
        public virtual int ThirdPartyId { get; set; }
        public virtual string ThirdPartyContactPerson { get; set; }
        public virtual string ThirdPartyContactPersonFax { get; set; }
        public virtual int MarketingOfficer { get; set; }
        public virtual decimal Currency { get; set; }
        public virtual decimal ExchangeRate { get; set; }

        public virtual Job Job { get; set; }
        public virtual InformationIndication InformationIndication { get; set; }
    }
}
