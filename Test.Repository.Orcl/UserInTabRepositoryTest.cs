using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KTBLeasing.FrontLeasing.Domain;
using FluentNHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using NHibernate.ByteCode.Castle;
using KTBLeasing.FrontLeasing.Mapping.Orcl;

namespace Test.Repository.Orcl
{
    
    
    /// <summary>
    ///This is a test class for UserInTabRepositoryTest and is intended
    ///to contain all UserInTabRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserInTabRepositoryTest
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
        ///A test for UserInTabRepository Constructor
        ///</summary>
        [TestMethod()]
        public void UserInTabRepositoryConstructorTest()
        {
            UserInTabRepository target = new UserInTabRepository();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            //UserInTabRepository target = new UserInTabRepository(); // TODO: Initialize to an appropriate value
            //target.SessionFactory = CreateSessionFactory();
            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            //var s = target.Get();
            //
            //UserInTab entity = new UserInTab
            //{
            //    TabId = 2,
            //    RoleId = 2,
            //    
            //    Description   = "testInsert",
            //    CreateBy = "woody",
            //    UpdateBy = "woody",
            //    UpdateDate   = DateTime.Now,
            //    CreateDate = DateTime.Now

            //};//null; // TODO: Initialize to an appropriate value
            //target.Insert(entity);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");

        }

        [TestMethod()]
        public void TestMap()
        {
            var session = CreateSessionFactory();
            Assert.Equals(true, !session.IsClosed);
        }

        [TestMethod]
        public void TestJoinUserInfo()
        {
            UserInfomationRepository target = new UserInfomationRepository();
            target.SessionFactory = CreateSessionFactory();

          //  var result = target.GetGridView();
        }


        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var sessionf = Fluently.Configure()
                    .ProxyFactoryFactory<ProxyFactoryFactory>()
                    .Database(OracleClientConfiguration.Oracle10.ConnectionString(x =>
                        x.Server("221.23.0.70")
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
    }
}
