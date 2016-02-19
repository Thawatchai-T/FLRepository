using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class EquipmentListMap : ClassMap<EquipmentList>
    {
        public EquipmentListMap()
        {
            Table("JOB_AD_EQUIPMENT_LIST");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            References(x => x.PurchaseOrder).Column("PO_ID");
            Map(x => x.SellerId).Column("SELLER_ID");
            Map(x => x.SellerName).Column("SELLER_NAME").Length(100);
            Map(x => x.Quantity).Column("QUANTITY");
            Map(x => x.EquipmentId).Column("EQUIPMENT_ID");
            Map(x => x.EquipmentName).Column("EQUIPMENT_NAME").Length(100);
            Map(x => x.UnitPrice).Column("UNIT_PRICE");
            Map(x => x.Total).Column("TOTAL");
            Map(x => x.VAT).Column("VAT");
            Map(x => x.Net).Column("NET");
            Map(x => x.ChequeDate).Column("CHEQUE_DATE").CustomSqlType("date");
        }
    }
}
