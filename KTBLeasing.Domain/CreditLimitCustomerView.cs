using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class CreditLimitCustomerView {

        public CreditLimitCustomerView()
        {
            //this.CreditLimitApproval = new CreditLimitApproval();
            //this.Customer = new Customer();
        }

        public virtual long Id { get; set; }
        public virtual long CreditLimitApprovalId { get; set; }
        //public virtual CreditLimitApproval CreditLimitApproval { get; set; }
        public virtual long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual decimal LimitAmount { get; set; }
        public virtual int VAT_Registration { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime UpdateDate { get; set; }
        #region NHibernate Composite Key Requirements
        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;
        //    var t = obj as CreditLimitCustomer;
        //    if (t == null) return false;
        //    if (CreditLimitApproval.Id == t.CreditLimitApproval.Id &&
        //      Customer.Id == t.Customer.Id)
        //        return true;

        //    return false;
        //}
        //public override int GetHashCode()
        //{
        //    int hash = GetType().GetHashCode();
        //    hash = (hash * 397) ^ CreditLimitApproval.Id.GetHashCode();
        //    hash = (hash * 397) ^ Customer.Id.GetHashCode();

        //    return hash;
        //}
        #endregion

        
    }
}
