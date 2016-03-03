using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class CreditLimitGuarantorViewMap : ClassMap<CreditLimitGuarantorView>
    {

        public CreditLimitGuarantorViewMap()
        {
            Table("CREDIT_LIMIT_GUARANTOR");
			LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            //CompositeId().KeyProperty(x => x.CreditLimitApprovalId, "CREDIT_LIMIT_ID")
            //             .KeyProperty(x => x.CustomerId, "CUSTOMER_ID");
            //References(x => x.CreditLimitApproval).Column("CREDIT_LIMIT_ID");
            References(x => x.Customer).Column("CUSTOMER_ID");
            Map(x => x.CreditLimitDetilId).Column("CREDIT_LIMIT_DETAIL_ID");
            Map(x => x.CustomerId).Column("CUSTOMER_ID");

			Map(x => x.CreateBy).Column("CREATE_BY");
			Map(x => x.UpdateBy).Column("UPDATE_BY");
			Map(x => x.CreateDate).Column("CREATE_DATE");
            Map(x => x.UpdateDate).Column("UPDATE_DATE");
        }
    }
}
