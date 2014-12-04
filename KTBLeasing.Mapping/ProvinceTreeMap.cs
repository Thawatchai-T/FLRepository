using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public class ProvinceTreeMap : ClassMap<ProvinceTree> 
    {
        public ProvinceTreeMap() {
            Table("PROVINCE_TREE");
            CompositeId().KeyProperty(x => x.Id, "ID")
                         .KeyProperty(x => x.ParentId, "Parent_Id");
            Map(x => x.Levels).Column("LEVELS").Not.Nullable();
            Map(x => x.Name).Column("NAME").Not.Nullable();
            Map(x => x.IsLeaf).Column("ISLEAF").Not.Nullable();
        }
    }
}

