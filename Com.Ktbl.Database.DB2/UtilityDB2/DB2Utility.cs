using System;
using System.Data;
using System.IO;
//using IBM.Data.DB2;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using log4net;


public class DbAuth
{
#region Properties
    public string _Provider { get; set; }
    public string _Password { get; set; }
    public string _UserID { get; set; }
    public string _DATABASE { get; set; }
    public string _SERVER { get; set; }
#endregion

    public OleDbConnection dbConn { get; set; }
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
  // Helper method: This method establishes a connection to a database
  //public static DB2Connection ConnectDb()
  //{
  //  string connectstring = string.Format("");
  //  DB2Connection conn = null;
  //  
  //  try{

  //      dbConn = new OleDbConnection("Provider=IBMDADB2.DB2COPY2;Password =JUNEJULY;Persist Security Info=True;User ID =KEMADIST;Data Source=KTBL;Location=221.23.0.2;Extended Properties=''");
  //      dbConn.Open();

  //      conn = new DB2Connection("Server=221.23.0.2:50000;Database=KTBL;UID=KEMADIST;PWD=JUNEJULY");
  //      conn.Open();
  //      
  //    
  //  }catch(DB2Exception ex){

  //  }catch(Exception ex){

  //  }
  //  return conn;

  //} // ConnectDb

  //public static bool ExcuteUpdate(string sql, DB2Connection conn)
  //{
  //    var trans = conn.BeginTransaction();
  //    try
  //    {
  //        DB2Command cmd = conn.CreateCommand();
  //        cmd.CommandText = sql;
  //        trans.Commit();
  //      return true;
  //    }catch(DB2Exception ex){
  //        trans.Rollback();          
  //        return false;
  //        
  //    }catch(Exception ex){
  //        trans.Rollback();
  //        return false;

  //    }finally{
  //        conn.Close();
  //    }
  //}//executeUpdate

  //public static void ExcuteResult(string sql, DB2Connection conn)
  //{
  //    var trans = conn.BeginTransaction();


  //}

  //// This method shows how to revoke user authorities on a database
  //public static void Revoke(DB2Connection conn, DB2Transaction trans)
  //{
  //  Console.WriteLine();
  //  Console.WriteLine(
  //    "  ----------------------------------------------------------\n" +
  //    "  USE THE SQL STATEMENTS:\n" +
  //    "    REVOKE (Database Authorities)\n" +
  //    "    COMMIT\n" +
  //    "  TO REVOKE AUTHORITIES AT DATABASE LEVEL.");

  //  try
  //  {
  //    // Revoke authorities of 'user1'
  //    Console.WriteLine();
  //    Console.WriteLine(
  //      "    REVOKE CONNECT, CREATETAB, BINDADD\n" +
  //      "      ON DATABASE\n" +
  //      "      FROM USER user1");
  //    DB2Command cmd = conn.CreateCommand();
  //    cmd.CommandText = "REVOKE CONNECT, CREATETAB, BINDADD " +
  //                      " ON DATABASE " +
  //                      " FROM USER user1";
  //    cmd.Transaction = trans;
  //    cmd.ExecuteNonQuery();

  //    // Commit the transaction
  //    Console.WriteLine();
  //    Console.WriteLine("    COMMIT");
  //    trans.Commit();
  //  }
  //  catch (Exception e)
  //  {
  //    Console.WriteLine(e.Message);
  //    trans.Rollback();
  //  }
  //} // Revoke

  public static void TestOleDbConnection(){
       
        //OleDbConnection conn = new OleDbConnection();
        OleDbConnection dbConn = new OleDbConnection("Provider=IBMDADB2.DB2COPY2;Password =JUNEJULY;Persist Security Info=True;User ID =KEMADIST;Data Source=KTBL;Location=221.23.0.2;Extended Properties=''");//"Provider=IBMDADB2.DB2COPY2;Password=JUNEJULY;Persist Security Info=True;User ID=KEMADIST;Data Source=KTBL;Location='';Extended Properties='' ");
        //conn.ConnectionString = "Driver=IBMDADB2; DataBase=DataBaseName; HostName=ServerName; Protocol=TCPIP; Port=PortNumber; Uid=UserName; Pwd=Secret;"; 
        dbConn.Open();
  }

