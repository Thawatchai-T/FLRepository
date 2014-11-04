using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections.Generic;
using NHibernate;
using NHibernate.ByteCode.Castle;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using KTBLeasing.FrontLeasing.Mapping.Orcl;

namespace Test.Repository.Orcl
{
    
    
    /// <summary>
    ///This is a test class for UsersAuthorizeRepositoryTest and is intended
    ///to contain all UsersAuthorizeRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UsersAuthorizeRepositoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetAll
        ///</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            UsersAuthorizeRepository target = new UsersAuthorizeRepository(); // TODO: Initialize to an appropriate value
            target.SessionFactory = CreateSessionFactory();
            List<UsersAuthorize> expected = null; // TODO: Initialize to an appropriate value
            List<UsersAuthorize> actual =  new List<UsersAuthorize>();
            actual = target.GetAll();
            Assert.AreEqual(true, actual.Count > 0);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            UsersAuthorizeRepository target = new UsersAuthorizeRepository(); // TODO: Initialize to an appropriate value
            UsersAuthorize entity = new UsersAuthorize(); // TODO: Initialize to an appropriate value
            target.SessionFactory = CreateSessionFactory();
            entity.Active = 1;
            entity.UserId = "test";
            entity.DepCode = "01";
               
            target.Insert(entity);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var sessionf = Fluently.Configure()
                    .ProxyFactoryFactory<ProxyFactoryFactory>()
                    .Database(OracleClientConfiguration.Oracle10.ConnectionString(x =>
                        x.Server("221.23.0.170")
                        .Port(1521)
                        .Username("fluser")
                        .Password("ktblitadmin")
                        .Instance("ktbl"))
                        )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RoleMap>())
                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
                    .BuildSessionFactory();
                return sessionf;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); //ex.Message;
                //  return null;
            }
        }

        [TestMethod]
        public void Testmaping()
        {
            Assert.AreEqual(true, !CreateSessionFactory().IsClosed);
        }

    }
}
