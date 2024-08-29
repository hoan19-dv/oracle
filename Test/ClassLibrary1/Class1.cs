using java.awt.print;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Dapper;
using ClassLibrary1;
using com.sun.xml.@internal.bind.v2.model.core;
using java.beans;
using Z.Dapper.Plus;
using java.util.logging;
using Microsoft.Extensions.Logging;


namespace WebApplication2

{
    
    public class Connect
    {
        public static ILogger<Connect> _logger;

        public Connect(ILogger<Connect> logger)
        {
            _logger = logger;
        }
        public static  async void getData()
        { 

            var connectionString = "User Id=TEST_DEV;Password=TEST_DEV;Validate Connection=True;Data Source=//192.168.2.11:1521/ORADB;Min Pool Size=10;Connection Lifetime=120;Connection Timeout=60;Incr Pool Size=5; Decr Pool Size=2; Max Pool Size=100; Pooling=true; Statement Cache Size=1;";
            using (var connection = new OracleConnection(connectionString))
            {


                //LAY 1 HANG
                //var sql2 = "SELECT * FROM sv WHERE ID=5";
                // var sv2 =await connection.QuerySingleAsync(sql2);
                // var sql3 = "SELECT * FROM sv WHERE ID=5";//neu 2 id giong nhau se lay hang dau tien
                // var sv3 = connection.QueryFirst(sql3);
                //LAY NHIEU HANG
                 var sql4 = "SELECT * FROM sv";
                 var sv4 = connection.Query<sv>(sql4);
                //TRUY VAN COT CU THE
                //var sql5 = "SELECT AGE,LAST_NAME FROM sv WHERE ID=:authorName";
                // var sv5 = connection.Query(sql5, new { authorName = "5" });
                // var sql6 = "INSERT INTO sv (AGE, LAST_NAME) VALUES (:age, :lastname)";
                // var sv6 = connection.Execute(sql6, new {age=50,lastname= "hoang" });

                /*var sql7 = "SELECT * FROM sv";
                 var sv7 = connection.ExecuteReader(sql7);
                 DataTable dataTable = new DataTable();
                 dataTable.Load(sv7);
                 while (sv7.Read())
                 {
                     int id = sv7.GetInt32(0);
                 }
                 */

                

            }
        }

        public static void addData(int id,string firstname, string lastname, string city, int age,string classs)
        {
          
          var connectionString = "User Id=TEST_DEV;Password=TEST_DEV;Validate Connection=True;Data Source=//192.168.2.11:1521/ORADB;Min Pool Size=10;Connection Lifetime=120;Connection Timeout=60;Incr Pool Size=5; Decr Pool Size=2; Max Pool Size=100; Pooling=true; Statement Cache Size=1;";
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    var queryString = "INSERT INTO sv (ID, FIRST_NAME, LAST_NAME, CITY, AGE, CLASS) VALUES (:idd, :firstnamee, :lastnamee, :cityy, :agee, :classss)";
                    object[] parameters = { new { idd = id, firstnamee = firstname, lastnamee = lastname, cityy = city, agee = age, classss = classs } };
                    var affectedRows = connection.Execute(queryString, parameters);
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message);
                    _logger.LogError(ex, "An error occurred while performing the task.");
    }
}
        }

        public static void updateData(int id, string firstname, string lastname, string city, int age, string classs)
        {
            var connectionString = "User Id=TEST_DEV;Password=TEST_DEV;Validate Connection=True;Data Source=//192.168.2.11:1521/ORADB;Min Pool Size=10;Connection Lifetime=120;Connection Timeout=60;Incr Pool Size=5; Decr Pool Size=2; Max Pool Size=100; Pooling=true; Statement Cache Size=1;";
            using (var connection=new OracleConnection(connectionString))
            {
                try
                {
                    var queryString = "UPDATE sv SET FIRST_NAME = :firstnamee, LAST_NAME = :lastnamee, CITY = :cityy, AGE = :agee, CLASS = :classss WHERE ID = :idd";
                    object[] parameters = { new { idd = id, firstnamee = firstname, lastnamee = lastname, cityy = city, agee = age, classss = classs } };

                    var affectedRows = connection.Execute(queryString, parameters);
                } catch (Exception ex) {
                    _logger.LogError(ex, "An error occurred while performing the task.");
                    Console.WriteLine(ex.Message);
                } 
            }
        }

        public static void deleteData(int id)
        {
            var connectionString = "User Id=TEST_DEV;Password=TEST_DEV;Validate Connection=True;Data Source=//192.168.2.11:1521/ORADB;Min Pool Size=10;Connection Lifetime=120;Connection Timeout=60;Incr Pool Size=5; Decr Pool Size=2; Max Pool Size=100; Pooling=true; Statement Cache Size=1;";
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    var queryString = "DELETE FROM sv WHERE ID=:idd";
                    var affectedRows = connection.Execute(queryString, new { idd = id });
                } catch (Exception ex) { 
                    Console.WriteLine(ex.Message);
                    _logger.LogError(ex, "An error occurred while performing the task.");
                }
            }
        }

        
    }
}

