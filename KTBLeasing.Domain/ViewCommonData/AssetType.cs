using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.Domain.ViewCommonData
{
    public class AssetType
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Parent_Id { get; set; }
    }
}
