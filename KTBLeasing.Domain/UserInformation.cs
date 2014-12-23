using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.Domain
{
    public class UserInformation :BaseDomain
    {
            public virtual long Id { get; set; }
            public virtual UsersAuthorize UsersAuthorize { get; set; }
            public virtual int TitleNameTh { get; set; }
            public virtual int TitleNameEng { get; set; }
            public virtual string FristNameTh { get; set; }
            public virtual string LastNameTh { get; set; }
            public virtual string FristNameEng { get; set; }
            public virtual string LastNameEng { get; set; }
            public virtual int Position { get; set; }
            public virtual int MarketingGroup { get; set; }
            public virtual int MarketingCode { get; set; }
            //public virtual DateTime? CreateDate { get; set; }
            //public virtual string UpdateDate { get; set; }
            //public virtual string CreateBy { get; set; }
            //public virtual string UpdateBy { get; set; }
            public virtual int? DeparmentCode { get; set; }
        
        
    }
}
