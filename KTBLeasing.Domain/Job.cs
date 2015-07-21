using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Job : BaseDomain
    {
        public Job()
        {
            Customer = new Customer();
            MarketingOfficer = new UserInformation();
            //Lead = new List<Lead>();
            //InformationIndication = new List<InformationIndication>();
            //IndicationEquipment = new List<IndicationEquipment>();
            //ApplicationDetail = new List<ApplicationDetail>();
        }

        public virtual long Id { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual UserInformation MarketingOfficer { get; set; }
        //public virtual MarketingOfficer MarketingOfficer { get; set; }
        //public virtual List<Lead> Lead { get; set; }
        //public virtual List<InformationIndication> InformationIndication { get; set; }
        //public virtual List<IndicationEquipment> IndicationEquipment { get; set; }
        //public virtual List<ApplicationDetail> ApplicationDetail { get; set; }

    }
}
