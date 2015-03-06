using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Table("ROLES");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Assigned().Column("ID");
            Map(x => x.RoleName).Column("ROLE_NAME").Not.Nullable();
            Map(x => x.Createdate).Column("CREATE_DATE").Not.Nullable();
            Map(x => x.Createby).Column("CREATE_BY").Not.Nullable();
            Map(x => x.Updatedate).Column("UPDATE_DATE").Not.Nullable();
            Map(x => x.Updateby).Column("UPDATE_BY").Not.Nullable();
        }
    }
}
