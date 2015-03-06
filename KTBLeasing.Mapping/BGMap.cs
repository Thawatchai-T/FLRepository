using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class BGMap : ClassMap<BG>
    {
        public BGMap()
        {
            Table("BG");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.BGNo).Column("BG_NO").Length(20);
            Map(x => x.ReceiveDate).Column("RECEIVE_DATE").CustomSqlType("date");
            Map(x => x.BGDate).Column("BG_DATE").CustomSqlType("date");
            Map(x => x.Bank).Column("BANK").Length(100);
            Map(x => x.Branch).Column("BRANCH").Length(100);
            Map(x => x.Amount).Column("BG_AMOUNT");
            Map(x => x.ContactNo).Column("CONTACT_NO").Length(20);
        }
    }
}
