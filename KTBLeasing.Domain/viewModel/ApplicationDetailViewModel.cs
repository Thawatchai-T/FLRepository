using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.Domain
{
    public class ApplicationDetailViewModel: ApplicationDetail
    {
        private ApplicationDetail obj { get; set; }
        public ApplicationDetailViewModel()
            : base()
        {
        }

        public ApplicationDetailViewModel(ApplicationDetail obj)
            : base(obj)
        {
            this.obj = obj;
        }

        //public virtual WaiveDocument WaiveDocument { get; set; }
        //public virtual Guarantor Guarantor { get; set; }
        public virtual EquipmentList EquipmentList { get; set; }
    }
}
