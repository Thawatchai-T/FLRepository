using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.Domain
{
    public class BaseCommonData
    {
        public virtual long Id { get; set; }
        public virtual bool Active { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
    }
}
