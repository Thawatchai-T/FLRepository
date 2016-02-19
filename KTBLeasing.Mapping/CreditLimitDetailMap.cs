using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class CreditLimitDetailMap : ClassMap<CreditLimitDetail>
    {
        public CreditLimitDetailMap()
        {
			Table("CREDIT_LIMIT_DETAIL");
			LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.CreditLimitApproval).Column("CREDIT_DETAIL_ID");
            Map(x => x.AssetType).Column("ASSET_TYPE");
            Map(x => x.MainAsset).Column("MAIN_ASSET");
            Map(x => x.SubAsset).Column("SUB_ASSET");
            Map(x => x.DetailAsset).Column("DETAIL_ASSET");
            Map(x => x.Marketable).Column("MARKETABLE");
            Map(x => x.LimitAmount).Column("LIMIT_AMOUNT");
            Map(x => x.Amount).Column("AMOUNT");
            Map(x => x.DownHireInsurance).Column("DOWN_HIRE_INSURANCE");
            Map(x => x.DownRate).Column("DOWN_RATE");
            Map(x => x.ScrapValue).Column("SCRAP_VALUE");
            Map(x => x.ScrapPercent).Column("SCRAP_PERCENT");
            Map(x => x.FlatRate).Column("FLAT_RATE");
            Map(x => x.EffectiveRate).Column("EFFECTIVE_RATE");
            Map(x => x.KTBMLR).Column("KTBMLR");
            Map(x => x.Term).Column("TERM");
            Map(x => x.TermStyle).Column("TERM_STYLE");
            Map(x => x.MethodPayment).Column("METHOD_PAYMENT");
            Map(x => x.ChequeCondition).Column("CHEQUE_CONDITION");
            Map(x => x.Guarantor).Column("GUARANTOR");
            Map(x => x.Insurance).Column("INSURANCE");
            Map(x => x.InsuranceBy).Column("INSURANCE_BY");
            Map(x => x.RegisterCapital).Column("REGISTER_CAPITAL");
            Map(x => x.RegisterCapitalBy).Column("REGISTER_CAPITAL_BY");
            Map(x => x.RegisterCapitalAgency).Column("REGISTER_CAPITAL_AGENCY");
            Map(x => x.OtherCondition).Column("OTHER_CONDITION");
            Map(x => x.TypeLeasing).Column("TYPE_LEASING");
            //Map(x => x.CreditLimitId).Column("CREDIT_DETAIL_ID");

            Map(x => x.Active).Column("ACTIVE");
            Map(x => x.CreateBy).Column("CREATE_BY");
            Map(x => x.UpdateBy).Column("UPDATE_BY");
            Map(x => x.CreateDate).Column("CREATE_DATE");
            Map(x => x.UpdateDate).Column("UPDATE_DATE");
        }
    }
}
