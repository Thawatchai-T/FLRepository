using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class CustomerMap : ClassMap<Customer> {
        public CustomerMap()
        {
            Table("CUSTOMER");
            LazyLoad();
            //Id(x => x.Id).Column(x => x.ID).GeneratedBy.Sequence("DBOBJECTID_SEQUENCE")
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.PositionId).Column("POSITION_ID");
            Map(x => x.Positionguid).Column("POSITIONGUID");
            Map(x => x.TypeCustomer).Column("TYPE_CUSTOMER");
            Map(x => x.IndustryCode).Column("INDUSTRY_CODE");
            Map(x => x.NatureCust).Column("NATURE_CUST");
            Map(x => x.TypeCust).Column("TYPE_CUST");
            Map(x => x.TitleCustNameEng).Column("TITLE_CUST_NAME_ENG");
            Map(x => x.TitleCustNameTh).Column("TITLE_CUST_NAME_TH");
            Map(x => x.TsicCode).Column("TSIC_CODE");
            Map(x => x.CustType).Column("CUST_TYPE");
            Map(x => x.FirstNameTh).Column("FIRST_NAME_TH");
            Map(x => x.LastNameTh).Column("LAST_NAME_TH");
            Map(x => x.FirstNameEng).Column("FIRST_NAME_ENG");
            Map(x => x.LastNameEng).Column("LAST_NAME_ENG");
            Map(x => x.ParentId).Column("PARENT_ID").Not.Nullable();
            Map(x => x.VsAreaProvince).Column("VS_AREA_PROVINCE");
            Map(x => x.VsAreaIndEstate).Column("VS_AREA_IND_ESTATE");
            Map(x => x.TaxNo).Column("TAX_NO");
            Map(x => x.Vat).Column("VAT");
            Map(x => x.MarketingOfficer).Column("MARKETING_OFFICER");
            Map(x => x.Remark).Column("REMARK");
            Map(x => x.GroupCust).Column("GROUP_CUST_ID");
            Map(x => x.PhoneNo).Column("PHONE_NO");
            Map(x => x.FaxNo).Column("FAX_NO");
            Map(x => x.KTBCustType).Column("KTB_CUST_TYPE");
            Map(x => x.Email).Column("E_MAIL");
            Map(x => x.BirthDate).Column("BIRTH_DATE");
            Map(x => x.IdIssueDate).Column("ID_ISSUE_DATE");
            Map(x => x.IdExpireDate).Column("ID_EXPIRE_DATE");
            Map(x => x.OwnerBranch).Column("OWNER_BRANCH");
            Map(x => x.Contact).Column("CONTACT");

            Map(x => x.Active).Column("ACTIVE");
            Map(x => x.CreateBy).Column("CREATE_BY");
            Map(x => x.UpdateBy).Column("UPDATE_BY");
            Map(x => x.CreateDate).Column("CREATE_DATE");
            Map(x => x.UpdateDate).Column("UPDATE_DATE");
        }
    
        
    }
}
