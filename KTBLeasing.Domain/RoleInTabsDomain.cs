using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.Domain
{
    public class RoleInTabsDomain
    {
        public RoleInTabsDomain()
        {
            this.Roles = new Role();
            this.TabManament = new Tab();
        }

        public virtual long RoleId { get; set; }
        public virtual long TabId { get; set; }
        public virtual Role Roles { get; set; }
        public virtual Tab TabManament { get; set; }
        public virtual string Remark { get; set; }
        public virtual short? Active { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as RoleInTabsDomain;
            if (t == null) return false;
            if (Roles.Id == t.Roles.Id
             && TabManament.Id == t.TabManament.Id)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ Roles.Id.GetHashCode();
            hash = (hash * 397) ^ TabManament.Id.GetHashCode();

            return hash;
        }
        #endregion

    }
}
