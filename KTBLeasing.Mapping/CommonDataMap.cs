using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class CommonDataMap : ClassMap<CommonData>
    {
        public CommonDataMap()
        {
			Table("COMMON_DATA");
			LazyLoad();
            //Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.Name).Column("NAME").Not.Nullable();
			Map(x => x.Parent_Id).Column("PARENT_ID").Not.Nullable();
			Map(x => x.Active).Column("ACTIVE").Not.Nullable();
			Map(x => x.Create_By).Column("CREATE_BY").Not.Nullable();
            Map(x => x.Create_Date).Column("CREATE_DATE").Not.Nullable();
            Map(x => x.Update_By).Column("UPDAET_BY").Not.Nullable();
			Map(x => x.Update_Date).Column("UPDATE_DATE").Not.Nullable();
            Map(x => x.Code).Column("CODE").Not.Nullable();
			Map(x => x.Remark).Column("REMARK").Not.Nullable();
            Map(x => x.Name_Eng).Column("NAME_ENG").Not.Nullable();
        }
    }
}
