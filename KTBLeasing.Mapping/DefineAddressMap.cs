using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class DefineAddressMap : ClassMap<DefineAddress>
    {
        public DefineAddressMap()
        {
            Table("AD_DEFINE_ADDRESS");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.Agreement).Column("AGREEMENT").Length(100);
            Map(x => x.ScheduleAcceptanceReceipt).Column("SCHEDULEACCEPTANCERECEIPT").Length(100);
            Map(x => x.ContactSheetTaxInvoice).Column("CONTACTSHEETTAXINVOICE").Length(100);
            Map(x => x.TaxBranch).Column("TAXBRANCH").Length(20);
            Map(x => x.AddressPurchaseOrder).Column("ADDRESSPURCHASEORDER");
            Map(x => x.Remark).Column("REMARK").Length(255);
        }
    }
}
