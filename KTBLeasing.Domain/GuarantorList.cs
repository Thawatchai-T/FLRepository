using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class GuarantorList : BaseDomain
    {
        public GuarantorList()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual bool GuarantorType { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Signer1 { get; set; }
        public virtual string Signer2 { get; set; }
        public virtual string Person1 { get; set; }
        public virtual string Position { get; set; }
        public virtual string PersonAddress { get; set; }
        public virtual string ConsentSpouse { get; set; }
        public virtual string SpouseAddress { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
