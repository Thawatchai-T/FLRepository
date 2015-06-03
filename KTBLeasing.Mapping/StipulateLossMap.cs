using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class StipulateLossMap : ClassMap<StipulateLoss>
    {
        public StipulateLossMap()
        {
            Table("JOB_AD_STIPULATE_LOSS");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.CLPerUnit).Column("CL_PER_UNIT");
            Map(x => x.CLTotal).Column("CL_TOTAL");
            Map(x => x.MDAmountFrom).Column("MD_AMOUNT_FROM");
            Map(x => x.MDAmountTo).Column("MD_AMOUNT_TO");
            Map(x => x.MDPerUnit).Column("MD_PER_UNIT");
            Map(x => x.MDTotal).Column("MD_TOTAL");
            Map(x => x.MDAmountFrom2).Column("MD_AMOUNT_FROM_2");
            Map(x => x.MDAmountTo2).Column("MD_AMOUNT_TO_2");
            Map(x => x.MDPerUnit2).Column("MD_PER_UNIT_2");
            Map(x => x.MDTotal2).Column("MD_TOTAL_2");
        }
    }
}
