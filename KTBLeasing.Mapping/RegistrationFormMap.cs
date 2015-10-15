using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class RegistrationFormMap : ClassMap<RegistrationForm>
    {
        public RegistrationFormMap()
        {
            Table("JOB_AD_REGISTRATION_FORM");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.Registration_Form).Column("REGISTRATION_FORM");
            Map(x => x.Registration_Date).Column("REGISTRATION_DATE").CustomSqlType("date");
        }
    }
}
