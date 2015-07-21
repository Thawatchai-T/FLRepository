using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using FluentNHibernate.Cfg;
using NHibernate.ByteCode.Castle;
using FluentNHibernate.Cfg.Db;
using KTBLeasing.FrontLeasing.Mapping.Orcl;

namespace KTBLeasing.FrontLeasing
{
    public class NHHelpers
    {
        private string Server { get; set; }
        private int Port { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Instance { get; set; }
        
        public ISessionFactory CreateSessionFactory()
        {
            try
            {
                var sessionf = Fluently.Configure()
                    .ProxyFactoryFactory<ProxyFactoryFactory>()
                    .Database(OracleClientConfiguration.Oracle10.ConnectionString(x =>
                        x.Server("221.23.0.70")
                        .Port(1521)
                        .Username("FrontLeasing_UAT")
                        .Password("ktblitadmin")
                        .Instance("ktbl"))
                        )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RoleMap>())
                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
                    .BuildSessionFactory();

                //var sessionf = Fluently.Configure()
                //    .ProxyFactoryFactory<ProxyFactoryFactory>()
                //    .Database(OracleClientConfiguration.Oracle10.ConnectionString(x =>
                //        x.Server(Server)
                //        .Port(Port)
                //        .Username(Username)
                //        .Password(Password)
                //        .Instance(Instance))
                //        )
                //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RoleMap>())
                //    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
                //    .BuildSessionFactory();
                return sessionf;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); //ex.Message;
                //  return null;
            }
        }
    }
}