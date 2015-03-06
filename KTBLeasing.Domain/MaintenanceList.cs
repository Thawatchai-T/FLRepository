using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class MaintenanceList : BaseDomain
    {
        public MaintenanceList()
        {
            Maintenance = new Maintenance();
        }

        public virtual long Id { get; set; }
        public virtual long MaintenanceId { get; set; }
        public virtual int Yearly { get; set; }
        public virtual int Month { get; set; }
        public virtual decimal Amount { get; set; } 

        public virtual Maintenance Maintenance { get; set; }
    }
}
