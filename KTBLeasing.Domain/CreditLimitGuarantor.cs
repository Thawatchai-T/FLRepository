using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {

    public class CreditLimitGuarantor
    {
        public CreditLimitGuarantor()
        {
        }

        public virtual long Id { get; set; }
        public virtual long CreditLimitDetailId { get; set; }
        public virtual long CustomerId { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime UpdateDate { get; set; }

        
    }
}
