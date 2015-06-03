using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class MethodPaymentMap : ClassMap<MethodPayment>
    {
        public MethodPaymentMap()
        {
            Table("JOB_AD_METHOD_PAYMENT");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.MethodPayments).Column("METHOD_PAYMENT");
            Map(x => x.BankCharges).Column("BANK_CHARGES");
            Map(x => x.ChequeAmount).Column("CHEQUE_AMOUNT");
        }
    }
}
