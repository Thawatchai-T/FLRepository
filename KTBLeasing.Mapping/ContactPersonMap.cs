using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class ContactPersonMap : ClassMap<Contact> {
        public ContactPersonMap()
        {
            Table("CUST_CONTRACT");
            LazyLoad();
            //Id(x => x.Id).Column(x => x.ID).GeneratedBy.Sequence("DBOBJECTID_SEQUENCE")
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.CustomerId).Column("CUST_ID").Length(22);
            Map(x => x.TitleEng).Column("TITLE_ENG").Length(22);
            Map(x => x.TitleTh).Column("TITLE_TH").Length(22);
            Map(x => x.FirstNameEng).Column("FIRST_NAME_ENG").Length(300);
            Map(x => x.LastNameEng).Column("LAST_NAME_ENG").Length(100);
            Map(x => x.FirstNameTh).Column("FIRST_NAME_TH").Length(100);
            Map(x => x.LastNameTh).Column("LAST_NAME_TH").Length(100);
            Map(x => x.PositionEng).Column("POSITION_ENG").Length(100);
            Map(x => x.PositionTh).Column("POSITION_TH").Length(100);
            Map(x => x.Department).Column("DEPARTMENT").Length(100);
            Map(x => x.Telephone).Column("PHONE_NO").Length(10);
            //Map(x => x.AddressTh).Column("ADDRESS_TH").Length(10);
            Map(x => x.Fax).Column("FAX_NO").Length(10);
            Map(x => x.Remark).Column("REMARK").Length(255);
            Map(x => x.Email).Column("EMAIL").Length(100);
            Map(x => x.Active).Column("ACTIVE").Length(22);
        }
    
        
    }
}
