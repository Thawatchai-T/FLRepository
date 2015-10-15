using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class RequestTransactionMap : ClassMap<RequestTransaction>
    {
        public RequestTransactionMap()
        {
            Table("JOB_ID_REQUEST_TRANSACTION");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.InformationIndication).Column("INFORMATION_ID");
            Map(x => x.EquipmentTypeCode).Column("EQUIPMENT_TYPE_CODE");
            Map(x => x.EquipmentName).Column("EQUIPMENT_NAME").Length(256);
            Map(x => x.Amount).Column("AMOUNT");
            Map(x => x.Term).Column("TERM");
            Map(x => x.RVFrom).Column("RV_FROM");
            Map(x => x.RVTo).Column("RV_TO");
            Map(x => x.IRR).Column("IRR");
            Map(x => x.FinalIRR).Column("FINAL_IRR");
            Map(x => x.InsuranceCode).Column("INSURANCE_CODE");
            Map(x => x.ConditionLeaseCode).Column("CONDITION_LEASE_CODE");
            Map(x => x.Comment).Column("COMMENTS").Length(256);
            Map(x => x.Delivery).Column("DELIVERY").CustomSqlType("date");
            Map(x => x.Competitor).Column("COMPETITOR").Length(256);
        }
    }
}
