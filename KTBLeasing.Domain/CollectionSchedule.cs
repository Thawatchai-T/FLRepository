using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class CollectionSchedule : BaseDomain
    {
        public CollectionSchedule()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual DateTime? CollectionDate { get; set; }
        public virtual string Collection { get; set; }
        public virtual decimal Principal { get; set; }
        public virtual decimal Receivable { get; set; } 

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
