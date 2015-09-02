using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Ktbl.Database.DB2.Domain;
using Com.Ktbl.Database.DB2.Repository;

namespace KTBLeasing.FrontLeasing.Helpers
{
    public class CommonHelps
    {
        public static List<CustomerDomain> ListCustomerDomain { get; set; }
        public static List<AgrCodeDomain> ListAgrCodeDomain { get; set; }

        public CommonHelps(Repository repository)
        {
            ListAgrCodeDomain = repository.GetAgrCodeAll();
            ListCustomerDomain = repository.GetCustomerName();
        }
             
    }
}