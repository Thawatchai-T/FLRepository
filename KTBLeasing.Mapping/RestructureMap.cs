using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class RestructureMap : ClassMap<Restructure>
    {
        public RestructureMap()
        {
            Table("RES_RESTRUCTURE");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.Agreement).Column("AGRCODE").Length(20);
            Map(x => x.SEQ).Column("SEQ");
            Map(x => x.RestructureDate).Column("RESTRUCTURE_DATE").CustomSqlType("date");
            Map(x => x.Customer).Column("CUSTOMER").Length(100);
            Map(x => x.OS_PR).Column("OS_PR");
            Map(x => x.New_OS_PR).Column("NEW_OS_PR");
            Map(x => x.FlatRate).Column("FLAT_RATE");
            Map(x => x.Day).Column("DAY");
            Map(x => x.Interest).Column("INTEREST");
            Map(x => x.UnpaidVAT).Column("UNPAID_VAT");
            Map(x => x.Penalty).Column("PENALTY");
            Map(x => x.DebitNote).Column("DEBIT_NOTE");
            Map(x => x.NewFlatRate).Column("NEW_FLAT_RATE");
            Map(x => x.NewFirstDueDate).Column("NEW_FIRST_DUE_DATE").CustomSqlType("date");
            Map(x => x.SubsequentDueDay).Column("SUBSEQUENT_DUE_DAY");
            Map(x => x.NewTerm).Column("NEW_TERM");
            Map(x => x.EffectiveRate).Column("EFFECTIVE_RATE");
            Map(x => x.Status).Column("STATUS").Length(20);
            Map(x => x.ApproveDate).Column("APPROVE_DATE").CustomSqlType("date");
            Map(x => x.ApproveBy).Column("APPROVE_BY").Length(20);
            Map(x => x.CreateDate).Column("CREATE_DATE").CustomSqlType("date");
            Map(x => x.CreateBy).Column("CREATE_BY").Length(20);
            Map(x => x.UpdateDate).Column("UPDATE_DATE").CustomSqlType("date");
            Map(x => x.UpdateBy).Column("UPDATE_BY").Length(20);
        }
    }
}
