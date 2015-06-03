using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class EquipmentDetailMap : ClassMap<EquipmentDetail>
    {
        public EquipmentDetailMap()
        {
            Table("JOB_AD_EQUIPMENT_DETAIL");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.EquipmentList).Column("EQUIPMENT_LIST_ID");
            Map(x => x.SubType).Column("SUB_TYPE");
            Map(x => x.Brand).Column("BRAND");
            Map(x => x.Model).Column("MODEL");
            Map(x => x.CC).Column("CC").Length(20);
            Map(x => x.SerialNo).Column("SERIAL_NO").Length(20);
            Map(x => x.FrameChassisSerialNo).Column("FRAME_CHASSIS_SERIAL_NO").Length(20);
            Map(x => x.FLNo).Column("FL_NO").Length(20);
            Map(x => x.DateInvoice).Column("DATE_INVOICE").CustomSqlType("date");
            Map(x => x.DueDate).Column("DUE_DATE").CustomSqlType("date");
            Map(x => x.ChassisNo).Column("CHASSIS_NO").Length(20);
            Map(x => x.EngineNo).Column("ENGINE_NO").Length(20);
            Map(x => x.Color).Column("COLOR").Length(20);
            Map(x => x.LicenseNo).Column("LICENSE_NO").Length(20);
            Map(x => x.PriceCar).Column("PRICE_CAR");
            Map(x => x.Book).Column("BOOK");
            Map(x => x.BookBy).Column("BOOK_BY").Length(100);
            Map(x => x.BookReceivedDate).Column("BOOK_RECEIVED_DATE").CustomSqlType("date");
            Map(x => x.BookReturnDate).Column("BOOK_RETURN_DATE").CustomSqlType("date");
            Map(x => x.PowNo).Column("POW_NO").Length(20);
            Map(x => x.SpareKey).Column("SPARE_KEY");
            Map(x => x.SpareBy).Column("SPARE_BY").Length(100);
            Map(x => x.SpareReceivedDate).Column("SPARE_RECEIVED_DATE").CustomSqlType("date");
            Map(x => x.SpareReturnDate).Column("SPARE_RETURN_DATE").CustomSqlType("date");
            Map(x => x.Remark).Column("REMARK").Length(255);
        }
    }
}
