using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.Domain;
using KTBLeasing.Domain.ViewCommonData; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class AssetTypeMap : ClassMap<AssetType>
    {
        public AssetTypeMap()
        {
			Table("AssetType");
			LazyLoad();
            Id(x => x.Id, "Id").GeneratedBy.Assigned();
            Map(x => x.Name).Column("Asset_Type").Not.Nullable();
			Map(x => x.Parent_Id).Column("REF_ASSET").Not.Nullable();
        }
    }
}
