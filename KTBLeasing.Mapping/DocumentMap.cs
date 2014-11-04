using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class DocumentMap : ClassMap<Document> {
        
        public DocumentMap() {
			Table("DOCUMENT");
			LazyLoad();
			References(x => x.Customer).Column("CUSTOMER_ID");
			Map(x => x.DocType).Column("DOC_TYPE");
        }
    }
}
