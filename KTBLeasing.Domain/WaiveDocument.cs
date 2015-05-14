using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class WaiveDocument //: BaseDomain
    {
        public WaiveDocument()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual string Document { get; set; }
        public virtual string Reason { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
