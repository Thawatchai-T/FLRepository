using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class JobMap : ClassMap<Job>
    {
        public JobMap()
        {
            Table("JOB_MASTER");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.Customer).Column("CUSTOMER_ID");
            References(x => x.MarketingOfficer).Column("MARKETING_OFFICER_ID");
        }
    }
}
