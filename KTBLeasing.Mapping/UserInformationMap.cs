using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl
{
    public class UserInformationMap : ClassMap<UserInformation>
    {

        public UserInformationMap() {
            Table("USER_INFORMATION");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Sequence("SEQ_ADDRESS");
            References(x => x.UsersAuthorize).Column("USER_ID");
            Map(x => x.TitleNameTh).Column("TITLE_NAME_TH").Not.Nullable();
            Map(x => x.TitleNameEng).Column("TITLE_NAME_ENG");
            Map(x => x.FristNameTh).Column("FRIST_NAME_TH");
            Map(x => x.LastNameTh).Column("LAST_NAME_TH");
            Map(x => x.FristNameEng).Column("FRIST_NAME_ENG");
            Map(x => x.LastNameEng).Column("LAST_NAME_ENG");
            Map(x => x.Position).Column("POSITION").Not.Nullable();
            Map(x => x.MarketingGroup).Column("MARKETING_GROUP").Not.Nullable();
            Map(x => x.MarketingCode).Column("MARKETING_CODE").Not.Nullable();
            Map(x => x.CreateDate).Column("CREATE_DATE");
            Map(x => x.UpdateDate).Column("UPDATE_DATE");
            Map(x => x.CreateBy).Column("CREATE_BY");
            Map(x => x.UpdateBy).Column("UPDATE_BY");
            Map(x => x.DeparmentCode).Column("DEPARMENT_CODE");
        }
    }
}
