using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Models
{
    public class RoleInTabsModel
    {
        public List<RoleInTabsDomain> items { get; set; }
        public int totalProperty { get; set; }
    }
}