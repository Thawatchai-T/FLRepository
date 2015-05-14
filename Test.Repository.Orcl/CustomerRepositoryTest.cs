using KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KTBLeasing.Domain.ViewCommonData;
using System.Collections.Generic;
using NHibernate;
using FluentNHibernate.Cfg;
using NHibernate.ByteCode.Castle;
using FluentNHibernate.Cfg.Db;
using KTBLeasing.FrontLeasing.Mapping.Orcl;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;
using System.Data;

namespace Test.Repository.Orcl
{
    
    
    /// <summary>
    ///This is a test class for CustomerRepositoryTest and is intended
    ///to contain all CustomerRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomerRepositoryTest
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
        ///A test for GetCustomerInfoPopup
        ///</summary>
        [TestMethod()]
        public void GetCustomerInfoPopupTest()
        {
            CustomerRepository target = new CustomerRepository(); // TODO: Initialize to an appropriate value
            target.SessionFactory = CreateSessionFactory();
            
            List<CommonCustomerDomain> actual;
          //  actual = target.GetCustomerInfoPopup();
            //Assert.AreEqual(2, actual.Count);
            
        }


        [TestMethod]
        public void TestInsertWaiveDocument()
        {
            try
            {
                CustomerRepository target = new CustomerRepository();
                target.SessionFactory = CreateSessionFactory();
                ApplicationDetailViewModel entity = new ApplicationDetailViewModel();
                
                //WaiveDocument entity = new WaiveDocument();
                //appdetail.ApplicationDetail =(entity.ApplicationDetail ==null)?new ApplicationDetail():entity.ApplicationDetail;

                //entity.AppId = 1;
                //entity.ApplicationDetail.Id = 1;
                //entity.Document ="test";
                //entity.Reason = "tset:";
                entity.WaiveDocument = (entity.WaiveDocument == null) ? new WaiveDocument() : entity.WaiveDocument;
                entity.WaiveDocument.AppId = 1;
                entity.WaiveDocument.ApplicationDetail.Id = 1;
                entity.WaiveDocument.Document = "test2";
                entity.WaiveDocument.Reason = "test2";
                entity.WaiveDocument.AppId = 1;
                


                target.Insert<WaiveDocument>(entity.WaiveDocument); 


                List<CommonCustomerDomain> actual;
                //  actual = target.GetCustomerInfoPopup();
            }
            catch (Exception ex)
            {

            }

        }

        [TestMethod]
        public void TestTab()
        {
            try
            {
               var repo = new CustomerRepository();
               repo.SessionFactory = CreateSessionFactory();

               var result = repo.ExecuteICriteria<Tab>();
            }
            catch (Exception ex)
            {

            }
        }

        private  ISessionFactory CreateSessionFactory()
        {
            try
            {
                var sessionf = Fluently.Configure()
                    .ProxyFactoryFactory<ProxyFactoryFactory>()
                    .Database(OracleClientConfiguration.Oracle10.ConnectionString(x =>
                        x.Server("221.23.0.70")
                        .Port(1521)
                        .Username("frontleasing")
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


        //public static T ConvertToEntity<T>(this DataRow tableRow) where T : new()
        //{
        //    // Create a new type of the entity I want
        //    Type t = typeof(T);
        //    T returnObject = new T();

        //    foreach (DataColumn col in tableRow.Table.Columns)
        //    {
        //        string colName = col.ColumnName;

        //        // Look for the object's property with the columns name, ignore case
        //        PropertyInfo pInfo = t.GetProperty(colName.ToLower(),
        //            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

        //        // did we find the property ?
        //        if (pInfo != null)
        //        {
        //            object val = tableRow[colName];
        //            if (colName.ToLower() == "amount4")
        //            {
        //                val = tableRow[colName];
        //            }
        //            // is this a Nullable<> type
        //            bool IsNullable = (Nullable.GetUnderlyingType(pInfo.PropertyType) != null || val is System.DBNull);
        //            if (IsNullable)
        //            {
        //                if (val is System.DBNull)
        //                {
        //                    val = null;
        //                }
        //                else
        //                {
        //                    // Convert the db type into the T we have in our Nullable<T> type
        //                    val = Convert.ChangeType
        //            (val, Nullable.GetUnderlyingType(pInfo.PropertyType));
        //                }
        //            }
        //            else
        //            {
        //                // Convert the db type into the type of the property in our entity
        //                try
        //                {
        //                    val = Convert.ChangeType(val, pInfo.PropertyType);
        //                }
        //                catch (Exception ex)
        //                {
        //                    //ex;
        //                }
        //            }
        //            // Set the value of the property with the value from the db
        //            pInfo.SetValue(returnObject, val, null);
        //        }
        //    }

        //    // return the entity object with values
        //    return returnObject;
        //}
    }
}
