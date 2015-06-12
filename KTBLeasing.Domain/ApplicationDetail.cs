using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class ApplicationDetail : BaseDomain
    {
        public ApplicationDetail()
        {
            IndicationEquipment = new IndicationEquipment();
            InformationIndication = new InformationIndication();
        }

        public ApplicationDetail(ApplicationDetail obj)
        {
            Id  = obj.Id;
            Code  = obj.Code;
            Name  = obj.Name;
            Year  = obj.Year;
            ApplicationId = obj.ApplicationId;
            ApplicationType  = obj.ApplicationType;
            ApplicationDate  = obj.ApplicationDate;
            PrimaryJob  = obj.PrimaryJob;
            //IndicationLine  = obj.IndicationLine;
            Status  = obj.Status;
            AgreementNo  = obj.AgreementNo;
            IntegralPartNo  = obj.IntegralPartNo;
            ScheduleNo  = obj.ScheduleNo;
            CustomerCode  = obj.CustomerCode;
            CustomerName  = obj.CustomerName;
            Telephone  = obj.Telephone;
            Fax  = obj.Fax;
            MarketingOfficer  = obj.MarketingOfficer;
            IndustryCode  = obj.IndustryCode;
            NatureCust  = obj.NatureCust;
            GroupCust  = obj.GroupCust;
            TypeLease  = obj.TypeLease;
            TypeEquipment  = obj.TypeEquipment;
            TypeBusiness  = obj.TypeBusiness;
            TypeCustomer  = obj.TypeCustomer;
            Business  = obj.Business;
            SourceInformation  = obj.SourceInformation;
            Remark  = obj.Remark;
            ApproveDate  = obj.ApproveDate;
            DeliveryDate  = obj.DeliveryDate;
            AgreementDate  = obj.AgreementDate;
            ExecuteDate  = obj.ExecuteDate;
            ScheduleDate  = obj.ScheduleDate;
            VAT  = obj.VAT;
            Currency  = obj.Currency;
            ExchangeRate  = obj.ExchangeRate;
            Rating  = obj.Rating;
            ExposureLimit  = obj.ExposureLimit;
            RatingDetail  = obj.RatingDetail;
            RatingDate  = obj.RatingDate;
        }

        public virtual long Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual int Year { get; set; }
        public virtual string ApplicationId { get; set; }
        public virtual int ApplicationType { get; set; }
        public virtual DateTime ApplicationDate { get; set; }
        public virtual int PrimaryJob { get; set; }
        //public virtual string IndicationLine { get; set; }
        public virtual int Status { get; set; }
        public virtual string AgreementNo { get; set; }
        public virtual int IntegralPartNo { get; set; }
        public virtual string ScheduleNo { get; set; }
        public virtual string CustomerCode { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string Telephone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string MarketingOfficer { get; set; }
        public virtual int IndustryCode { get; set; }
        public virtual int NatureCust { get; set; }
        public virtual int GroupCust { get; set; }
        public virtual int TypeLease { get; set; }
        public virtual int TypeEquipment { get; set; }
        public virtual int TypeBusiness { get; set; }
        public virtual int TypeCustomer { get; set; }
        public virtual string Business { get; set; }
        public virtual int SourceInformation { get; set; }
        public virtual string Remark { get; set; }
        public virtual DateTime ApproveDate { get; set; }
        public virtual string DeliveryDate { get; set; }
        public virtual DateTime AgreementDate { get; set; }
        public virtual DateTime ExecuteDate { get; set; }
        public virtual DateTime ScheduleDate { get; set; }
        public virtual decimal VAT { get; set; }
        public virtual int Currency { get; set; }
        public virtual decimal ExchangeRate { get; set; }
        public virtual decimal Rating { get; set; }
        public virtual decimal ExposureLimit { get; set; }
        public virtual string RatingDetail { get; set; }
        public virtual DateTime RatingDate { get; set; }

        public virtual IndicationEquipment IndicationEquipment { get; set; }
        public virtual InformationIndication InformationIndication { get; set; }
        
    }
}
