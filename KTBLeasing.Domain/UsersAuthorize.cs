using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class UsersAuthorize:IVersionedModelObject {
        public UsersAuthorize()
        {
        }
        public virtual long Id { get; set; }
        public virtual string UserId { get; set; }
        public virtual short Active { get; set; }
        public virtual string DepCode { get; set; }
		public virtual byte[] Version { get; set; }    }
}
