using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.Domain;
using KTBLeasing.Domain.ViewCommonData; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class EqpMap : ClassMap<EQP>
    {
        public EqpMap()
        {
			Table("EQPREL");
			LazyLoad();
            Id(x => x.Id, "EQPCODE").GeneratedBy.Assigned();
            Map(x => x.IdSort).Column("EQPCODE").Not.Nullable();
            Map(x => x.Name).Column("DESC1").Not.Nullable();
			Map(x => x.Parent_Id).Column("ASSETCODE").Not.Nullable();
        }
    }
}
