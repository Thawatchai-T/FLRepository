using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class SellerMap : ClassMap<Seller>
    {
        public SellerMap()
        {
            Table("JOB_AD_SELLER");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.SellerId).Column("SELLER_ID").Length(20);
            Map(x => x.SellerName).Column("SELLER_NAME").Length(100);
            Map(x => x.Address).Column("ADDRESS").Length(255);
            Map(x => x.Signer1).Column("SIGNER_1").Length(100);
            Map(x => x.Signer2).Column("SIGNER_2").Length(100);
            Map(x => x.Title1).Column("TITLE_1").Length(20);
            Map(x => x.Title2).Column("BANK").Length(20);
            Map(x => x.PaymentMethod).Column("PAYMENT_METHOD");
            Map(x => x.PaymentCondition).Column("PAYMENT_CONDITION");
            Map(x => x.BankNo).Column("BANK_NO");
            Map(x => x.BankName).Column("BANK_NAME").Length(100);
            Map(x => x.Branch).Column("BRANCH").Length(100);
            Map(x => x.AccountType).Column("ACCOUNT_TYPE").Length(50);
            Map(x => x.AccountNo).Column("ACCOUNT_NO").Length(20);
            Map(x => x.BankChargeBy).Column("BANK_CHARGE_BY").Length(100);
            Map(x => x.Remark).Column("REMARK").Length(255);
        }
    }
}
