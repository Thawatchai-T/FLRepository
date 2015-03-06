using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Approval : BaseDomain
    {
        public Approval()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual string ApprovedBy { get; set; }
        public virtual string Position { get; set; }
        public virtual bool Status { get; set; }
        public virtual string Comment { get; set; }
        public virtual string ApprovalDate { get; set; }
        public virtual string MinIRR { get; set; }
        public virtual decimal PDC { get; set; }
        public virtual bool PG { get; set; }
        public virtual bool CG { get; set; }
        public virtual decimal RV { get; set; }
        public virtual decimal Deposit { get; set; }
        public virtual string ConditionLease { get; set; }
        public virtual string InsPaid { get; set; }
        public virtual string Other { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
