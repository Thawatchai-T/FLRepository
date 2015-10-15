using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class InformationIndicationMap : ClassMap<InformationIndication>
    {
        public InformationIndicationMap()
        {
            Table("JOB_INFORMATION_INDICATION");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            //References(x => x.Lead).Column("LEAD_ID");
            Map(x => x.Year, "YEAR");
            Map(x => x.InformationId).Column("INFORMATION_ID").Length(20);
            Map(x => x.RequestDate).Column("REQUEST_DATE").CustomSqlType("date");
            Map(x => x.PrimaryJob).Column("PRIMARY_JOB").Length(20);
            Map(x => x.IndustryCode).Column("INDUSTRY_CODE").Length(20);
            Map(x => x.MarketingCode).Column("MARKETING_CODE").Length(20);
            Map(x => x.Nationality).Column("NATIONALITY");
            Map(x => x.CustomerId).Column("CUSTOMER_ID");
            Map(x => x.TypeCustomer).Column("TYPE_CUSTOMER");
            Map(x => x.TitleNameTh).Column("TITLE_NAME_TH");
            Map(x => x.GroupCust).Column("GROUP_CUST");
            Map(x => x.FirstNameTh).Column("FIRST_NAME_TH").Length(64);
            Map(x => x.LastNameTh).Column("LAST_NAME_TH").Length(64);
            Map(x => x.TypeBusiness).Column("TYPE_BUSINESS");
            Map(x => x.Address).Column("ADDRESS").Length(512);
            Map(x => x.SubDistrict).Column("SUB_DISTRICT");
            Map(x => x.Telephone).Column("TELEPHONE").Length(10);
            Map(x => x.Fax).Column("FAX").Length(10);
            Map(x => x.Email).Column("EMAIL").Length(64);
            Map(x => x.TypeFinance).Column("TYPE_FINANCE");
            Map(x => x.SubLesseeSyndicated).Column("SUBLESSEE_SYNDICATED").Length(256);
            Map(x => x.UsedEquipment).Column("USED_EQUIPMENT");
            Map(x => x.SpecialProgram).Column("SPECIAL_PROGRAM");
            Map(x => x.EQPYear).Column("EQP_YEAR");
            Map(x => x.ProgramName).Column("PROGRAM_NAME");
            Map(x => x.Currency).Column("CURRENCY");
            Map(x => x.ExchangeRate).Column("EXCHANGE_RATE");
            Map(x => x.SourceInformation).Column("SOURCE_INFORMATION");
            Map(x => x.Remark).Column("REMARK").Length(256);
            Map(x => x.Approve).Column("APPROVE");
            Map(x => x.CreateDate).Column("CREATE_DATE").CustomSqlType("date");
            Map(x => x.CreateBy).Column("CREATE_BY").Length(32);
            Map(x => x.UpdateDate).Column("UPDATE_DATE").CustomSqlType("date");
            Map(x => x.UpdateBy).Column("UPDATE_BY").Length(32);

            //HasMany(x => x.Approval).KeyColumn("ID");
        }
    }
}
