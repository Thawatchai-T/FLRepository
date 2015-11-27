using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class ApplicationDetailMap : ClassMap<ApplicationDetail>
    {
        public ApplicationDetailMap()
        {
            Table("JOB_APPLICATION_DETAIL");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.IndicationEquipment).Column("INDICATION_ID");
            References(x => x.Job).Column("JOB_ID");
            Map(x => x.Year).Column("YEAR");
            Map(x => x.ApplicationId).Column("APPLICATION_ID").Length(100);
            Map(x => x.ApplicationType).Column("APPLICATION_TYPE");
            Map(x => x.ApplicationDate).Column("APPLICATION_DATE").CustomSqlType("date");
            Map(x => x.PrimaryJob).Column("PRIMARY_JOB");
            Map(x => x.Status).Column("STATUS");
            Map(x => x.AgreementNo).Column("AGREEMENT_NO").Length(100);
            Map(x => x.IntegralPartNo).Column("INTEGRAL_PART_NO");
            Map(x => x.ScheduleNo).Column("SCHEDULE_NO").Length(100);
            Map(x => x.CustomerCode).Column("CUSTOMER_CODE").Length(100);
            Map(x => x.CustomerName).Column("CUSTOMER_NAME").Length(100);
            Map(x => x.Telephone).Column("TELEPHONE");
            Map(x => x.Fax).Column("FAX");
            Map(x => x.MarketingOfficer).Column("MARKETING_OFFICER").Length(100);
            Map(x => x.IndustryCode).Column("INDUSTRY_CODE");
            Map(x => x.NatureCust).Column("NATURE_CUST");
            Map(x => x.GroupCust).Column("GROUP_CUST");
            Map(x => x.TypeLease).Column("TYPE_LEASE");
            Map(x => x.TypeEquipment).Column("TYPE_EQUIPMENT");
            Map(x => x.TypeBusiness).Column("TYPE_BUSINESS");
            Map(x => x.TypeCustomer).Column("TYPE_CUSTOMER");
            Map(x => x.Business).Column("BUSINESS").Length(150);
            Map(x => x.SourceInformation).Column("SOURCE_INFORMATION");
            Map(x => x.Remark).Column("REMARK").Length(255);
            Map(x => x.ApproveDate).Column("APPROVE_DATE").CustomSqlType("date");
            Map(x => x.DeliveryDate).Column("DELIVERY_DATE");
            Map(x => x.AgreementDate).Column("AGREEMENT_DATE").CustomSqlType("date");
            Map(x => x.ExecuteDate).Column("EXECUTE_DATE").CustomSqlType("date");
            Map(x => x.ScheduleDate).Column("SCHEDULE_DATE").CustomSqlType("date");
            Map(x => x.VAT).Column("VAT");
            Map(x => x.Currency).Column("CURRENCY");
            Map(x => x.ExchangeRate).Column("EXCHANGE_RATE");
            Map(x => x.CreateDate).Column("CREATE_DATE").CustomSqlType("date");
            Map(x => x.CreateBy).Column("CREATE_BY").Length(32);
            Map(x => x.UpdateDate).Column("UPDATE_DATE").CustomSqlType("date");
            Map(x => x.UpdateBy).Column("UPDATE_BY").Length(32);
        }
    }

}
