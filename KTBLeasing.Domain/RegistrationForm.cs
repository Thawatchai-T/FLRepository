using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class RegistrationForm : BaseDomain
    {
        public RegistrationForm()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual int Registration_Form { get; set; }
        public virtual DateTime Registration_Date { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
