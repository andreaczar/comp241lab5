using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace lab5 {
    public class Customer {

        private const string sessionChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public bool IsCached { get; set; } = false;

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public int Customerid { get; private set; }
        public bool Exists { get; private set; }

        public string Cookie { get; private set; }

        public Customer(string cookie) {
            Cookie = cookie;

            InitializeCustomer();
        }

        public Customer(string first, string last) {
            Firstname = first;
            Lastname = last;
        }

        private void InitializeCustomer() {
            SqlConnection conn = DatabaseHelper.GetConnection();

            using (conn) {

                SqlCommand command = new SqlCommand(
                    "SELECT * " +
                    "FROM sessions " +
                    "INNER JOIN customers ON customers.customerid = sessions.customerid " +
                    "WHERE cookie = @COOKIE;", conn);

                command.Parameters.Add("@COOKIE", SqlDbType.VarChar).Value = Cookie;

                //try {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    Exists = true;

                    Firstname = Convert.ToString(reader["firstname"]);
                    Lastname = Convert.ToString(reader["lastname"]);
                    Customerid = Convert.ToInt32(reader["customerid"]);

                } else {
                    Exists = false;
                }

                //} catch (Exception bigbadaboom) {

                //}
            }
        }

        public static string GenerateSessionKey() {
            Random random = new Random();
            return new string(Enumerable.Repeat(Customer.sessionChars, 32)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static Customer GetById(int id) {
            SqlConnection conn = DatabaseHelper.GetConnection();
            SqlCommand command = new SqlCommand(
                   "SELECT * " +
                   "FROM customers " +
                   "WHERE customerid = @ID;", conn);

            command.Parameters.AddWithValue("@ID", id);

            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read()) {
                return new Customer(
                    Convert.ToString(reader["firstname"]),
                    Convert.ToString(reader["lastname"])
                );

            } else {
                return null;
            }

        }

        public static Customer GetByCookie(string sessionId) {

            Customer c = GetFromCache(sessionId);
            if (c != null) {
                c.IsCached = true;
                return c;
            }

            SqlConnection conn = DatabaseHelper.GetConnection();
            using (conn) {
                SqlCommand command = new SqlCommand(
                    "SELECT * " +
                    "FROM sessions " +
                    "INNER JOIN customers ON customers.customerid = sessions.customerid " +
                    "WHERE cookie = @COOKIE;", conn);

                command.Parameters.Add("@COOKIE", SqlDbType.VarChar).Value = sessionId;

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    c = new Customer(
                        Convert.ToString(reader["firstname"]),
                        Convert.ToString(reader["lastname"])
                    );

                    HttpContext.Current.Cache.Insert(sessionId, c, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero); // cache for 30s

                    return c;

                } else {
                    return null;
                }
            }
        }
        public static Customer GetFromCache(string sessionId) {
            return (Customer)HttpContext.Current.Cache.Get(sessionId);
        }
    }
}