using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class WaiveDocumentMap : ClassMap<WaiveDocument>
    {
        public WaiveDocumentMap()
        {
            Table("JOB_AD_WAIVE_DOCUMENT");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("AppId");
            Map(x => x.Document).Column("DOCUMENT").Length(150);
            Map(x => x.Reason).Column("REASON").Length(255);
        }
    }
}
