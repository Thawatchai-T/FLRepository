using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class PurchaseOrderMap : ClassMap<PurchaseOrder>
    {
        public PurchaseOrderMap()
        {
            Table("AD_PURCHASE_ORDER");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.PONo).Column("PO_NO").Length(20);
            Map(x => x.PODate).Column("PO_DATE").CustomSqlType("date");
            Map(x => x.SellerId).Column("SELLER_ID");
            Map(x => x.QuotationNo1).Column("QUOTATION_NO_1").Length(100);
            Map(x => x.QuotationDate1).Column("QUOTATION_DATE_1").CustomSqlType("date");
            Map(x => x.QuotationNo2).Column("QUOTATION_NO_2").Length(100);
            Map(x => x.QuotationDate2).Column("QUOTATION_DATE_2").CustomSqlType("date");
            Map(x => x.POType).Column("PO_TYPE");
            Map(x => x.SignerName).Column("SIGNER_NAME").Length(100);
            Map(x => x.RefPO).Column("REF_PO").Length(20);
        }
    }
}
