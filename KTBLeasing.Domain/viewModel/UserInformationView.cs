using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;


namespace KTBLeasing.Domain
{
    public class UserInformationView : BaseDomain
    {
        public UserInformationView()
        {
            if (this.UsersAuthorize == null) this.UsersAuthorize = new UsersAuthorize();
        }
             
            public virtual long Id { get; set; }
            public virtual UsersAuthorize UsersAuthorize { get; set; }
            public virtual TitleTh TitleNameTh { get; set; }
            public virtual TitleEng TitleNameEng { get; set; }
            public virtual string FirstNameTh { get; set; }
            public virtual string LastNameTh { get; set; }
            public virtual string FirstNameEng { get; set; }
            public virtual string LastNameEng { get; set; }
            public virtual Position Position { get; set; }
            public virtual MarketingGroup MarketingGroup { get; set; }
            public virtual int MarketingCode { get; set; }
            //public virtual DateTime? CreateDate { get; set; }
            //public virtual string UpdateDate { get; set; }
            //public virtual string CreateBy { get; set; }
            //public virtual string UpdateBy { get; set; }
            public virtual DepartmentCode DepartmentCode { get; set; }
        
        
    }
}
