using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Reflection;
using KTBLeasing.FrontLeasing.Domain;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IIndicationEquipmentRepository
    {
        List<IndicationEquipment> GetAll();
        List<Equipment> GetEquipment(long indicationId);
        IndicationEquipment Get(long id);
        void Insert<T>(T entity);
        void Update<T>(T entity);
        void SaveOrUpdate<T>(T entity);
    }
    public class IndicationEquipmentRepository : NhRepository, IIndicationEquipmentRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public List<IndicationEquipment> GetAll()
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<IndicationEquipment>().List<IndicationEquipment>() as List<IndicationEquipment>;
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
                        .Fetch(x => x.IndicationEquipment).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                        .Where(x => x.IndicationEquipment.Id == indicationId)
                        .List<Equipment>() as List<Equipment>;
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
