using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.Domain;
using FluentNHibernate.Mapping;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl
{
    public class RoleInTabsMap : ClassMap<RoleInTabsDomain>
    {
       public RoleInTabsMap() {
            Table("ROLE_IN_TABS");
            LazyLoad();
            CompositeId().KeyProperty(x => x.RoleId, "ROLE_ID")
                         .KeyProperty(x => x.TabId, "TAB_ID");
            References(x => x.Roles).Column("ROLE_ID");
            References(x => x.TabManament).Column("TAB_ID");
            Map(x => x.Remark).Column("REMARK").Length(150);
            Map(x => x.Active).Column("ACTIVE").Length(22);
       }
    }
}
