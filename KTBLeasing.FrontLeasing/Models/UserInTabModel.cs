using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Models
{
    public class UserInTabModel
    {
        public List<UserInTab> items { get; set; }
        public int totalProperty { get; set; }
    }
}