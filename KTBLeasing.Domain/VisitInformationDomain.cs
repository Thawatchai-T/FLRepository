using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.Domain
{
    public class VisitInformationDomain
    {
        public virtual long Id { get; set; }

        public virtual decimal? CustomerId { get; set; }

        public virtual string MarketingOfficer { get; set; }

        public virtual string Status { get; set; }

        public virtual decimal? RefNo { get; set; }

        public virtual string CreateBy { get; set; }

        public virtual string UpdateBy { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual string UpdateDate { get; set; }

        public virtual string VsCode { get; set; }

        public virtual string FinalcialProlicy { get; set; }

        public virtual string CustCode { get; set; }

        public virtual decimal? CustId { get; set; }

        public virtual string TypeCustomer { get; set; }

        public virtual decimal? CustThType { get; set; }

        public virtual string CustNameTh { get; set; }

        public virtual string CustNameEng { get; set; }

        public virtual string Position { get; set; }

        public virtual string Business { get; set; }

        public virtual DateTime? Establishment { get; set; }

        public virtual string SourceOfInformation { get; set; }

        public virtual string DetailWhenOthers { get; set; }

        public virtual decimal? ContactId { get; set; }

        public virtual decimal? TitleTh { get; set; }

        public virtual string ContactFirstName { get; set; }

        public virtual string ContactLastName { get; set; }

        public virtual string PhoneNo { get; set; }

        public virtual string FaxNo { get; set; }

        public virtual string Email { get; set; }

        public virtual string TypeLeaseEqp { get; set; }

        public virtual string LeasingCompany { get; set; }

        public virtual string TermCondition { get; set; }

        public virtual string HpTypeEqp { get; set; }

        public virtual string HpCompany { get; set; }

        public virtual string HpTermCondition { get; set; }

        public virtual string Detail { get; set; }

        public virtual decimal? ProjectPlanResult { get; set; }

        public virtual string ProjectPlanComment { get; set; }
    }
}
