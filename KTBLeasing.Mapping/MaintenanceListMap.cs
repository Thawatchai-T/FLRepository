using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class MaintenanceListMap : ClassMap<MaintenanceList>
    {
        public MaintenanceListMap()
        {
            Table("AD_MAINTENANCE_LIST");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.Maintenance).Column("MAINTENANCE_ID");
            Map(x => x.Yearly).Column("YEARLY");
            Map(x => x.Month).Column("MONTH");
            Map(x => x.Amount).Column("AMOUNT");
        }
    }
}
