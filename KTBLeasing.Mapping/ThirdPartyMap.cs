using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class ThirdPartyMap : ClassMap<ThirdParty>
    {
        public ThirdPartyMap()
        {
            Table("THIRD_PARTY");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.ThirdPartyCode).Column("THIRD_PARTY_CODE").Length(20);
            Map(x => x.PersonType).Column("PERSON_TYPE");
            Map(x => x.TitleNameEn).Column("TITLE_NAME_EN");
            Map(x => x.NameEn).Column("NAME_EN").Length(128);
            Map(x => x.TitleNameTh).Column("TITLE_NAME_TH");
            Map(x => x.NameTh).Column("NAME_TH").Length(128);
            Map(x => x.Telephone).Column("TELEPHONE").Length(10);
            Map(x => x.Fax).Column("FAX").Length(10);
            Map(x => x.Email).Column("EMAIL").Length(64);
            Map(x => x.HomePage).Column("HOME_PAGE").Length(128);
            Map(x => x.Tax).Column("TAX");
            Map(x => x.Vat).Column("VAT");
            Map(x => x.PaymentMethod).Column("PAYMENT_METHOD");
            Map(x => x.Bank1).Column("BANK_1");
            Map(x => x.Branch1).Column("BRANCH_1").Length(128);
            Map(x => x.AccountType1).Column("ACCOUNT_TYPE_1");
            Map(x => x.AccountNo1).Column("ACCOUNT_NO_1").Length(10);
            Map(x => x.Bank2).Column("BANK_2");
            Map(x => x.Branch2).Column("BRANCH_2").Length(128);
            Map(x => x.AccountType2).Column("ACCOUNT_TYPE_2");
            Map(x => x.AccountNo2).Column("ACCOUNT_NO_2").Length(10);
            Map(x => x.BankChargeBy).Column("BANK_CHARGE_BY");
            Map(x => x.PaymentCondition).Column("PAYMENT_CONDITION");
            Map(x => x.OtherRemark).Column("OTHER_REMARK").Length(256);
            Map(x => x.Status).Column("STATUS");
            Map(x => x.AddressEng1).Column("ADDRESS_ENG_1").Length(512);
            Map(x => x.AddressTh1).Column("ADDRESS_TH_1").Length(512);
            Map(x => x.AddressEng2).Column("ADDRESS_ENG_2").Length(512);
            Map(x => x.AddressTh2).Column("ADDRESS_TH_2").Length(512);
        }
    }
}
