using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class ApprovalMap : ClassMap<Approval>
    {
        public ApprovalMap()
        {
            Table("JOB_AD_APPROVAL");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.ApprovedBy).Column("APPROVED_BY").Length(100);
            Map(x => x.Position).Column("POSITIONS").Length(100);
            Map(x => x.Status).Column("STATUS");
            Map(x => x.Comment).Column("REMARK").Length(255);
            Map(x => x.ApprovalDate).Column("APPROVAL_DATE").CustomSqlType("date");
            Map(x => x.MinIRR).Column("MIN_IRR").Length(20);
            Map(x => x.PDC).Column("PDC");
            Map(x => x.PG).Column("PG");
            Map(x => x.CG).Column("CG");
            Map(x => x.RV).Column("RV");
            Map(x => x.Deposit).Column("DEPOSIT");
            Map(x => x.ConditionLease).Column("CONDITION_LEASE").Length(150);
            Map(x => x.InsPaid).Column("INS_PAID").Length(150);
            Map(x => x.Other).Column("OTHER").Length(150);
        }
    }
}
