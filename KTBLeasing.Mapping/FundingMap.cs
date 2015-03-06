using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class FundingMap : ClassMap<Funding>
    {
        public FundingMap()
        {
            Table("AD_FUNDING");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.Source).Column("SOURCE");
            Map(x => x.NetRate).Column("NET_RATE");
            Map(x => x.FundingCost).Column("FUNDING_COST");
            Map(x => x.Spread).Column("SPREAD");
            Map(x => x.ProfitFromSpread).Column("PROFIT_FROM_SPREAD");
            Map(x => x.CreditNetRate).Column("CREDIT_NET_RATE");
            Map(x => x.CreditSpread).Column("CREDIT_SPREAD");
            Map(x => x.CreditProfit).Column("CREDIT_PROFIT");
        }
    }
}
