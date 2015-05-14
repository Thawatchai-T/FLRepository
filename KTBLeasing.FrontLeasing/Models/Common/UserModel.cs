using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KTBLeasing.Domain;
using KTBLeasing.FrontLeasing.Domain;
using System.Net.Http;

namespace KTBLeasing.FrontLeasing.Models
{
    public class UserModel
    {
        public UserModel()
        {
            this.TabMdelList = (this.TabMdelList == null) ? new List<Tab>() : this.TabMdelList;
            //this.ResponseMsg = (this.ResponseMsg == null) ? new HttpResponseMessage() : this.ResponseMsg ;
            this.UserInfo = (this.UserInfo == null) ? new UserInformationView() : this.UserInfo;
        }
        public string UserId { get; set; }

        public string ResponseMsg { get; set; }

        public UserInformationView UserInfo { get; set; }

        public DateTime LoginDate { get; set; }

        public long RoleId { get; set; }

        public string RoleName { get; set; }

        public List<Tab> TabMdelList { get; set; }

        public bool Status { get; set; }

    }
}
