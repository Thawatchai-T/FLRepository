using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public class CommonAddressRepository : NhRepository
    {
        public void Insert(CommonAddress entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Save(entity);
                ts.Commit();
            }
        }

        public List<CommonAddress> Get()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<CommonAddress>().List<CommonAddress>() as List<CommonAddress>;
            }
        }
//[20141211] Thawatchai.t Sample sql to bean entity with use function Transformers.AliasToBeanConstructor
        public void getsql()
        {
            

            using (var session = SessionFactory.OpenSession())
            {
                var result = session.CreateSQLQuery("SELECT  "+
                                                    "  ID AS Id, "+
                                                    "  PARENT_ID AS Parent_id, " +
                                                    "  level AS Levels, " +
                                                    "  name Name, CONNECT_BY_ISLEAF AS ISLEAF " +
                                                    "FROM COMMON_DATA "+
                                                    "  CONNECT BY prior id = PARENT_ID "+
                                                    "  START WITH name_eng     = 'address' ");
                var aa = result.List();
                var tra = result.SetResultTransformer(Transformers.AliasToBeanConstructor( typeof(CommonAddress).GetConstructors().First())).List<CommonAddress>();
                var c = tra.Count;

            }
        }



        public int Count()
        {
            using(var session = SessionFactory.OpenSession())
            {
                var result =  session.QueryOver<CommonAddress>().RowCount();
                session.Close();
                return result;
            }
        }
    }

    partial class CommonAddress11
    {
        public virtual Decimal ID { get; set; }
        public virtual int PARENT_ID { get; set; }
        public virtual int LEVELS { get; set; }
        public virtual string NAME { get; set; }
        public virtual bool ISLEAF { get; set; }
    }
}
