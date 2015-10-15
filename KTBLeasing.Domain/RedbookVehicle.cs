using System;
using System.Collections.Generic;
using System.Text;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Domain
{

    public class RedbookVehicle
    {
        public RedbookVehicle()
        {
        }

        public DateTime EffectiveDate
        {
            get { return _EffectiveDate; }
            set { _EffectiveDate = value; }
        }
        private DateTime _EffectiveDate;

        public string VehicleKey
        {
            get { return _VehicleKey; }
            set { _VehicleKey = value; }
        }
        private string _VehicleKey;

        public string Source_Type
        {
            get { return _Source_Type; }
            set { _Source_Type = value; }
        }
        private string _Source_Type;

        public string Brand_Code
        {
            get { return _Brand_Code; }
            set { _Brand_Code = value; }
        }
        private string _Brand_Code;

        public string Family_Code
        {
            get { return _Family_Code; }
            set { _Family_Code = value; }
        }
        private string _Family_Code;

        public string MakeDescription
        {
            get { return _MakeDescription; }
            set { _MakeDescription = value; }
        }
        private string _MakeDescription;

        public string MakeDescriptionThai
        {
            get { return _MakeDescriptionThai; }
            set { _MakeDescriptionThai = value; }
        }
        private string _MakeDescriptionThai;

        public string FamilyDescription
        {
            get { return _FamilyDescription; }
            set { _FamilyDescription = value; }
        }
        private string _FamilyDescription;

        public string FamilyDescriptionThai
        {
            get { return _FamilyDescriptionThai; }
            set { _FamilyDescriptionThai = value; }
        }
        private string _FamilyDescriptionThai;

        public string VehicleTypeDescription
        {
            get { return _VehicleTypeDescription; }
            set { _VehicleTypeDescription = value; }
        }
        private string _VehicleTypeDescription;

        public string VehicleTypeDescriptionThai
        {
            get { return _VehicleTypeDescriptionThai; }
            set { _VehicleTypeDescriptionThai = value; }
        }
        private string _VehicleTypeDescriptionThai;

        public short YearGroup
        {
            get { return _YearGroup; }
            set { _YearGroup = value; }
        }
        private short _YearGroup;

        public short MonthGroup
        {
            get { return _MonthGroup; }
            set { _MonthGroup = value; }
        }
        private short _MonthGroup;

        public short SequenceNum
        {
            get { return _SequenceNum; }
            set { _SequenceNum = value; }
        }
        private short _SequenceNum;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private string _Description;

        public string DescriptionThai
        {
            get { return _DescriptionThai; }
            set { _DescriptionThai = value; }
        }
        private string _DescriptionThai;

        public bool CurrentRelease
        {
            get { return _CurrentRelease; }
            set { _CurrentRelease = value; }
        }
        private bool _CurrentRelease;

        public string ImportStatus
        {
            get { return _ImportStatus; }
            set { _ImportStatus = value; }
        }
        private string _ImportStatus;

        public string ImportStatusTH
        {
            get { return _ImportStatusTH; }
            set { _ImportStatusTH = value; }
        }
        private string _ImportStatusTH;

        public bool LimitedEdition
        {
            get { return _LimitedEdition; }
            set { _LimitedEdition = value; }
        }
        private bool _LimitedEdition;

        public string Series
        {
            get { return _Series; }
            set { _Series = value; }
        }
        private string _Series;

        public string SeriesThai
        {
            get { return _SeriesThai; }
            set { _SeriesThai = value; }
        }
        private string _SeriesThai;

        public string BodyStyleDescription
        {
            get { return _BodyStyleDescription; }
            set { _BodyStyleDescription = value; }
        }
        private string _BodyStyleDescription;

        public string BodyStyleDescriptionThai
        {
            get { return _BodyStyleDescriptionThai; }
            set { _BodyStyleDescriptionThai = value; }
        }
        private string _BodyStyleDescriptionThai;

        public string BodyConfigDescription
        {
            get { return _BodyConfigDescription; }
            set { _BodyConfigDescription = value; }
        }
        private string _BodyConfigDescription;

        public string BodyConfigDescriptionThai
        {
            get { return _BodyConfigDescriptionThai; }
            set { _BodyConfigDescriptionThai = value; }
        }
        private string _BodyConfigDescriptionThai;

        public string BadgeDescription
        {
            get { return _BadgeDescription; }
            set { _BadgeDescription = value; }
        }
        private string _BadgeDescription;

        public string BadgeDescriptionThai
        {
            get { return _BadgeDescriptionThai; }
            set { _BadgeDescriptionThai = value; }
        }
        private string _BadgeDescriptionThai;

        public string BadgeSecondaryDescription
        {
            get { return _BadgeSecondaryDescription; }
            set { _BadgeSecondaryDescription = value; }
        }
        private string _BadgeSecondaryDescription;

        public string BadgeSecondaryDescriptionThai
        {
            get { return _BadgeSecondaryDescriptionThai; }
            set { _BadgeSecondaryDescriptionThai = value; }
        }
        private string _BadgeSecondaryDescriptionThai;

        public string ExtraIdentification
        {
            get { return _ExtraIdentification; }
            set { _ExtraIdentification = value; }
        }
        private string _ExtraIdentification;

        public string ExtraIdentificationThai
        {
            get { return _ExtraIdentificationThai; }
            set { _ExtraIdentificationThai = value; }
        }
        private string _ExtraIdentificationThai;

        public string GearTypeDescription
        {
            get { return _GearTypeDescription; }
            set { _GearTypeDescription = value; }
        }
        private string _GearTypeDescription;

        public string GearTypeDescriptionThai
        {
            get { return _GearTypeDescriptionThai; }
            set { _GearTypeDescriptionThai = value; }
        }
        private string _GearTypeDescriptionThai;

        public short GearNum
        {
            get { return _GearNum; }
            set { _GearNum = value; }
        }
        private short _GearNum;

        public string GearLocationDescription
        {
            get { return _GearLocationDescription; }
            set { _GearLocationDescription = value; }
        }
        private string _GearLocationDescription;

        public string GearLocationDescriptionThai
        {
            get { return _GearLocationDescriptionThai; }
            set { _GearLocationDescriptionThai = value; }
        }
        private string _GearLocationDescriptionThai;

        public short DoorNum
        {
            get { return _DoorNum; }
            set { _DoorNum = value; }
        }
        private short _DoorNum;

        public short SeatCapacity
        {
            get { return _SeatCapacity; }
            set { _SeatCapacity = value; }
        }
        private short _SeatCapacity;

        public int EngineSize
        {
            get { return _EngineSize; }
            set { _EngineSize = value; }
        }
        private int _EngineSize;

        public string EngineDescription
        {
            get { return _EngineDescription; }
            set { _EngineDescription = value; }
        }
        private string _EngineDescription;

        public short Cylinders
        {
            get { return _Cylinders; }
            set { _Cylinders = value; }
        }
        private short _Cylinders;

        public string DriveDescription
        {
            get { return _DriveDescription; }
            set { _DriveDescription = value; }
        }
        private string _DriveDescription;

        public string DriveDescriptionThai
        {
            get { return _DriveDescriptionThai; }
            set { _DriveDescriptionThai = value; }
        }
        private string _DriveDescriptionThai;

        public string InductionDescription
        {
            get { return _InductionDescription; }
            set { _InductionDescription = value; }
        }
        private string _InductionDescription;

        public string InductionDescriptionThai
        {
            get { return _InductionDescriptionThai; }
            set { _InductionDescriptionThai = value; }
        }
        private string _InductionDescriptionThai;

        public string FuelDeliveryDescription
        {
            get { return _FuelDeliveryDescription; }
            set { _FuelDeliveryDescription = value; }
        }
        private string _FuelDeliveryDescription;

        public string FuelDeliveryDescriptionThai
        {
            get { return _FuelDeliveryDescriptionThai; }
            set { _FuelDeliveryDescriptionThai = value; }
        }
        private string _FuelDeliveryDescriptionThai;

        public string MethodOfDeliveryDescription
        {
            get { return _MethodOfDeliveryDescription; }
            set { _MethodOfDeliveryDescription = value; }
        }
        private string _MethodOfDeliveryDescription;

        public string MethodOfDeliveryDescriptionThai
        {
            get { return _MethodOfDeliveryDescriptionThai; }
            set { _MethodOfDeliveryDescriptionThai = value; }
        }
        private string _MethodOfDeliveryDescriptionThai;

        public string FuelTypeDescription
        {
            get { return _FuelTypeDescription; }
            set { _FuelTypeDescription = value; }
        }
        private string _FuelTypeDescription;

        public string FuelTypeDescriptionThai
        {
            get { return _FuelTypeDescriptionThai; }
            set { _FuelTypeDescriptionThai = value; }
        }
        private string _FuelTypeDescriptionThai;

        public string CamDescription
        {
            get { return _CamDescription; }
            set { _CamDescription = value; }
        }
        private string _CamDescription;

        public string CamDescriptionThai
        {
            get { return _CamDescriptionThai; }
            set { _CamDescriptionThai = value; }
        }
        private string _CamDescriptionThai;

        public decimal Power
        {
            get { return _Power; }
            set { _Power = value; }
        }
        private decimal _Power;

        public int PowerRPMFrom
        {
            get { return _PowerRPMFrom; }
            set { _PowerRPMFrom = value; }
        }
        private int _PowerRPMFrom;

        public int PowerRPMTo
        {
            get { return _PowerRPMTo; }
            set { _PowerRPMTo = value; }
        }
        private int _PowerRPMTo;

        public int Torque
        {
            get { return _Torque; }
            set { _Torque = value; }
        }
        private int _Torque;

        public int TorqueRPMFrom
        {
            get { return _TorqueRPMFrom; }
            set { _TorqueRPMFrom = value; }
        }
        private int _TorqueRPMFrom;

        public int TorqueRPMTo
        {
            get { return _TorqueRPMTo; }
            set { _TorqueRPMTo = value; }
        }
        private int _TorqueRPMTo;

        public int WheelBase
        {
            get { return _WheelBase; }
            set { _WheelBase = value; }
        }
        private int _WheelBase;

        public int GrossVehicleMass
        {
            get { return _GrossVehicleMass; }
            set { _GrossVehicleMass = value; }
        }
        private int _GrossVehicleMass;

        public int PayLoad
        {
            get { return _PayLoad; }
            set { _PayLoad = value; }
        }
        private int _PayLoad;

        public int GrossCombinationMass
        {
            get { return _GrossCombinationMass; }
            set { _GrossCombinationMass = value; }
        }
        private int _GrossCombinationMass;

        public int KerbWeight
        {
            get { return _KerbWeight; }
            set { _KerbWeight = value; }
        }
        private int _KerbWeight;

        public int TareMass
        {
            get { return _TareMass; }
            set { _TareMass = value; }
        }
        private int _TareMass;

        public int AverageKM
        {
            get { return _AverageKM; }
            set { _AverageKM = value; }
        }
        private int _AverageKM;

        public int GoodKM
        {
            get { return _GoodKM; }
            set { _GoodKM = value; }
        }
        private int _GoodKM;

        public int AvgWholesale
        {
            get { return _AvgWholesale; }
            set { _AvgWholesale = value; }
        }
        private int _AvgWholesale;

        public int AvgRetail
        {
            get { return _AvgRetail; }
            set { _AvgRetail = value; }
        }
        private int _AvgRetail;

        public int GoodWholesale
        {
            get { return _GoodWholesale; }
            set { _GoodWholesale = value; }
        }
        private int _GoodWholesale;

        public int GoodRetail
        {
            get { return _GoodRetail; }
            set { _GoodRetail = value; }
        }
        private int _GoodRetail;

        public int NewPrice
        {
            get { return _NewPrice; }
            set { _NewPrice = value; }
        }
        private int _NewPrice;

        public string Model_No
        {
            get { return _Model_No; }
            set { _Model_No = value; }
        }
        private string _Model_No;

        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        private bool _Active;

        public DateTime Create_Date
        {
            get { return _Create_Date; }
            set { _Create_Date = value; }
        }
        private DateTime _Create_Date;

        public string Create_User
        {
            get { return _Create_User; }
            set { _Create_User = value; }
        }
        private string _Create_User;

        public DateTime Modify_Date
        {
            get { return _Modify_Date; }
            set { _Modify_Date = value; }
        }
        private DateTime _Modify_Date;

        public string Modify_User
        {
            get { return _Modify_User; }
            set { _Modify_User = value; }
        }
        private string _Modify_User;

        public string EngineTypeDescription
        {
            get { return _EngineTypeDescription; }
            set { _EngineTypeDescription = value; }
        }
        private string _EngineTypeDescription;

        public string EngineTypeDescriptionThai
        {
            get { return _EngineTypeDescriptionThai; }
            set { _EngineTypeDescriptionThai = value; }
        }
        private string _EngineTypeDescriptionThai;

        public int FuelCapacity
        {
            get { return _FuelCapacity; }
            set { _FuelCapacity = value; }
        }
        private int _FuelCapacity;

        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        private int _Height;

        public int Length
        {
            get { return _Length; }
            set { _Length = value; }
        }
        private int _Length;

        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        private int _Width;

    }
}