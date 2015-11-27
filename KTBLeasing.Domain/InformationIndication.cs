using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain
{

    public class InformationIndication : BaseDomain
    {
        public InformationIndication()
        {
            VisitInformationDomain = new VisitInformationDomain();
            Job = new Job();
            //sRequestTransaction = new RequestTransaction();
        }

        public virtual long Id { get; set; }
        public virtual int Year { get; set; }
        public virtual string InformationId { get; set; }
        public virtual DateTime? RequestDate { get; set; }
        public virtual string PrimaryJob { get; set; }
        public virtual long IndustryCode { get; set; }
        public virtual long MarketingCode { get; set; }
        public virtual int Nationality { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int TypeCustomer { get; set; }
        public virtual int GroupCust { get; set; }
        public virtual int TitleNameTh { get; set; }
        public virtual string FirstNameTh { get; set; }
        public virtual string LastNameTh { get; set; }
        public virtual int TypeBusiness { get; set; }
        public virtual string Address { get; set; }
        public virtual int SubDistrict { get; set; }
        public virtual string Telephone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual int TypeFinance { get; set; }
        public virtual string SubLesseeSyndicated { get; set; }
        public virtual bool UsedEquipment { get; set; }
        public virtual bool SpecialProgram { get; set; }
        public virtual int EQPYear { get; set; }
        public virtual int ProgramName { get; set; }
        public virtual int Currency { get; set; }
        public virtual decimal ExchangeRate { get; set; }
        public virtual int SourceInformation { get; set; }
        public virtual string Remark { get; set; }
        public virtual bool Approve { get; set; }

        public virtual VisitInformationDomain VisitInformationDomain { get; set; }
        public virtual Job Job { get; set; }
        //public virtual RequestTransaction RequestTransaction { get; set; }

    }
}
