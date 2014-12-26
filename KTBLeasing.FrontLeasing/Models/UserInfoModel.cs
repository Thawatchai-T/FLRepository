using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class UserInfoModel
    {
        public string DepartmentCode {get;set;}
        public string FirstNameEng {get;set;}
        public string FirstNameTh {get;set;}
        public string LastNameEng {get;set;}
        public string LastNameTh {get;set;}
        public int MarketingCode {get;set;}
        public int MarketingGroup {get;set;}
        public int Position {get;set;}
        public int TitleNameEng {get;set;}
        public int IdTitleName { get; set; }
        public string UserId {get;set;}
    }
}