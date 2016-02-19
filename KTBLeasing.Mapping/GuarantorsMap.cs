using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class GuarantorsMap : ClassMap<GuarantorModel>
    {
        public GuarantorsMap()
        {
            //Table("GUARANTOR");
            //LazyLoad();
            //Id(x => x.Id, "ID").GeneratedBy.Increment();
            //Map(x => x.AppNo).Column("APP_NO");
            //Map(x => x.KtbCollTypeDesc).Column("KTB_COLL_TYPE_DESC");
            //Map(x => x.KtbCollSubTypeDesc).Column("KTB_COLL_SUB_TYPE_DESC");
            //Map(x => x.BotCollTypeDesc).Column("BOT_COLL_TYPE_DESC");
            //Map(x => x.BotCollSubTypeDesc).Column("BOT_COLL_SUB_TYPE_DESC");
            //Map(x => x.CollateralNo).Column("COLLATERAL_NO");
            //Map(x => x.CollFlagCode).Column("COLL_FLAG_CODE");
            //Map(x => x.IsExisting).Column("IS_EXISTING");
            //Map(x => x.CifNo).Column("CIF_NO");
            //Map(x => x.TaxId).Column("TAX_ID");
            //Map(x => x.CitizenId).Column("CITIZEN_ID");
            //Map(x => x.IsFlLimit).Column("IS_FL_LIMIT");
            //Map(x => x.IsNonCrm).Column("IS_NON_CRM");
            //Map(x => x.IsReqApprove).Column("IS_REQ_APPROVE");
            //Map(x => x.GuarantorName).Column("GUARANTOR_NAME");
            //Map(x => x.GuarantorTitleName).Column("GUARANTOR_TITLE_NAME");
            
            //Map(x => x.Active).Column("ACTIVE");
            //Map(x => x.CreateBy).Column("CREATE_BY");
            //Map(x => x.UpdateBy).Column("UPDATE_BY");
            //Map(x => x.CreateDate).Column("CREATE_DATE");
            //Map(x => x.UpdateDate).Column("UPDATE_DATE");

            Table("GUARANTORS");
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
            Map(x => x.VAT_Registration).Column("VAT_REGISTRATION");
            Map(x => x.CreditLimit).Column("CREDIT_LIMIT");
            Map(x => x.CreditLimitId).Column("CL_ID");

            Map(x => x.Active).Column("ACTIVE");
            Map(x => x.CreateBy).Column("CREATE_BY");
            Map(x => x.UpdateBy).Column("UPDATE_BY");
            Map(x => x.CreateDate).Column("CREATE_DATE");
            Map(x => x.UpdateDate).Column("UPDATE_DATE");
        }
    }
}
