using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Reflection;
using KTBLeasing.FrontLeasing.Domain;
using NHibernate.Transform;
using NHibernate.Criterion;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IIndicationEquipmentRepository
    {
        List<IndicationEquipment> GetAll(int start, int limit, long jobId);
        List<Equipment> GetEquipment(long indicationId);
        IndicationEquipment Get(long id);
        void Insert<T>(T entity);
        void Update<T>(T entity);
        void SaveOrUpdate<T>(T entity);
    }
    public class IndicationEquipmentRepository : NhRepository, IIndicationEquipmentRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public List<IndicationEquipment> GetAll(int start, int limit, long jobId)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<IndicationEquipment>()
                        .Fetch(x => x.Job).Eager
                        .Fetch(x => x.Job.Customer).Eager
                        .Fetch(x => x.Job.MarketingOfficer).Eager
                        .Fetch(x => x.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.InformationIndication).Eager
                        .Fetch(x => x.InformationIndication.Job).Eager
                        .Fetch(x => x.InformationIndication.Job.Customer).Eager
                        .Fetch(x => x.InformationIndication.Job.MarketingOfficer).Eager
                        .Fetch(x => x.InformationIndication.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain.Job).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain.Job.Customer).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain.Job.MarketingOfficer).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Where(x => x.Job.Id == jobId)
                        .OrderBy(x => x.Id).Asc
                        .Skip(start).Take(limit)
                        .List<IndicationEquipment>() as List<IndicationEquipment>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public List<Equipment> GetEquipment(long indicationId)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<Equipment>()
                        .Fetch(x => x.IndicationEquipment).Eager
                        .Fetch(x => x.IndicationEquipment.Job).Eager
                        .Fetch(x => x.IndicationEquipment.Job.Customer).Eager
                        .Fetch(x => x.IndicationEquipment.Job.MarketingOfficer).Eager
                        .Fetch(x => x.IndicationEquipment.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.Job).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.Job.Customer).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.Job.MarketingOfficer).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.VisitInformationDomain).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.VisitInformationDomain.Job).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.VisitInformationDomain.Job.Customer).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.VisitInformationDomain.Job.MarketingOfficer).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.VisitInformationDomain.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Where(x => x.IndicationEquipment.Id == indicationId)
                        .List<Equipment>() as List<Equipment>;

                    //var criteria = session.CreateCriteria("Equipment", "Equipment");
                    //criteria.CreateAlias("Equipment.IndicationEquipment", "IndicationEquipment");
                    //criteria.CreateAlias("IndicationEquipment.InformationIndication", "InformationIndication");
                    //criteria.Add(Restrictions.Eq("IndicationEquipment.Id", indicationId));
                    //return criteria.List<Equipment>() as List<Equipment>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public IndicationEquipment Get(long id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.Get<IndicationEquipment>(id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public void Insert<T>(T entity)
        {
            try
            {
                base.Insert<T>(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public void Update<T>(T entity)
        {
            try
            {
                base.Update<T>(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public void SaveOrUpdate<T>(T entity)
        {
            try
            {
                base.SaveOrUpdate<T>(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

    }
}
