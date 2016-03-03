using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Domain.ViewModel; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class CreditLimitApprovalViewMap : ClassMap<CreditLimitMasterView>
    {
        public CreditLimitApprovalViewMap()
        {
			Table("V_CREDIT_LIMIT_MASTER");
			LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            //HasMany(x => x.CreditLimitCustomer).KeyColumn("CREDIT_LIMIT_ID").Cascade.All().OrderBy("CREDIT_LIMIT_ID");
            //HasOne(x => x.CreditLimitCustomer).PropertyRef(r => r.Customer).Cascade.All();
            Map(x => x.TypeCreditLimit).Column("TYPE_CREDIT_LIMIT");
            Map(x => x.MarketingGroup).Column("MARKETING_GROUP");
            Map(x => x.Branch).Column("BRANCH");
            Map(x => x.ApproveDate).Column("APPROVE_DATE");
            Map(x => x.CustType).Column("CUST_TYPE");
            Map(x => x.TypeLeasing).Column("TYPE_LEASING");
            Map(x => x.TypeProductHP).Column("TYPE_PRODUCT_HP");
            Map(x => x.TypeProductLease).Column("TYPE_PRODUCT_LEASE");
            Map(x => x.CreditLimit).Column("CREDIT_LIMIT");
            Map(x => x.Total).Column("TOTAL");
            Map(x => x.Balance).Column("BALANCE");
            Map(x => x.AssetAmount).Column("ASSET_AMOUNT");
            Map(x => x.Limit).Column("LIMIT");
            Map(x => x.StartLimitDate).Column("START_LIMIT_DATE");
            Map(x => x.EndLimitDate).Column("END_LIMIT_DATE");
            Map(x => x.LimitHPAmount).Column("LIMIT_HP_AMOUNT");
            Map(x => x.LimitLeaseAmount).Column("LIMIT_LEASE_AMOUNT");
            Map(x => x.CustomerId).Column("CUSTOMER_ID");
            Map(x => x.FullNameTh).Column("FULL_NAME_TH");
            Map(x => x.SEQ).Column("SEQ");

            Map(x => x.Active).Column("ACTIVE");
            Map(x => x.CreateBy).Column("CREATE_BY");
            Map(x => x.UpdateBy).Column("UPDATE_BY");
            Map(x => x.CreateDate).Column("CREATE_DATE");
            Map(x => x.UpdateDate).Column("UPDATE_DATE");
        }
    }
}
