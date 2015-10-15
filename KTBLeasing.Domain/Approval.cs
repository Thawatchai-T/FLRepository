using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Approval : BaseDomain
    {
        public Approval()
        {
            InformationIndication = new InformationIndication();
        }

        public virtual long Id { get; set; }
        public virtual long InformationId { get; set; }
        public virtual string ApprovedBy { get; set; }
        public virtual bool Approve { get; set; }
        public virtual DateTime ApprovalDate { get; set; }
        public virtual bool Unquote { get; set; }
        public virtual DateTime UnquoteDate { get; set; }
        public virtual string Position { get; set; } 
        public virtual string Comment { get; set; }
        public virtual string MinIRR { get; set; }
        public virtual decimal PDC { get; set; }
        public virtual bool PG { get; set; }
        public virtual bool CG { get; set; }
        public virtual decimal RV { get; set; }
        public virtual decimal Deposit { get; set; }
        public virtual string ConditionLease { get; set; }
        public virtual string InsPaid { get; set; }
        public virtual string Other { get; set; }

        public virtual InformationIndication InformationIndication { get; set; }
    }
}
