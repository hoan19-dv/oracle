using CommonFunc;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection.PortableExecutable;

namespace CommonFunc
{
    public class CommonFunction
    {

        public static void InitConfigData(IConfiguration configuration)
        {
            try
            {
                ConfigInfo.ConnectionString = configuration["ConnectionString"]?.ToString();
               updateData(ConfigInfo.ConnectionString, 19, "hung", "nguyen", "hanoi", 20, "12a3");
                 // addData(ConfigInfo.ConnectionString, 19, "duy", "nguyen", "hanoi", 20, "12a3");
                 // getData(ConfigInfo.ConnectionString);
                 // deleteData(ConfigInfo.ConnectionString, 4);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static DataTable getData(string connectionString)
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            string queryString =  "SELECT * FROM sv";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
              
                OracleCommand command = new OracleCommand(queryString);
                command.Connection = connection;
                try
                {
                    connection.Open();

                    OracleDataReader dr = command.ExecuteReader();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        dataTable.Columns.Add(dr.GetName(i), dr.GetFieldType(i));
                    }
                    while (dr.Read())
                    {
                        var dataRow = dataTable.NewRow();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            dataRow[i] = dr.GetValue(i);
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                    ds.Tables.Add(dataTable);
                  
                }  
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }return dataTable;
        }

        public static void addData(string connectionString, int id, string firstname, string lastname, string city, int age, string classs)
        {
            string queryString = "INSERT INTO sv (ID, FIRST_NAME, LAST_NAME, CITY, AGE, CLASS) VALUES (:id, :firstname, :lastname, :city, :age, :classs)";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand cmd = new OracleCommand(queryString);

                // Adding parameters to prevent SQL injection
                cmd.Parameters.Add(new OracleParameter("id", id));
                cmd.Parameters.Add(new OracleParameter("firstname", firstname));
                cmd.Parameters.Add(new OracleParameter("lastname", lastname));
                cmd.Parameters.Add(new OracleParameter("city", city));
                cmd.Parameters.Add(new OracleParameter("age", age));
                cmd.Parameters.Add(new OracleParameter("classs", classs));
                cmd.Connection = connection;
                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void updateData(string connectionString, int id, string firstname, string lastname, string city, int age, string classs)
        {
            string queryString = "UPDATE sv SET FIRST_NAME = :firstname, LAST_NAME = :lastname, CITY = :city, AGE = :age, CLASS = :classs WHERE ID = :id";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand cmd = new OracleCommand(queryString, connection);

                cmd.Parameters.Add(new OracleParameter("id", id));
                cmd.Parameters.Add(new OracleParameter("firstname", firstname));
                cmd.Parameters.Add(new OracleParameter("lastname", lastname));
                cmd.Parameters.Add(new OracleParameter("city", city));
                cmd.Parameters.Add(new OracleParameter("age", age));
                cmd.Parameters.Add(new OracleParameter("classs", classs));

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public static void deleteData(string connectionString,int id) {
            string queryString = $"DELETE FROM sv WHERE ID={id}";
            using (OracleConnection connection = new OracleConnection(connectionString)) { 
            OracleCommand cmd = new OracleCommand(queryString);
              
                cmd.Connection=connection;
                try { 
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                }
                catch (Exception ex) {                
                    Console.WriteLine(ex.Message);}
            }
        }
    }
}
