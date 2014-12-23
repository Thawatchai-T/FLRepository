using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using KTBLeasing.Domain.ViewCommonData;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.CommonDataMapView
{
    public class MarketingGroupMap : ClassMap<MarketingGroup>
    {
        public MarketingGroupMap()
        {
            Table("V_MARKETING_GROUP");
            ReadOnly();
			//LazyLoad();
            //Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Id(x => x.Id).GeneratedBy.Assigned().Column("ID");
            Map(x => x.Name).Column("NAME").Not.Nullable();
			Map(x => x.Active).Column("ACTIVE").Not.Nullable();
            Map(x => x.Code).Column("CODE").Not.Nullable();
        }
    }
}