  //public static string GetSchemaName(DB2Connection conn, String tableName)
  //{
  //    
  //    try
  //    {
  //        DB2Command cmd = conn.CreateCommand();
  //        cmd.CommandText = "SELECT tabschema " +
  //                          "  FROM syscat.tables " +
  //                          "  WHERE tabname = '" + tableName + "'";
  //        DB2DataReader reader = cmd.ExecuteReader();
  //        reader.Read();
  //        string schemaname = reader.GetString(0);
  //        reader.Close();
  //        return schemaname;
  //    }
  //    catch (Exception e)
  //    {
  //        Console.WriteLine(e.Message);
  //        return null;
  //    }
  //} // GetSchemaName

  //public static List<string> GetColumnInfo(DB2Connection conn, String tableName)
  //{
  //    String dataColname = "";
  //    String dataTypename = "";
  //    Int32 dataLength = 0;
  //    Int32 dataScale = 0;
  //    List<string> columnName = new List<string>();
  //    Console.WriteLine();
  //    Console.WriteLine(
  //      "  ----------------------------------------------------------\n" +
  //      "  USE THE SQL STATEMENTS:\n" +
  //      "    SELECT\n" +
  //      "  TO GET THE COLUMN INFORMATION OF A TABLE.");

  //    try
  //    {
  //        // Get the column information for a table
  //        Console.WriteLine();
  //        Console.WriteLine(
  //          "    The following SQL statement gets the column information \n" +
  //          "    of the '" + tableName + "' table: \n");

  //        Console.WriteLine(
  //          "    SELECT colname, typename, length, scale \n" +
  //          "      FROM syscat.columns \n" +
  //          "      WHERE tabname = '" + tableName + "'\n");

  //        Console.WriteLine(
  //          "      column name          data type      data size\n" +
  //          "      -------------------- -------------- ----------");

  //        // Create a DB2Command to execute the SQL statement
  //        DB2Command cmd = conn.CreateCommand();
  //        cmd.CommandText = "SELECT colname, typename, length, scale " +
  //                          "  FROM syscat.columns " +
  //                          "  WHERE tabname = '" + tableName + "'\n";
  //        DB2DataReader reader = cmd.ExecuteReader();

  //        // Check if the query returned no data
  //        if (reader.Read() == false)
  //        {
  //            Console.WriteLine();
  //            Console.WriteLine("    Data not found.\n");
  //        }

  //        // Retrieve and display the column information from the DB2DataReader
  //        do
  //        {
  //            //add colname to list 
  //            columnName.Add(reader.GetString(0));

  //            dataColname = reader.GetString(0);
  //            dataTypename = reader.GetString(1);
  //            dataLength = reader.GetInt32(2);
  //            dataScale = reader.GetInt16(3);
  //            Console.Write("      " + dataColname.PadRight(20) +
  //                          " " + dataTypename.PadRight(14) +
  //                          " " + dataLength);
  //            if (dataScale != 0)
  //            {
  //                Console.WriteLine("," + dataScale);
  //            }
  //            else
  //            {
  //                Console.WriteLine();
  //            }
  //        } while (reader.Read());

  //        reader.Close();
  //        return columnName;
  //    }
  //    catch (Exception e)
  //    {
  //        Console.WriteLine(e.Message);
  //        return null;
  //    }
//  } // GetColumnInfo

  //public static DataSet DataSetFillSchema(DB2Connection conn, string tablename, string wherecodition = " ")
  //{
  //    try
  //    {
  //        // Create a DB2DataAdapter
  //        DB2DataAdapter adapt = new DB2DataAdapter();
  //        adapt.SelectCommand = new DB2Command("SELECT *" +
  //                                             "  FROM "+tablename+" " +
  //                                             "  WHERE "+wherecodition, conn);

  //        // Create a DataSet to which constraints are to be added
  //        DataSet dset = new DataSet();
  //        Console.WriteLine("\n  ADDING EXISTING CONSTRAINTS USING THE" +
  //                          " FillSchema() METHOD \n  OF DB2DataAdapter ...\n");

  //        // Configure the schema of 'dset' to match that of the 'staff' table 
  //        adapt.FillSchema(dset, SchemaType.Source, tablename);
  //        Console.WriteLine("  ... CONSTRAINTS ADDED\n");
  //        adapt.Fill(dset, tablename);
  //        return dset;
  //    }
  //    catch (Exception e)
  //    {
  //        Console.WriteLine(e.Message);
  //        return null;
  //    }
  //} // DataSetFillSchema

  // This method adds constraints to a DataSet using the MissingSchemaAction
  // property of DB2DataAdapater
  //public static void DataSetMissingSchemaAction(DB2Connection conn)
  //{
  //    try
  //    {
  //        // Create a DB2DataAdapter
  //        DB2DataAdapter adapt = new DB2DataAdapter();
  //        adapt.SelectCommand = new DB2Command("SELECT *" +
  //                                             "  FROM staff " +
  //                                             "  WHERE id > 300", conn);

