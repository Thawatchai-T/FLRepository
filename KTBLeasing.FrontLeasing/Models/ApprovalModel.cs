using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class ApprovalModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public string ApprovedBy { get; set; }
        public string Position { get; set; }
        public bool Status { get; set; }
        public string Comment { get; set; }
        public string ApprovalDate { get; set; }
        public string MinIRR { get; set; }
        public decimal PDC { get; set; }
        public bool PG { get; set; }
        public bool CG { get; set; }
        public decimal RV { get; set; }
        public decimal Deposit { get; set; }
        public string ConditionLease { get; set; }
        public string InsPaid { get; set; }
        public string Other { get; set; }

        public List<ApprovalModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<ApprovalModel> list = new List<ApprovalModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new ApprovalModel
                {
                    Id= 960,
                    AppId = 1,
                    ApprovedBy= "nemo",
                    Position= "maxime",
                    Status= true,
                    Comment= "est",
                    ApprovalDate= "12/2/2007",
                    MinIRR= "autem",
                    PDC= Convert.ToDecimal(5.00),
                    PG= true,
                    CG= false,
                    RV = Convert.ToDecimal(5.00),
                    Deposit = Convert.ToDecimal(5.00),
                    ConditionLease= "non",
                    InsPaid= "distinctio",
                    Other= "ea"
                };
                list.Add(en);
            }
            return list;
        }
    }
}