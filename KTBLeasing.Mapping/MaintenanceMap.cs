using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class MaintenanceMap : ClassMap<Maintenance>
    {
        public MaintenanceMap()
        {
            Table("AD_MAINTENANCE");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.PayTo).Column("PAY_TO").Length(100);
            Map(x => x.PaymentCondition).Column("PAYMENT_CONDITION");
            Map(x => x.Pattern).Column("PATTERN");
            Map(x => x.FirstDue).Column("FIRST_DUE");
            Map(x => x.SecondDue).Column("SECOND_DUE");
            Map(x => x.LastDue).Column("LAST_DUE");
        }
    }
}
