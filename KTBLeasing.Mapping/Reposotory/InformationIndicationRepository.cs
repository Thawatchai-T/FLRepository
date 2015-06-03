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
    public interface IInformationIndicationRepository
    {
        List<InformationIndication> GetAll();
        InformationIndication Get(long id);
        List<Background> GetBackground(long id);
        void Insert<T>(T entity);
        void Update<T>(T entity);
        void SaveOrUpdate<T>(T entity);
    }
    public class InformationIndicationRepository : NhRepository, IInformationIndicationRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public List<InformationIndication> GetAll()
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<InformationIndication>().List<InformationIndication>() as List<InformationIndication>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public InformationIndication Get(long id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.Get<InformationIndication>(id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }
        
        public List<Background> GetBackground(long id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<Background>()
                        .Fetch(x => x.InformationIndication).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                        .Where(x => x.InformationIndication.Id == id)
                        .List<Background>() as List<Background>;
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
