using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace lab5 {
    public class DatabaseHelper {

        public static SqlConnection GetConnection() {
            string connectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        public static void ClearSession(string sessionId) {
            SqlConnection conn = DatabaseHelper.GetConnection();

            using (conn) {

                SqlCommand command = new SqlCommand(
                    "DELETE FROM sessions WHERE cookie = @cookie;", conn);

                command.Parameters.Add("@cookie", SqlDbType.VarChar, 50).Value = sessionId;

                //try {
                conn.Open();
                command.ExecuteNonQuery();
                //} catch (Exception bigbadaboom) {
                //Response.Write(bigbadaboom);
                //}
            }
        }

        public static void PersistSession(string sessionId, int customerid) {

            SqlConnection conn = DatabaseHelper.GetConnection();

            using (conn) {

                SqlCommand command = new SqlCommand(
                    "INSERT INTO sessions (customerid, cookie) VALUES (@customerid, @cookie);", conn);

                command.Parameters.Add("@customerid", SqlDbType.Int).Value = customerid;
                command.Parameters.Add("@cookie", SqlDbType.Text, 50).Value = sessionId;

                //try {
                conn.Open();
                command.ExecuteNonQuery();
                //} catch (Exception bigbadaboom) {
                //Response.Write(bigbadaboom);
                //}
            }
        }

    }
}