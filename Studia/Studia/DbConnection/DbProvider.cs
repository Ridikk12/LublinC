using System;
using System.Data;
using System.Data.SqlClient;

namespace Studia.DbConnection
{
    public static class DbProvider
    {
        private static string _connectionString = @"Data Source =(LocalDB)\MSSQLLocalDB; Initial Catalog = studia; Integrated Security = True;";
        private static SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        public static DataTable GetDataSelectQuery(string sqlStatement)
        {
            _sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, _sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            _sqlConnection.Close();
            return dt;
        }

        public static bool InsertQuery(string sqlStatement)
        {
            try
            {
                _sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlStatement, _sqlConnection);
                cmd.ExecuteNonQuery();
                _sqlConnection.Close();
                return true;
            }
            catch(Exception Ex)
            {
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }



    }
}
