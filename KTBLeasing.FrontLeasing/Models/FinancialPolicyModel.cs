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
    }
}
