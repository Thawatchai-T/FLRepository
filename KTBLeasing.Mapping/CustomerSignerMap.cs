using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl
{
    public class CustomerSignerMap : ClassMap<CustomerSignerDomain> 
    {
        public CustomerSignerMap() {
            Table("CUST_SIGNER");
            LazyLoad();
            //Id(x => x.Id).Column(x => x.ID).GeneratedBy.Sequence("DBOBJECTID_SEQUENCE")
            Id(x => x.Id, "ID").GeneratedBy.Increment(); 
            Map(x => x.TitleTh).Column("TITLE_TH");
            Map(x => x.TitleEng).Column("TITLE_ENG");
            Map(x => x.FirstNameTh).Column("FIRST_NAME_TH");
            Map(x => x.LastNameTh).Column("LAST_NAME_TH");
            Map(x => x.FirstNameEng).Column("FIRST_NAME_ENG");
            Map(x => x.LastNameEng).Column("LAST_NAME_ENG");
            Map(x => x.PassportType).Column("PASSPORT_TYPE");
            Map(x => x.IdCardNo).Column("ID_NO");
            Map(x => x.ExpireDate).Column("EXPIRE_DATE");
            Map(x => x.IssuedDate).Column("ISSUED_DATE");
            Map(x => x.Active).Column("ACTIVE");
            Map(x => x.CustomerId).Column("CUST_ID");
            Map(x => x.SpouseTitleEng).Column("SP_TITLE_ENG");
            Map(x => x.SpouseTitleTh).Column("SP_TITLE_TH");
            Map(x => x.SpouseFirstNameTh).Column("SP_FIRST_NAME_TH");
            Map(x => x.SpouseFirstNameEng).Column("SP_FIRST_NAME_ENG");
            Map(x => x.SpouseLastNameTh).Column("SP_LAST_NAME_TH");
            Map(x => x.SpouseLastNameEng).Column("SP_LAST_NAME_ENG");
            Map(x => x.SpouseAddressTh).Column("SP_ADDRESS_TH");
            Map(x => x.SpouseAddressEng).Column("SP_ADDRESS_ENG");
            Map(x => x.AddressTh).Column("ADDRESS_TH");
            Map(x => x.AddressEng).Column("ADDRESS_ENG");
            Map(x => x.SpouseSubDistrictId).Column("SP_SUBDISTRICT_ID");
            Map(x => x.SubDistrictId).Column("SUBDISTRICT_ID");
            Map(x => x.PositionTh).Column("POSITION_TH");
            Map(x => x.PositionEng).Column("POSITION_ENG");
            Map(x => x.Remark).Column("REMARK");
        }
    }
}
