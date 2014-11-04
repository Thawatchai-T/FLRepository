using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class Document {
        public virtual Customer Customer { get; set; }
        public virtual long? DocType { get; set; }
    }
}
