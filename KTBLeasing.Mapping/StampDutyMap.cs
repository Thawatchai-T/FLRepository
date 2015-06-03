using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class StampDutyMap : ClassMap<StampDuty>
    {
        public StampDutyMap()
        {
            Table("JOB_AD_STAMP_DUTY");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.BorneBy).Column("BORN_BY");
            Map(x => x.Amount).Column("AMOUNT");
        }
    }
}
