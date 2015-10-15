using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Redbook {
    
    
    public class RedbookVehicleMap : ClassMap<RedbookVehicle> {

        public RedbookVehicleMap()
        {
            Table("RBVehicle");
            LazyLoad();
            Id(x => x.VehicleKey, "VehicleKey").GeneratedBy.Assigned(); 
            Map(x => x.EffectiveDate).Column("EffectiveDate");
            //Map(x => x.VehicleKey).Column("VehicleKey");
            Map(x => x.Source_Type).Column("Source_Type");
            Map(x => x.Brand_Code).Column("Brand_Code");
            Map(x => x.Family_Code).Column("Family_Code");
            Map(x => x.MakeDescription).Column("MakeDescription");
            Map(x => x.MakeDescriptionThai).Column("MakeDescriptionThai");
            Map(x => x.FamilyDescription).Column("FamilyDescription");
            Map(x => x.FamilyDescriptionThai).Column("FamilyDescriptionThai");
            Map(x => x.VehicleTypeDescription).Column("VehicleTypeDescription");
            Map(x => x.VehicleTypeDescriptionThai).Column("VehicleTypeDescriptionThai");
            Map(x => x.YearGroup).Column("YearGroup");
            Map(x => x.MonthGroup).Column("MonthGroup");
            Map(x => x.SequenceNum).Column("SequenceNum");
            Map(x => x.Description).Column("Description");
            Map(x => x.DescriptionThai).Column("DescriptionThai");
            Map(x => x.CurrentRelease).Column("CurrentRelease");
            Map(x => x.ImportStatus).Column("ImportStatus");
            Map(x => x.ImportStatusTH).Column("ImportStatusTH");
            Map(x => x.LimitedEdition).Column("LimitedEdition");
            Map(x => x.Series).Column("Series");
            Map(x => x.SeriesThai).Column("SeriesThai");
            Map(x => x.BodyStyleDescription).Column("BodyStyleDescription");
            Map(x => x.BodyStyleDescriptionThai).Column("BodyStyleDescriptionThai");
            Map(x => x.BodyConfigDescription).Column("BodyConfigDescription");
            Map(x => x.BodyConfigDescriptionThai).Column("BodyConfigDescriptionThai");
            Map(x => x.BadgeDescription).Column("BadgeDescription");
            Map(x => x.BadgeDescriptionThai).Column("BadgeDescriptionThai");
            Map(x => x.BadgeSecondaryDescription).Column("BadgeSecondaryDescription");
            Map(x => x.BadgeSecondaryDescriptionThai).Column("BadgeSecondaryDescriptionThai");
            Map(x => x.ExtraIdentification).Column("ExtraIdentification");
            Map(x => x.ExtraIdentificationThai).Column("ExtraIdentificationThai");
            Map(x => x.GearTypeDescription).Column("GearTypeDescription");
            Map(x => x.GearTypeDescriptionThai).Column("GearTypeDescriptionThai");
            Map(x => x.GearNum).Column("GearNum");
            Map(x => x.GearLocationDescription).Column("GearLocationDescription");
            Map(x => x.GearLocationDescriptionThai).Column("GearLocationDescriptionThai");
            Map(x => x.DoorNum).Column("DoorNum");
            Map(x => x.SeatCapacity).Column("SeatCapacity");
            Map(x => x.EngineSize).Column("EngineSize");
            Map(x => x.EngineDescription).Column("EngineDescription");
            Map(x => x.Cylinders).Column("Cylinders");
            Map(x => x.DriveDescription).Column("DriveDescription");
            Map(x => x.DriveDescriptionThai).Column("DriveDescriptionThai");
            Map(x => x.InductionDescription).Column("InductionDescription");
            Map(x => x.InductionDescriptionThai).Column("InductionDescriptionThai");
            Map(x => x.FuelDeliveryDescription).Column("FuelDeliveryDescription");
            Map(x => x.FuelDeliveryDescriptionThai).Column("FuelDeliveryDescriptionThai");
            Map(x => x.MethodOfDeliveryDescription).Column("MethodOfDeliveryDescription");
            Map(x => x.MethodOfDeliveryDescriptionThai).Column("MethodOfDeliveryDescriptionThai");
            Map(x => x.FuelTypeDescription).Column("FuelTypeDescription");
            Map(x => x.FuelTypeDescriptionThai).Column("FuelTypeDescriptionThai");
            Map(x => x.CamDescription).Column("CamDescription");
            Map(x => x.CamDescriptionThai).Column("CamDescriptionThai");
            Map(x => x.Power).Column("Power");
            Map(x => x.PowerRPMFrom).Column("PowerRPMFrom");
            Map(x => x.PowerRPMTo).Column("PowerRPMTo");
            Map(x => x.Torque).Column("Torque");
            Map(x => x.TorqueRPMFrom).Column("TorqueRPMFrom");
            Map(x => x.TorqueRPMTo).Column("TorqueRPMTo");
            Map(x => x.WheelBase).Column("WheelBase");
            Map(x => x.GrossVehicleMass).Column("GrossVehicleMass");
            Map(x => x.PayLoad).Column("PayLoad");
            Map(x => x.GrossCombinationMass).Column("GrossCombinationMass");
            Map(x => x.KerbWeight).Column("KerbWeight");
            Map(x => x.TareMass).Column("TareMass");
            Map(x => x.AverageKM).Column("AverageKM");
            Map(x => x.GoodKM).Column("GoodKM");
            Map(x => x.AvgWholesale).Column("AvgWholesale");
            Map(x => x.AvgRetail).Column("AvgRetail");
            Map(x => x.GoodWholesale).Column("GoodWholesale");
            Map(x => x.GoodRetail).Column("GoodRetail");
            Map(x => x.NewPrice).Column("NewPrice");
            Map(x => x.Model_No).Column("Model_No");
            Map(x => x.Active).Column("Active");
            Map(x => x.Create_Date).Column("Create_Date");
            Map(x => x.Create_User).Column("Create_User");
            Map(x => x.Modify_Date).Column("Modify_Date");
            Map(x => x.Modify_User).Column("Modify_User");
            Map(x => x.EngineTypeDescription).Column("EngineTypeDescription");
            Map(x => x.EngineTypeDescriptionThai).Column("EngineTypeDescriptionThai");
            Map(x => x.FuelCapacity).Column("FuelCapacity");
            Map(x => x.Height).Column("Height");
            Map(x => x.Length).Column("Length");
            Map(x => x.Width).Column("Width");
        }
    }
}
