using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;
using log4net;
using System.Reflection;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IEquipmentListRepository
    {
        int Count();
        int Count(string text);
        List<EquipmentList> Find(int start, int limit, string text);
        List<EquipmentList> GetAll();
        List<EquipmentList> GetAllWithOrderBy(string orderby);
        List<EquipmentList> GetByAppId(int start, int limit, long app_id);
        List<EquipmentList> GetByPOId(int start, int limit, long app_id, long po_id);
        void Insert(EquipmentList entity);
        void Update(EquipmentList entity);
        void Delete(long id);
        void SaveOrUpdate(EquipmentList entity);
    }

    public class EquipmentListRepository : NhRepository, IEquipmentListRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Insert(EquipmentList entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.Save(entity);
                    ts.Commit();
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    ts.Rollback();
                }
            }
        }

        public void Update(EquipmentList entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.Update(entity);
                    ts.Commit();
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    ts.Rollback();
                }
            }
        }

        public void SaveOrUpdate(EquipmentList entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(entity);
                    ts.Commit();
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                }
            }
        }

        public void Delete(long id)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.Delete(id);
                    ts.Commit();
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                }
            }
        }

        public List<EquipmentList> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<EquipmentList>().List<EquipmentList>() as List<EquipmentList>;

                //return this.ExecuteICriteria<EquipmentList>() as List<EquipmentList>;
            }
        }

        public List<EquipmentList> GetAllWithOrderBy(string orderby)
        {
            return this.ExecuteICriteriaOrderBy<EquipmentList>(new EquipmentList(), orderby) as List<EquipmentList>;
        }

        public List<EquipmentList> GetByAppId(int start, int limit, long app_id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                try
                {
                    var list = session.QueryOver<EquipmentList>()
                        .Fetch(x => x.ApplicationDetail).Eager
                        .Fetch(x => x.ApplicationDetail.Job).Eager
                        .Fetch(x => x.ApplicationDetail.Job.Customer).Eager
                        .Fetch(x => x.ApplicationDetail.Job.MarketingOfficer).Eager
                        .Fetch(x => x.ApplicationDetail.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.Job).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.Job.Customer).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.Job.MarketingOfficer).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.Job).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.Job.Customer).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.Job.MarketingOfficer).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.VisitInformationDomain).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.VisitInformationDomain.Job).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.VisitInformationDomain.Job.Customer).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.VisitInformationDomain.Job.MarketingOfficer).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.VisitInformationDomain.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.PurchaseOrder).Eager
                        .Where(x => x.ApplicationDetail.Id == app_id)
                        .List<EquipmentList>() as List<EquipmentList>;

                    return list;
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    return null;
                }
            }
        }

        public List<EquipmentList> GetByPOId(int start, int limit, long app_id, long po_id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                try
                {
                    var list = session.QueryOver<EquipmentList>()
                        .Fetch(x => x.ApplicationDetail).Eager
                        .Fetch(x => x.ApplicationDetail.Job).Eager
                        .Fetch(x => x.ApplicationDetail.Job.Customer).Eager
                        .Fetch(x => x.ApplicationDetail.Job.MarketingOfficer).Eager
                        .Fetch(x => x.ApplicationDetail.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.Job).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.Job.Customer).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.Job.MarketingOfficer).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.Job).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.Job.Customer).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.Job.MarketingOfficer).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.VisitInformationDomain).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.VisitInformationDomain.Job).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.VisitInformationDomain.Job.Customer).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.VisitInformationDomain.Job.MarketingOfficer).Eager
                        .Fetch(x => x.ApplicationDetail.IndicationEquipment.InformationIndication.VisitInformationDomain.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.PurchaseOrder).Eager
                        .Where(x => x.PurchaseOrder.Id == po_id)
                        .List<EquipmentList>() as List<EquipmentList>;

                    return list;
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    return null;
                }
            }
        }
             
        public int Count()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<EquipmentList>().RowCount();
                session.Close();
                return result;
            }
        }

        //find searech
        public List<EquipmentList> Find(int start, int limit, string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = (from x in session.QueryOver<EquipmentList>().List<EquipmentList>() where x.EquipmentName.Contains(text) select x).Skip(start).Take(limit);
                //var result = session.QueryOver<EquipmentList>().List<EquipmentList>().Where(w => w.EquipmentListTh.Contains(text) || w.EquipmentListEng.Contains(text)).Skip(start).Take(limit);
                //session.Close();
                return result.ToList<EquipmentList>();

            }
        }

        public int Count(string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<EquipmentList>().List<EquipmentList>().Where(w => w.EquipmentName.Contains(text));
                session.Close();
                return result.ToList<EquipmentList>().Count;
            }
        }
    }
}
