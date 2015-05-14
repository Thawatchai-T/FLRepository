using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Restructure : BaseDomain
    {
        public Restructure()
        {
        }

        public virtual long Id { get; set; }
        public virtual string Agreement { get; set; }
        public virtual int SEQ { get; set; }
        public virtual DateTime? RestructureDate { get; set; }
        public virtual string Customer { get; set; }
        public virtual decimal OS_PR { get; set; }
        public virtual decimal FlatRate { get; set; }
        public virtual int Day { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal UnpaidVAT { get; set; }
        public virtual decimal Penalty { get; set; }
        public virtual decimal DebitNote { get; set; }
        public virtual decimal NewFlatRate { get; set; }
        public virtual DateTime? NewFirstDueDate { get; set; }
        public virtual int SubsequentDueDay { get; set; }
        public virtual decimal NewTerm { get; set; }
        public virtual decimal EffectiveRate { get; set; }
    }
}
