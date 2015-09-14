using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class InstallmentMap : ClassMap<Installment>
    {
        public InstallmentMap()
        {
            Table("RES_INSTALLMENT");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.Res_Id).Column("RES_ID");
            Map(x => x.Agreement, "AGRCODE").Length(20);
            Map(x => x.SEQ).Column("SEQ");
            Map(x => x.InstallNo).Column("INSTALL_NO");
            Map(x => x.InstallmentDate).Column("INSTALLMENT_DATE").CustomSqlType("date");
            Map(x => x.InstallmentBeforeVAT).Column("INSTALLMENT_BEFORE_VAT");
            Map(x => x.VAT).Column("VAT");
            Map(x => x.Total).Column("TOTAL");
            Map(x => x.Principle).Column("PRINCIPLE");
            Map(x => x.Interest).Column("INTEREST");
            Map(x => x.OS_PR).Column("OS_PR");
            Map(x => x.Penalty).Column("PENALTY");
            Map(x => x.Installment_Total).Column("INSTALLMENT_TOTAL");
            Map(x => x.Waste_Value).Column("WASTE_VALUE");
            Map(x => x.PV).Column("PV");
            Map(x => x.CreateDate).Column("CREATE_DATE").CustomSqlType("date");
            Map(x => x.CreateBy).Column("CREATE_BY").Length(20);
            Map(x => x.UpdateDate).Column("UPDATE_DATE").CustomSqlType("date");
            Map(x => x.UpdateBy).Column("UPDATE_BY").Length(20);
        }
    }
}
