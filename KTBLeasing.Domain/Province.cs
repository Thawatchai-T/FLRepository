using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class Province {
        public virtual int ProvinceId { get; set; }
        public virtual int DistrictId { get; set; }
        public virtual int SubdistrictId { get; set; }
        public virtual string ProvinceName { get; set; }
        public virtual string DistrictName { get; set; }
        public virtual string SubdistrictName { get; set; }
        public virtual int Zipcode { get; set; }
    }
}
