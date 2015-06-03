using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class InsuranceMap : ClassMap<Insurance>
    {
        public InsuranceMap()
        {
            Table("JOB_AD_INSURANCE");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.InsuranceCompany).Column("INSURANCE_COMPANY");
            Map(x => x.PaymentCondition).Column("PAYMENT_CONDITION");
            Map(x => x.Equipment1).Column("EQUIPMENT_1").Length(100);
            Map(x => x.BorneBy1).Column("BORNE_BY_1");
            Map(x => x.Equipment2).Column("EQUIPMENT_2").Length(100);
            Map(x => x.BorneBy2).Column("BORNE_BY_2");
            Map(x => x.ExceptEquipment).Column("EXCEPT_EQUIPMENT").Length(150);
            Map(x => x.Remark).Column("REMARK").Length(255);
        }
    }
}
