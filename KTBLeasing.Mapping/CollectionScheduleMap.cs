using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class CollectionScheduleMap : ClassMap<CollectionSchedule>
    {
        public CollectionScheduleMap()
        {
            Table("AD_COLLECTION_SCHEDULE");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.CollectionDate).Column("COLLECTION_DATE").CustomSqlType("date");
            Map(x => x.Collection).Column("COLLECTION").Length(100);
            Map(x => x.Principal).Column("PRINCIPAL");
            Map(x => x.Receivable).Column("RECEIVABLE");
        }
    }
}
