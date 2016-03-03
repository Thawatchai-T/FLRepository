
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using KTBLeasing.Domain;
using KTBLeasing.Domain.ViewCommonData;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.CommonDataMapView
{
    /// <summary>
    /// -View V_CustomerPopup
    /// 
    /// </summary>
    public class CommonCustomerMap : ClassMap<CommonCustomerDomain>
    {
        public CommonCustomerMap()
        {
            Table("V_CUSTOMER_POPUP");
            ReadOnly();
			Id(x => x.CustomerCode).GeneratedBy.Assigned().Column("CUSTOMER_CODE");
            Map(x => x.TitleNameTh).Column("TITLE_NAME_TH").Not.Nullable();
            Map(x => x.FirstNameTh).Column("FIRST_NAME_TH").Not.Nullable();
            Map(x => x.LastNameTh).Column("LAST_NAME_TH").Not.Nullable();
            Map(x => x.FullNameTh).Column("FULL_NAME_TH").Not.Nullable();
            Map(x => x.FirstNameEng).Column("FIRST_NAME_ENG").Not.Nullable();
            Map(x => x.LastNameEng).Column("LAST_NAME_ENG").Not.Nullable();
            Map(x => x.FullNameEng).Column("FULL_NAME_ENG").Not.Nullable();
            Map(x => x.TaxNo).Column("TAX_NO").Not.Nullable();
            Map(x => x.MarketingOfficer).Column("MARKETING_OFFICER").Not.Nullable();
            Map(x => x.TypeCustomer).Column("TYPE_CUSTOMER").Not.Nullable();
            Map(x => x.AddressTh).Column("ADDRESS_TH").Not.Nullable();
            Map(x => x.ProvinceName).Column("PROVINCE_NAME").Not.Nullable();
            Map(x => x.DistrictName).Column("DISTRICT_NAME").Not.Nullable();
            Map(x => x.SubdistrictName).Column("SUBDISTRICT_NAME").Not.Nullable();
            Map(x => x.SubdistrictId).Column("SUBDISTRICT_ID").Not.Nullable();
            Map(x => x.Zipcode).Column("ZIPCODE").Not.Nullable();
            Map(x => x.ContactTitleTh).Column("CONTACT_TITLE_TH").Not.Nullable();
            Map(x => x.ContactPersonFirstName).Column("CONTACT_PERSON_FIRST_NAME").Not.Nullable();
            Map(x => x.ContactPersonLastName).Column("CONTACT_PERSON_LAST_NAME").Not.Nullable();
            Map(x => x.PhoneNo).Column("PHONE_NO").Not.Nullable();
            Map(x => x.FaxNo).Column("FAX_NO").Not.Nullable();
            Map(x => x.Email).Column("EMAIL").Not.Nullable();
            Map(x => x.PositionTh).Column("POSITION_TH").Not.Nullable();
            
        }
    }
}
