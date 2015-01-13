using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.Domain
{
    public class AddressViewModel
    {
        public AddressViewModel()
        {
            //if (Company == null) this.Company = new Company();
        }
        public virtual long Id { get; set; }
        public virtual long CompanyId { get; set; }
        public virtual string AddressTh { get; set; }
        public virtual string AddressEng { get; set; }
        public virtual int ProvinceId { get; set; }
        public virtual int DistrictId { get; set; }
        public virtual int SubdistrictId { get; set; }
        public virtual string ProvinceName { get; set; }
        public virtual string DistrictName { get; set; }
        public virtual string SubdistrictName { get; set; }
        public virtual int Zipcode { get; set; }
        public virtual string Remark { get; set; }
        public virtual long AddressType { get; set; }


        public virtual string DisplayProvince { get; set; }
    }
}
