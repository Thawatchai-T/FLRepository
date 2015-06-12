using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class FinancialPolicyModel
    {
        public bool Cash { get; set; }

        public bool Loan { get; set; }

        public bool Lease { get; set; }

        public bool HirePurchase { get; set; }

        public bool LoadAffiliated { get; set; }

        public bool Other { get; set; }

        public string TypeOfLeaseEquipment { get; set; }

        public string LeasingCompany { get; set; }

        public string TermCondition { get; set; }

        public string TypeOfHPEquipment { get; set; }

        public string HPCompany { get; set; }

        public string HPTermCondition { get; set; }

        public string Detail { get; set; }
    }
}
