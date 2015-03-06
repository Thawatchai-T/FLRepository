using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Models
{
    public class VisistCallModel
    {
        public int Id { get; set; }

        public string VisitNo { get; set; }

        public int CustomerId { get; set; }

        public string MarketingOfficer { get; set; }

        public string Status { get; set; }

        public int RefNo { get; set; }

        public string CreateBy { get; set; }

        public DateTime CrateDate { get; set; }

        public string UpdateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public string Md5 { get; set; }

        public string CustomerName { get; set; }

        public string Year { get; set; }

        public string LeadId { get; set; }

        public DateTime RequestDate { get; set; }

        public int MarketingCode { get; set; }

        public string Method { get; set; }

        public int TypeCustomer { get; set; }

        public string TitleNameTh { get; set; }

        public string FirstNameTh { get; set; }

        public string LastNameTh { get; set; }

        // public string Address { get; set; }

        public string Telephone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public int SubDistrict { get; set; }

        public string ContactPersonTitleNameTh { get; set; }

        public string ContactPersonFirstNameTh { get; set; }

        public string ContactPersonLastNameTh { get; set; }

        public int Position { get; set; }

        public string Business { get; set; }

        public string Establishment { get; set; }

        public string SourceInformation { get; set; }

        public string Remark { get; set; }

        public string FinancialPolicy { get; set; }

        public int TypeEQP { get; set; }

        public decimal EQPAmount { get; set; }

        public string PlanSchedule { get; set; }

        public string Result { get; set; }

        public string OtherComment { get; set; }

        //object 
        public AddressModel Address { get; set; }

        public ContactPersonModel ContactPerson { get; set; }

        public FinancialPolicyModel FinalcialProlicy { get; set; }

        public ProjectPlanModel ProjectPlan {get;set;}
        
        public List<VisistCallModel> GenDummyData()
        {
            List<VisistCallModel> list = new List<VisistCallModel>();
            var date = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                var en = new VisistCallModel
                {
                    Id = i,
                    CustomerId = i,
                    VisitNo = "VS" + date.Year + date.Month + date.Day + "00" + i,
                    MarketingOfficer = "marketing_" + i,
                    RefNo = 10000025 + i,
                    CustomerName = "CustomerName_" + i,
                    CreateDate = DateTime.Now,
                    //address tab
                    Address = new AddressModel
                    {
                        AddressTh = "address" + i + " ตำบล อำเภอ จังหวัด 5714" + i,
                        SubdistrictId = 10287
                    },
                    Business = "HP " + i,
                    ContactPersonTitleNameTh = "นาย",
                    ContactPersonFirstNameTh = "สมชาย",
                    ContactPersonLastNameTh = "รักหญิง",
                    FinalcialProlicy = FinalcialPolicyFunction("101111"),
                    ProjectPlan = new ProjectPlanModel
                    {
                        Amount = 251111111.75,
                        Schedule = DateTime.Now.ToShortDateString(),
                        TypeOfEquipment = "TypeOfEquipment"
                    }
                };

                list.Add(en);
            }
            return list;
        }

        public FinancialPolicyModel FinalcialPolicyFunction(string fl)
        {
            var finalcialpolicy = new FinancialPolicyModel();
            finalcialpolicy.Cash = (fl.Substring(0, 1).Equals("1")) ? true : false;
            finalcialpolicy.Loan = (fl.Substring(1, 1).Equals("1")) ? true : false;
            finalcialpolicy.Lease = (fl.Substring(2, 1).Equals("1")) ? true : false;
            finalcialpolicy.HirePurchase = (fl.Substring(3, 1).Equals("1")) ? true : false;
            finalcialpolicy.LoadAffiliated = (fl.Substring(4, 1).Equals("1")) ? true : false;
            finalcialpolicy.Other = (fl.Substring(5, 1).Equals("1")) ? true : false;

            finalcialpolicy.LeasingCompany = "KTB";
            finalcialpolicy.Detail = "Detail xy";
            finalcialpolicy.HPCompany = "HP Company";
            finalcialpolicy.HPTermCondition = "HP and codition x <> Y";
            finalcialpolicy.LeasingCompany = "KTBL";
            finalcialpolicy.TermCondition = "20 20 20 use eqp";
            finalcialpolicy.TypeOfHPEquipment = "mechanism";
            finalcialpolicy.TypeOfLeaseEquipment = "Type of Lease equipment";
            return finalcialpolicy;
        }

        public AddressModel AddressFunction(int id)
        {
            return new AddressModel();
        }

        //public VisitInformationDomain MapDomain(VisistCallModel entity)
        //{
        //    var domain = new VisitInformationDomain
        //    {
        //       Id = entity.Id ;

        //         CustomerId = entity. ;

        //        MarketingOfficer = entity. ;

        //        Status = entity. ;

        //         RefNo = entity. ;

        //        CreateBy = entity. ;

        //        UpdateBy = entity. ;

        //        ContractCreateDate = entity. ;

        //        UpdateDate = entity. ;

        //        VsCode = entity. ;

        //        FinalcialProlicy = entity. ;

        //        CustCode = entity. ;

        //         CustId = entity. ;

        //        TypeCustomer = entity. ;

        //         CustThType = entity. ;

        //        CustNameTh = entity. ;

        //        CustNameEng = entity. ;

        //        Position = entity. ;

        //        Business = entity. ;

        //        Establishment = entity. ;

        //        SourceOfInformation = entity. ;

        //        DetailWhenOthers = entity. ;

        //         ContactId = entity. ;

        //         TitleTh = entity. ;

        //        ContactFirstName = entity. ;

        //        ContactLastName = entity. ;

        //        PhoneNo = entity. ;

        //        FaxNo = entity. ;

        //        Email = entity. ;

        //        TypeLeaseEqp = entity. ;

        //        LeasingCompany = entity. ;

        //        TermCondition = entity. ;

        //        HpTypeEqp = entity. ;

        //        HpCompany = entity. ;

        //        HpTermCondition = entity. ;

        //        Detail = entity. ;

        //         ProjectPlanResult = entity. ;

        //        ProjectPlanComment = entity. ; 
        //    };

        //    return domain;
        //}

    }
}
