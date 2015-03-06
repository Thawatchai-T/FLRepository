using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class AnnualTaxMap : ClassMap<AnnualTax>
    {
        public AnnualTaxMap()
        {
            Table("AD_ANNUAL_TAX");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.BorneBy).Column("BORN_BY");
            Map(x => x.Yearly).Column("YEARLY");
            Map(x => x.PerUnit).Column("PER_UNIT");
            Map(x => x.Quantity).Column("QUANTITY");
            Map(x => x.Total).Column("TOTAL");
        }
    }
}
