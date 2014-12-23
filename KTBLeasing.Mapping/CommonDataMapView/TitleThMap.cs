using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.Domain;
using FluentNHibernate.Mapping;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.CommonDataMapView
{
    public class TitleThMap : ClassMap<TitleTh>
    {
        public TitleThMap()
        {
            Table("V_TITLE_TH");
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
