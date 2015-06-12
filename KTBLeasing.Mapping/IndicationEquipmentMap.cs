using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class IndicationEquipmentMap : ClassMap<IndicationEquipment>
    {
        public IndicationEquipmentMap()
        {
            Table("JOB_INDICATION_EQUIPMENT");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.Year, "YEAR");
            Map(x => x.IndicationId).Column("INDICATION_ID").Length(20);
            Map(x => x.IndicationDate).Column("INDICATION_DATE").CustomSqlType("date");
            Map(x => x.JobId).Column("JOB_ID").Length(20);
            Map(x => x.InformationId).Column("INFORMATION_ID").Length(20);
            Map(x => x.RequestType).Column("REQUEST_TYPE").Length(20);
            Map(x => x.ScheduleNo).Column("SCHEDULE_NO");
            Map(x => x.LeaseType).Column("LEASE_TYPE");
            Map(x => x.CustomerId).Column("CUSTOMER_ID");
            Map(x => x.ContactPerson).Column("CONTACT_PERSON").Length(128);
            Map(x => x.CustomerFax).Column("CUSTOMER_FAX").Length(10);
            Map(x => x.ThirdPartyId).Column("THIRD_PARTY_ID");
            Map(x => x.ThirdPartyContactPerson).Column("THIRD_PARTY_CONTACT_PERSON").Length(128);
            Map(x => x.ThirdPartyContactPersonFax).Column("THIRD_PARTY_CONTACT_PERSON_FAX").Length(10);
            Map(x => x.MarketingOfficer).Column("MARKETING_OFFICER");
            Map(x => x.Currency).Column("CURRENCY");
            Map(x => x.ExchangeRate).Column("EXCHANGE_RATE");
            Map(x => x.CreateDate).Column("CREATE_DATE").CustomSqlType("date");
            Map(x => x.CreateBy).Column("CREATE_BY").Length(32);
            Map(x => x.UpdateDate).Column("UPDATE_DATE").CustomSqlType("date");
            Map(x => x.UpdateBy).Column("UPDATE_BY").Length(32);
        }
    }
}
