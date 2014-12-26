using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;
using KTBLeasing.Domain;
using KTBLeasing.Domain.ViewCommonData;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IComboboxRepository
    {
        List<Province> GetProvince();
        List<TitleTh> GetTitleNameTh();
        List<TitleEng> GetTitleNameEn();
        List<DeparmentCode> GetDeparment();
        List<Position> GetPosition();
        List<MarketingGroup> GetMarketingGroup();
        int Count();
    }
    public class ComboboxRepository : NhRepository, IComboboxRepository
    {
        public List<Province> GetProvince()
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                var result = session.QueryOver<Province>().List();
                
                return result as List<Province>;
            }
        }

        public List<TitleTh> GetTitleNameTh()
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                var result = session.QueryOver<TitleTh>().List();

                return result as List<TitleTh>;
            }
        }

        public List<DeparmentCode> GetDeparment()
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                var result = session.QueryOver<DeparmentCode>().List();

                return result as List<DeparmentCode>;
            }
        }

        public List<TitleEng> GetTitleNameEn()
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                var result = session.QueryOver<TitleEng>().List();

                return result as List<TitleEng>;
            }
        }

        public List<Position> GetPosition()
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                var result = session.QueryOver<Position>().List();

                return result as List<Position>;
            }
        }

        public List<MarketingGroup> GetMarketingGroup()
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                var result = session.QueryOver<MarketingGroup>().List();

                return result as List<MarketingGroup>;
            }
        }

        public int Count()
        {
            using(var session = SessionFactory.OpenSession())
            {
                var result =  session.QueryOver<CommonData>().RowCount();
                session.Close();
                return result;
            }
        }
    }
}
