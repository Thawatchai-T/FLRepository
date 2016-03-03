using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {

    public class CreditLimitCustomer
    {
        public CreditLimitCustomer()
        {
        }

        public virtual long Id { get; set; }
        public virtual long CreditLimitApprovalId { get; set; }
        public virtual long CustomerId { get; set; }
        public virtual decimal LimitAmount { get; set; }
        public virtual int VAT_Registration { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime UpdateDate { get; set; }

        
    }
}