  //        // Create a DataSet to which constraints are to be added
  //        DataSet dset = new DataSet();

  //        // Adds the necessary columns and primary key information to complete
  //        // the schema of the DataSet if its existing schema does not match 
  //        // the incoming data
  //        Console.WriteLine("  ADDING EXISTING CONSTRAINTS USING THE " +
  //                          "MissingSchemaAction \n" +
  //                          "  PROPERTY OF DB2DataAdapter ...\n");
  //        adapt.MissingSchemaAction = MissingSchemaAction.AddWithKey;
  //        adapt.Fill(dset, "staff");
  //        Console.WriteLine("  ... CONSTRAINTS ADDED");
  //    }
  //    catch (Exception e)
  //    {
  //        Console.WriteLine(e.Message);
  //    }
  //} // DataSetMissingSchemaAction

  public DataTable ExecuteQuery(string tablename, string joincodition="",string wharecodition="1=1")
  {
      var cn = GetOleDBConnetion(); 
      DataTable dt = new DataTable();
      var sql = string.Format("select * from {0} {1} where {2} WITH UR ", tablename, joincodition,wharecodition);
      cn.Open();
      OleDbCommand cmd = new OleDbCommand(sql, cn);
      OleDbDataReader reader = cmd.ExecuteReader();
      dt.Load(reader);
      cn.Close();
      return dt;
  }

  public DataTable ExecuteQuery(string tablename, string wharecodition = "1=1")
  {
      var cn = GetOleDBConnetion();
      DataTable dt = new DataTable();
      var sql = string.Format("select * from {0} where {1} WITH UR ", tablename, wharecodition);
      cn.Open();
      OleDbCommand cmd = new OleDbCommand(sql, cn);
      OleDbDataReader reader = cmd.ExecuteReader();
      dt.Load(reader);
      cn.Close();
      return dt;
  }

  public DataTable ExecuteQueryWithSQL(string sql)
  {
      var cn = GetOleDBConnetion();
      DataTable dt = new DataTable();
      
      cn.Open();
      //OleDbCommand cmd = new OleDbCommand(sql, cn);
      using (var cmd = new OleDbCommand(sql, cn))
      {
          cmd.CommandTimeout = 360;
          OleDbDataReader reader = cmd.ExecuteReader();
          dt.Load(reader);
          cn.Close();
          return dt;
      }
      

      
  }

  public DataTable ExecuteUpdate(string tablename, string value)
  {
      var cn = GetOleDBConnetion();
      DataTable dt = new DataTable();
      var sql = string.Format("select * from {0} ", tablename, value);
      cn.Open();
      OleDbCommand cmd = new OleDbCommand(sql, cn);
      OleDbDataReader reader = cmd.ExecuteReader();
      dt.Load(reader);
      return dt;
  }

  public OleDbConnection GetOleDBConnetion()
  {
      var constr = string.Format("Provider={0};Password ={1};Persist Security Info=True;User ID ={2};Data Source={3};Location={4};Extended Properties=''",
                        _Provider,
                        _Password,
                        _UserID,
                        _DATABASE,
                        _SERVER);

      string ConnectionStr = constr;
      var cn = new OleDbConnection(ConnectionStr);
      return cn;
  }

  public bool ExecuteTransaction(List<string> lsql)
  {
      using (OleDbConnection connection = GetOleDBConnetion())
      {
          OleDbCommand command = new OleDbCommand();
          OleDbTransaction transaction = null;

          // Set the Connection to the new OleDbConnection.
          command.Connection = connection;

          // Open the connection and execute the transaction. 
          try
          {
              connection.Open();

              // Start a local transaction with ReadCommitted isolation level.
              transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

              // Assign transaction object for a pending local transaction.
              command.Connection = connection;
              command.Transaction = transaction;
              Logger.Debug("INFO SQL");
              // Execute the commands.
             
              lsql.ForEach(x => {
                  Logger.Error(x);
             
                  command.CommandText = x;
                  command.ExecuteNonQuery();  
              });

             
              // Commit the transaction.
              transaction.Commit();
              return true;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              Logger.Error(ex);
              try
              {
                  // Attempt to roll back the transaction.
                  transaction.Rollback();
              }
              catch (Exception e)
              {
                  // Do nothing here; transaction is not active.
                  Logger.Error("Do nothing here; transaction is not active.");
                  throw new Exception("Do nothing here; transaction is not active.");
              }

              throw ex;
          }
          // The connection is automatically closed when the 
          // code exits the using block.
      }
  }

} // DbAuth
