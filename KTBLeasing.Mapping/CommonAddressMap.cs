using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class CommonAddressMap : ClassMap<CommonAddress>
    {
        public CommonAddressMap()
        {
			Table("PROVINCE_TREE");
			LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
			Map(x => x.Parent_Id).Column("PARENT_ID").Not.Nullable();
			Map(x => x.Levels).Column("LEVELS").Not.Nullable();
			Map(x => x.Name).Column("NAME").Not.Nullable();
            Map(x => x.IsLeaf).Column("ISLEAF").Not.Nullable();
        }
    }
}
