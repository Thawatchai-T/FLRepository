using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Lead : BaseDomain
    {
        public Lead()
        {
        }

        public virtual long Id { get; set; }
        public virtual int Year { get; set; }
        public virtual int LeadId { get; set; }
        public virtual string Status { get; set; }
        public virtual string RequestDate { get; set; }
        public virtual int MarketingCode { get; set; }
        public virtual int Method { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int TypeCustomer { get; set; }
        public virtual int TitleNameTh { get; set; }
        public virtual string FirstNameTh { get; set; }
        public virtual string LastNameTh { get; set; }
        public virtual string Address { get; set; }
        public virtual string Telephone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual int SubDistrict { get; set; }
        public virtual int ContactPersonTitleNameTh { get; set; }
        public virtual string ContactPersonFirstNameTh { get; set; }
        public virtual string ContactPersonLastNameTh { get; set; }
        public virtual int Position { get; set; }
        public virtual string Business { get; set; }
        public virtual string Establishment { get; set; }
        public virtual int SourceInformation { get; set; }
        public virtual string Remark { get; set; }
        public virtual string FinancialPolicy { get; set; }
        public virtual int TypeEQP { get; set; }
        public virtual decimal EQPAmount { get; set; }
        public virtual string PlanSchedule { get; set; }
        public virtual int Result { get; set; }
        public virtual string OtherComment { get; set; }
    }
}
