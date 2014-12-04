using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.Domain
{
    public class ProvinceTree
    {
        public virtual decimal Id { get; set; }
        public virtual decimal ParentId { get; set; }
        public virtual decimal Levels { get; set; }
        public virtual string Name { get; set; }
        public virtual short IsLeaf { get; set; }
        
           
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as ProvinceTree;
            if (t == null) return false;
            if (Id == t.Id
                && ParentId == t.ParentId)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ Id.GetHashCode();
            hash = (hash * 397) ^ ParentId.GetHashCode();

            return hash;
        }
        #endregion
        
    }
}
