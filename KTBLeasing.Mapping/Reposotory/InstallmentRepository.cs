using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KTBLeasing.Domain;
using System.Reflection;
using KTBLeasing.FrontLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IInstallmentRepository
    {
        //List<Installment> Get(string agrcode, int SEQ, int marketing_group);
        List<Installment> Get(long Res_Id);
        void Insert(Installment entity);
        void Update(Installment entity);
        void SaveOrUpdate(Installment entity);
    }
    public class InstallmentRepository : NhRepository, IInstallmentRepository
    {
        //public List<Installment> Get(string agrcode, int SEQ, int marketing_group)
        //{
        //    using (var session = SessionFactory.OpenSession())
        //    {
        //        return (from x in session.QueryOver<Installment>().List()
        //                join y in session.QueryOver<UserInformation>().List()
        //                on x.CreateBy equals y.UsersAuthorize.UserId
        //                where x.Agreement == agrcode && x.SEQ == SEQ && y.MarketingGroup == marketing_group
        //                select x)
        //                .ToList<Installment>();
        //    }
        //}
        public List<Installment> Get(long Res_Id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<Installment>()
                    .Where(x => x.Res_Id == Res_Id)
                    .OrderBy(x => x.InstallNo).Asc
                    .List<Installment>() as List<Installment>;
            }
        }

        public void Insert(Installment entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.Insert<Installment>(entity);
            }
        }

        public void Update(Installment entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.Update<Installment>(entity);
            }
        }

        public void SaveOrUpdate(Installment entity)
        {
            //using (var session = SessionFactory.OpenSession())
            //{
                base.SaveOrUpdate<Installment>(entity);
            //}
        }
    }
}
