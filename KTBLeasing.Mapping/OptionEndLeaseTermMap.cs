using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class OptionEndLeaseTermMap : ClassMap<OptionEndLeaseTerm>
    {
        public OptionEndLeaseTermMap()
        {
            Table("AD_OPTION_END_LEASE_TERM");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.PurchaseOption).Column("PURCHASE_OPTION");
            Map(x => x.ResidualValue).Column("RESIDUAL_VALUE");
            Map(x => x.ResidualValuePercent).Column("RESIDUAL_VALUE_PERCENT");
            Map(x => x.Others).Column("OTHERS").Length(150);
            Map(x => x.Renewal).Column("RENEWAL");
            Map(x => x.Term).Column("TERM");
            Map(x => x.Rental).Column("RENTAL");
            Map(x => x.RentalTotal).Column("RENTAL_TOTAL");
            Map(x => x.RentalTotalBHT).Column("RENTAL_TOTAL_BHT");
            Map(x => x.ResidualValueTotal).Column("RESIDUAL_VALUE_TOTAL");
            Map(x => x.ResidualValueTotalBHT).Column("RESIDUAL_VALUE_TOTAL_BHT");
            Map(x => x.ResidualValuePercentEQ).Column("RESIDUAL_VALUE_PERCENT_EQ");
            Map(x => x.Return).Column("RETURN");
            Map(x => x.GuaranteeBuyBackTotal).Column("GUARANTEE_BUY_BACK_TOTAL");
            Map(x => x.GuaranteeBuyBackTotalBHT).Column("GUARANTEE_BUY_BACK_TOTAL_BHT");
            Map(x => x.GuaranteeBuyBackPercentEQ).Column("GUARANTEE_BUY_BACK_PERCENT_EQ");
        }
    }
}
