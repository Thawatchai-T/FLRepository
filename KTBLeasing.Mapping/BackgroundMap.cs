using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class BackgroundMap : ClassMap<Background>
    {
        public BackgroundMap()
        {
            Table("CUST_BACKGROUND");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.Customer).Column("CUST_ID");
            Map(x => x.Business).Column("BUSINESS").Length(128);
            Map(x => x.Establishment).Column("ESTABLISHMENT").CustomSqlType("date");
            Map(x => x.Rating).Column("RATING");
            Map(x => x.RatingDate).Column("RATING_DATE").CustomSqlType("date");
            Map(x => x.RatingDetail).Column("RATING_DETAIL").Length(128);
            Map(x => x.RegisterCapital).Column("REGISTER_CAPITAL");
            Map(x => x.RegisterCapitalDetail).Column("REGISTER_CAPITAL_DETAIL").Length(128);
            Map(x => x.Sales).Column("SALES");
            Map(x => x.SalesDate).Column("SALES_DATE").CustomSqlType("date");
            Map(x => x.SalesDetail).Column("SALES_DETAIL").Length(128);
            Map(x => x.ProfitLoss).Column("PROFIT_LOSS");
            Map(x => x.ProfitLossDate).Column("PROFIT_LOSS_DATE").CustomSqlType("date");
            Map(x => x.ProfitLossDetail).Column("PROFIT_LOSS_DETAIL").Length(128);
            Map(x => x.ShareholderEquity).Column("SHAREHOLDER_EQUITY");
            Map(x => x.ShareholderEquityDate).Column("SHAREHOLDER_EQUITY_DATE").CustomSqlType("date");
            Map(x => x.ShareholderEquityDetail).Column("SHAREHOLDER_EQUITY_DETAIL").Length(128);
            Map(x => x.OutstandingAmount).Column("OUTSTANDING_AMOUNT");
            Map(x => x.OutstandingAmountDate).Column("OUTSTANDING_AMOUNT_DATE").CustomSqlType("date");
            Map(x => x.ExposureLimit).Column("EXPOSURE_LIMIT");
            Map(x => x.ExposureLimitDate).Column("EXPOSURE_LIMIT_DATE").CustomSqlType("date");
            Map(x => x.Committed).Column("COMMITTED");
            Map(x => x.CreateDate).Column("CREATE_DATE").CustomSqlType("date");
            Map(x => x.CreateBy).Column("CREATE_BY").Length(32);
            Map(x => x.UpdateDate).Column("UPDATE_DATE").CustomSqlType("date");
            Map(x => x.UpdateBy).Column("UPDATE_BY").Length(32);
        }
    }
}
