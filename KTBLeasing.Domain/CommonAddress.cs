using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class CommonAddress {
		
		/** [20151211] Thawatchai.T 
		*   -Constructor to support Transformers.AliasToBeanConstructor.
		*   -Remark Req parameter same in sql query. 
		*/
        public CommonAddress(decimal ID, decimal PARENT_ID, decimal LEVELS, string NAME, decimal ISLEAF)
        {
            this.Id = Convert.ToInt32(ID);
            this.IsLeaf = Convert.ToBoolean(ISLEAF);
            this.Levels = Convert.ToInt32(LEVELS);
            this.Name = NAME;
            this.Parent_Id = Convert.ToInt32(PARENT_ID);
        }

        public CommonAddress()
        {
        }
        public virtual long Id { get; set; }
        public virtual int Parent_Id { get; set; }
        public virtual int Levels { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsLeaf { get; set; }
    }
}
