using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class UserInTab {
        /**[20141127] Thawatchai.T edit domain class support composit key and change properties desc to Description **/ 
        //old
        //public virtual long RoleId { get; set; }
        //public virtual string Desc { get; set; }
        //public virtual string CreateBy { get; set; }
        //public virtual string UpdateBy { get; set; }
        //public virtual DateTime? CreateDate { get; set; }
        //public virtual string UpdateDate { get; set; }
        //public virtual long TabId { get; set; }

        //new 
        public virtual long RoleId { get; set; }
        public virtual long TabId { get; set; }
        public virtual string Description { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime UpdateDate { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as UserInTab;
            if (t == null) return false;
            if (RoleId == t.RoleId
             && TabId == t.TabId)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ RoleId.GetHashCode();
            hash = (hash * 397) ^ TabId.GetHashCode();

            return hash;
        }
        #endregion
    }
}
