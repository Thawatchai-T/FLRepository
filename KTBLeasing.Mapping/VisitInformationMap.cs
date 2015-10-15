using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Mapping;
using System.Text;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl
{
    public class VisitInformationMap : ClassMap<VisitInformationDomain>
    {
        public VisitInformationMap()
        {
            Table("VISIT_HEAD");
            LazyLoad();
            Id(x => x.Id,"ID").GeneratedBy.Sequence("SEQ_VISIT_CALL");
            //Id(x => x.Id, "ID").GeneratedBy.Identity();
            Map(x => x.CustomerId).Column("CUSTOMER_ID").Length(22);
            Map(x => x.MarketingOfficer).Column("MARKETING_OFFICER").Length(100);
            Map(x => x.Status).Column("STATUS").Length(20);
            Map(x => x.RefNo).Column("REF_NO").Length(22);
            Map(x => x.VsCode).Column("VS_CODE").Length(75);
            //Map(x => x.FinalcialProlicy).Column("FINALCIAL_PROLICY").Length(6);
            Map(x => x.CustCode).Column("CUST_CODE").Length(20);
            Map(x => x.CustId).Column("CUST_ID").Length(22);
            Map(x => x.TypeCustomer).Column("TYPE_CUSTOMER").Length(20);
            Map(x => x.CustThType).Column("CUST_TH_TYPE").Length(22);
            Map(x => x.CustNameTh).Column("CUST_NAME_TH").Length(20);
            Map(x => x.CustNameEng).Column("CUST_NAME_ENG").Length(20);
            Map(x => x.Position).Column("POSITION").Length(20);
            Map(x => x.Business).Column("BUSINESS").Length(20);
            Map(x => x.Establishment).Column("ESTABLISHMENT").Length(7);
            Map(x => x.SourceOfInformation).Column("SOURCE_OF_INFORMATION").Length(20);
            Map(x => x.DetailWhenOthers).Column("DETAIL_WHEN_OTHERS").Length(255);
            Map(x => x.ContactId).Column("CONTACT_ID").Length(22);
            Map(x => x.TitleTh).Column("TITLE_TH").Length(22);
            Map(x => x.ContactFirstName).Column("CONTACT_FIRST_NAME").Length(75);
            Map(x => x.ContactLastName).Column("CONTACT_LAST_NAME").Length(75);
            Map(x => x.PhoneNo).Column("PHONE_NO").Length(20);
            Map(x => x.FaxNo).Column("FAX_NO").Length(20);
            Map(x => x.Email).Column("EMAIL").Length(20);
            Map(x => x.TypeLeaseEqp).Column("TYPE_LEASE_EQP").Length(255);
            Map(x => x.LeasingCompany).Column("LEASING_COMPANY").Length(255);
            Map(x => x.TermCondition).Column("TERM_CONDITION").Length(255);
            Map(x => x.HpTypeEqp).Column("HP_TYPE_EQP").Length(255);
            Map(x => x.HpCompany).Column("HP_COMPANY").Length(255);
            Map(x => x.HpTermCondition).Column("HP_TERM_CONDITION").Length(255);
            Map(x => x.Detail).Column("DETAIL").Length(255);
            Map(x => x.ProjectPlanResult).Column("PROJECT_PLAN_RESULT").Length(22);
            Map(x => x.ProjectPlanComment).Column("PROJECT_PLAN_COMMENT").Length(200);
        }
    }
}
