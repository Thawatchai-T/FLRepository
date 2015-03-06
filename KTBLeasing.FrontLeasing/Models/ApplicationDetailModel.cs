using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class ApplicationDetailModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string ApplicationId { get; set; }
        public int ApplicationType { get; set; }
        public string ApplicationDate { get; set; }
        public int PrimaryJob { get; set; }
        public int IndicationLine { get; set; }
        public int Status { get; set; }
        public string AgreementNo { get; set; }
        public int IntegralPartNo { get; set; }
        public string ScheduleNo { get; set; }
        public int CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string MarketingOfficer { get; set; }
        public int IndustryCode { get; set; }
        public int NatureCust { get; set; }
        public int GroupCust { get; set; }
        public int TypeLease { get; set; }
        public int TypeEquipment { get; set; }
        public int TypeBusiness { get; set; }
        public int TypeCustomer { get; set; }
        public string Business { get; set; }
        public int SourceInformation { get; set; }
        public string Remark { get; set; }
        public string ApproveDate { get; set; }
        public string DeliveryDate { get; set; }
        public string AgreementDate { get; set; }
        public string ExecuteDate { get; set; }
        public string ScheduleDate { get; set; }
        public double VAT { get; set; }
        public int Currency { get; set; }
        public double ExchangeRate { get; set; }
        public double Rating { get; set; }
        public double ExposureLimit { get; set; }
        public string RatingDetail { get; set; }
        public string RatingDate { get; set; }
        public GuarantorModel Guarantor { get; set; }
        public FundingModel Funding { get; set; }
        public StipulateLossModel StipulateLoss { get; set; }
        public OptionEndLeaseTermModel OptionEndLeaseTerm { get; set; }
        public CommissionModel Commission { get; set; }
        public MaintenanceModel Maintenance { get; set; }
        public InsuranceModel Insurance { get; set; }
        public CollectionScheduleModel CollectionSchedule { get; set; }
        public WaiveDocumentModel WaiveDocument { get; set; }
        public StampDutyModel StampDuty { get; set; }
        public MethodPaymentModel MethodPayment { get; set; }
        
        public List<ApplicationDetailModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<ApplicationDetailModel> list = new List<ApplicationDetailModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new ApplicationDetailModel
                {
                    Id = 1,
                    Code = "a" + i,
                    Name = "15-0001-01",
                    Year = DateTime.Now.Year,
                    ApplicationId = "15-0001-01",
                    ApplicationType = i,
                    ApplicationDate = DateTime.Now.ToString("MM/dd/yyyy",eng),
                    IndicationLine = i,
                    Status = i,
                    AgreementNo = "a"+i,
                    IntegralPartNo = i,
                    ScheduleNo = "15-0001-01",
                    CustomerCode = 5,
                    CustomerName = "a" + i,
                    Telephone = "a" + i,
                    Fax = "a" + i,
                    MarketingOfficer = "a" + i,
                    IndustryCode = i,
                    NatureCust = i,
                    GroupCust = i,
                    TypeLease = i,
                    TypeEquipment = i,
                    TypeBusiness = i,
                    TypeCustomer = i,
                    Business = "a" + i,
                    SourceInformation = i,
                    Remark = "a" + i,
                    ApproveDate = DateTime.Now.ToString("MM/dd/yyyy",eng),
                    DeliveryDate = DateTime.Now.ToString("MM/dd/yyyy",eng),
                    AgreementDate = DateTime.Now.ToString("MM/dd/yyyy",eng),
                    ExecuteDate = DateTime.Now.ToString("MM/dd/yyyy",eng),
                    ScheduleDate = DateTime.Now.ToString("MM/dd/yyyy",eng),
                    VAT = i,
                    Currency = i,
                    ExchangeRate = i,
                    Rating = i,
                    ExposureLimit = i,
                    RatingDetail = "a" + i,
                    RatingDate = DateTime.Now.ToString("MM/dd/yyyy",eng)
                };

                en.Guarantor = new GuarantorModel
                {
                    Id = 173,
                    AppId = 1,
                    ConditionLease = "minima",
                    BGNo = "aut",
                    BGReceivedDate = "2/13/2005",
                    ConfirmPrintedDate = "2/7/2006",
                    ReturnDate = "7/19/2011",
                    Bank = "sed",
                    Branch = "dolores",
                    BGAmount = 337.51,
                    BGDate = "2/19/2011",
                    PeriodFrom = "3/8/2010",
                    PeriodTo = "3/10/2003",
                    BuyerName = "dolor",
                    RSAAmount = 661.53,
                    EquipmentSalesPrintedDate = "7/4/2002",
                    Signer1EquipmentSales = 966.42,
                    Signer2EquipmentSales = 966.42,
                    WithnessEquipmentSales = 413.73,
                    AddressEquipmentSales = 107.93,
                    Collateral = 15,
                    CollateralDetail = "officiis",
                    AdditionalCondition = "inventore"
                };

                en.Funding = new FundingModel
                {
                    Id = 685,
                    AppId = 1,
                    Source = 864,
                    NetRate = Convert.ToDecimal(452.6),
                    FundingCost = Convert.ToDecimal(455.83),
                    Spread = Convert.ToDecimal(759.07),
                    ProfitFromSpread = Convert.ToDecimal(867.64),
                    CreditNetRate = Convert.ToDecimal(86.48),
                    CreditSpread = Convert.ToDecimal(910.28),
                    CreditProfit = Convert.ToDecimal(629.11)
                };

                en.StipulateLoss = new StipulateLossModel
                {
                    Id = 511,
                    AppId = 1,
                    CommencementLeasePerUnit = 167,
                    CommencementLeaseTotal = 736,
                    MonthlyDiminishingAmountFrom = 1,
                    MonthlyDiminishingAmountTo = 20,
                    MonthlyDiminishingPerUnit = Convert.ToDecimal(595.14),
                    MonthlyDiminishingTotal = Convert.ToDecimal(996.28),
                    MonthlyDiminishingAmountFrom2 = 21,
                    MonthlyDiminishingAmountTo2 = 50,
                    MonthlyDiminishingPerUnit2 = 737,
                    MonthlyDiminishingTotal2 = 513
                };

                en.OptionEndLeaseTerm = new OptionEndLeaseTermModel
                {
                    Id = 501,
                    AppId = 1,
                    PurchaseOption = true,
                    ResidualValue = 950,
                    ResidualValuePercent = 996,
                    Others = "et",
                    Renewal = true,
                    Term = 754,
                    Rental = true,
                    RentalTotal = 359,
                    RentalTotalBHT = 819,
                    ResidualValueTotal = 505,
                    ResidualValueTotalBHT = 182,
                    ResidualValuePercentEQ = 689,
                    Return = true,
                    GuaranteeBuyBackTotal = 777,
                    GuaranteeBuyBackTotalBHT = 727,
                    GuaranteeBuyBackPercentEQ = 574,
                    BuyerName = "atque"
                };

                en.Commission = new CommissionModel
                {
                    Id = 635,
                    AppId = 1,
                    PayCompanyName = "magnam",
                    PayAmount = 398.13,
                    PayDetail = "et",
                    PayPaymentCondition = 544.27,
                    ReceiveCompanyName = "iusto",
                    ReceiveAmount = 357.36,
                    ReceiveDetail = "consequatur",
                    ReceivePaymentCondition = 162
                };

                en.Maintenance = new MaintenanceModel
                {
                    Id = 759,
                    AppId = 1,
                    PayTo = "eligendi",
                    PaymentCondition = 488,
                    Pattern = 834,
                    FirstDue = 187.32,
                    SecondDue = 928.22,
                    LastDue = 128.7
                };

                en.Insurance = new InsuranceModel
                {
                    Id = 371,
                    AppId = 1,
                    InsuranceCompany = 278,
                    PaymentCondition = 12,
                    Equipment1 = "dolores",
                    BorneBy1 = 629,
                    Equipment2 = "dicta",
                    BorneBy2 = 487,
                    ExceptEquipment = "vero",
                    Remark = "veniam"
                };

                en.CollectionSchedule = new CollectionScheduleModel
                {
                    Id = 172,
                    AppId = 1,
                    CollectionDate = "3/7/2012",
                    Collection = "atque",
                    Principal = Convert.ToDecimal(383.38),
                    Receivable = Convert.ToDecimal(66.67)
                };

                en.WaiveDocument = new WaiveDocumentModel
                {
                    Id = 194,
                    AppId = 1,
                    Document = "quia",
                    Reason = "voluptatem"
                };

                en.StampDuty = new StampDutyModel
                {
                    Id = 566,
                    AppId = 1,
                    BorneBy = 409,
                    Amount = Convert.ToDecimal(475.54)
                };

                en.MethodPayment = new MethodPaymentModel
                {
                    Id = 53,
                    AppId = 1,
                    MethodPayment = 979,
                    BankCharges = 7,
                    ChequeAmount = Convert.ToDecimal(894.55)
                };

                list.Add(en);
            }
            return list;
        }

    }
}