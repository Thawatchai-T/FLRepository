using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class InsurancePolicyMap : ClassMap<InsurancePolicy>
    {
        public InsurancePolicyMap()
        {
            Table("AD_INSURANCE_POLICY");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.PolicyNo).Column("POLICY_NO").Length(20);
            Map(x => x.ReceiveDate).Column("RECEIVE_DATE").CustomSqlType("date");
            Map(x => x.PayDate).Column("PAY_DATE").CustomSqlType("date");
            Map(x => x.Amount).Column("AMOUNT");
            Map(x => x.Rate).Column("RATE");
            Map(x => x.ContactNo).Column("CONTACT_NO").Length(20);
        }
    }
}
