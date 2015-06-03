using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class CommissionMap : ClassMap<Commission>
    {
        public CommissionMap()
        {
            Table("JOB_AD_COMMISSION");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.PayCompanyName).Column("PAY_COMPANY_NAME").Length(100);
            Map(x => x.PayAmount).Column("PAY_AMOUNT");
            Map(x => x.PayDetail).Column("PAY_DETAIL").Length(100);
            Map(x => x.PayPaymentCondition).Column("PAY_PAYMENT_CONDITION");
            Map(x => x.ReceiveCompanyName).Column("RECEIVE_COMPANYNAME").Length(100);
            Map(x => x.ReceiveAmount).Column("RECEIVE_AMOUNT");
            Map(x => x.ReceiveDetail).Column("RECEIVE_DETAIL").Length(100);
            Map(x => x.ReceivePaymentCondition).Column("RECEIVE_PAYMENT_CONDITION");
        }
    }
}
