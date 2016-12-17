using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace lab5 {
    /*
     * Queries DB for session information
     */ 
    public class DatabaseHelper {

        public static SqlConnection GetConnection() {
            string connectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        public static void ClearSession(string sessionId) {
            string query = "DELETE FROM sessions WHERE cookie = @cookie;";

            try {
                using (SqlConnection conn = DatabaseHelper.GetConnection()) {
                    using (SqlCommand command = new SqlCommand(query, conn)) {
                        command.Parameters.Add("@cookie", SqlDbType.VarChar, 50).Value = sessionId;
                        conn.Open();

                        command.ExecuteNonQuery();
                    }
                }
            } catch (Exception bigbadaboom) {
                HttpContext.Current.Response.Write("Error clearing session: " + bigbadaboom);
                HttpContext.Current.Response.End();
            }
        }

        public static void PersistSession(string sessionId, int customerid) {
            string query = "INSERT INTO sessions (customerid, cookie) VALUES (@customerid, @cookie);";

            try {
                using (SqlConnection conn = DatabaseHelper.GetConnection()) {
                    using (SqlCommand command = new SqlCommand(query, conn)) {
                        command.Parameters.Add("@customerid", SqlDbType.Int).Value = customerid;
                        command.Parameters.Add("@cookie", SqlDbType.Text, 50).Value = sessionId;

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            } catch (Exception bigbadaboom) {
                HttpContext.Current.Response.Write(bigbadaboom);
                HttpContext.Current.Response.End();
            }
        }
    }
}