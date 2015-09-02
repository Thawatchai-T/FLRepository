using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Installment : BaseDomain
    {
        public Installment()
        {
        }

        public virtual long Id { get; set; }
        public virtual string Agreement { get; set; }
        public virtual int SEQ { get; set; }
        public virtual int InstallNo { get; set; }
        public virtual DateTime? InstallmentDate { get; set; }
        public virtual decimal InstallmentBeforeVAT { get; set; }
        public virtual decimal VAT { get; set; }
        public virtual decimal Total { get; set; }
        public virtual decimal Principle { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal OS_PR { get; set; }
        public virtual decimal Penalty { get; set; }
        public virtual decimal Unknown2 { get; set; }
        public virtual decimal Unknown3 { get; set; }
        public virtual decimal Unknown4 { get; set; }
    }
}
