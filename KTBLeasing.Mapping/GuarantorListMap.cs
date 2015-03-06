using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class GuarantorListMap : ClassMap<GuarantorList>
    {
        public GuarantorListMap()
        {
            Table("AD_GUARANTOR_LIST");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.Guarantor).Column("GUARANTOR_ID");
            Map(x => x.GuarantorType).Column("GUARANTOR_TYPE");
            Map(x => x.Name).Column("NAME").Length(100);
            Map(x => x.Address).Column("ADDRESS").Length(255);
            Map(x => x.Signer1).Column("SIGNER_1").Length(100);
            Map(x => x.Signer2).Column("SIGNER_2").Length(100);
            Map(x => x.Person1).Column("PERSON_1").Length(100);
            Map(x => x.Position).Column("POSITIONS").Length(100);
            Map(x => x.PersonAddress).Column("PERSON_ADDRESS").Length(255);
            Map(x => x.ConsentSpouse).Column("CONSENT_SPOUSE").Length(100);
            Map(x => x.SpouseAddress).Column("SPOUSE_ADDRESS").Length(255);
        }
    }
}
