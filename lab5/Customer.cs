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
        public string Username { get; private set; }
        public int Customerid { get; private set; }
        public bool Exists { get; private set; }
        private string Password;

        public string Cookie { get; private set; }

        public Customer(string cookie) {
            Cookie = cookie;

            InitializeCustomer();
        }

        public Customer(string first, string last) {
            Firstname = first;
            Lastname = last;
        }

        public Customer(int id, string username, string first, string last, string password) {
            Customerid = id;
            Username = username;
            Firstname = first;
            Lastname = last;
            Password = password;
        }

        public string GetFullName() {
            if((Firstname == null || Firstname == "") && (Lastname == null || Lastname == "")) {
                return "Anonymous";
            }
            return Firstname + " " + Lastname;
        }

        public bool CheckPassword(string password) {
            return password == Password;
        }

        private void InitializeCustomer() {
            string query = "SELECT * FROM sessions " +
                            "INNER JOIN customers ON customers.customerid = sessions.customerid " +
                            "WHERE cookie = @COOKIE;";

            SqlConnection conn = DatabaseHelper.GetConnection();

            try {
                using (conn) {
                    using (SqlCommand command = new SqlCommand(query, conn)) {
                        command.Parameters.Add("@COOKIE", SqlDbType.VarChar).Value = Cookie;
                        conn.Open();

                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                Exists = true;

                                Firstname = Convert.ToString(reader["firstname"]);
                                Lastname = Convert.ToString(reader["lastname"]);
                                Customerid = Convert.ToInt32(reader["customerid"]);

                            } else {
                                Exists = false;
                            }
                        }
                    }
                }
            } catch (Exception ex) {

            }
        }

        public static string GenerateSessionKey() {
            Random random = new Random();
            return new string(Enumerable.Repeat(Customer.sessionChars, 32)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static Customer GetById(int id) {
            string query = "SELECT * FROM customers WHERE customerid = @ID;";
            Customer c = null;
            SqlConnection conn = DatabaseHelper.GetConnection();

            try {
                using (conn) {
                    using (SqlCommand command = new SqlCommand(query, conn)) {
                        command.Parameters.AddWithValue("@ID", id);
                        conn.Open();

                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                c = ConstructCustomerFromReader(reader);
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                HttpContext.Current.Response.Write("Whoopsies! An error occurred." + ex);
                HttpContext.Current.Response.End();
            }

            return c;
        }

        public static Customer GetByUsername(string username) {
            SqlConnection conn = DatabaseHelper.GetConnection();
            Customer c = null;
            string query = "SELECT * FROM customers WHERE username = @USERNAME;";

            try {
                using (conn) {
                    using (SqlCommand command = new SqlCommand(query, conn)) {
                        command.Parameters.AddWithValue("@USERNAME", username);
                        conn.Open();

                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                c = ConstructCustomerFromReader(reader);
                            }
                        }
                    }
                }
            } catch(Exception ex) {
                HttpContext.Current.Response.Write("Whoopsies! An error occurred." + ex);
                HttpContext.Current.Response.End();
            }

            return c;
        }

        public static Customer GetByCookie(string sessionId) {

            string query = "SELECT * FROM sessions " +
                            "INNER JOIN customers ON customers.customerid = sessions.customerid " +
                            "WHERE cookie = @COOKIE;";


            Customer c = GetFromCache(sessionId);
            if (c != null) {
                c.IsCached = true;
                return c;
            }

            try {
                using (SqlConnection conn = DatabaseHelper.GetConnection()) {
                    using (SqlCommand command = new SqlCommand(query, conn)) {

                        command.Parameters.Add("@COOKIE", SqlDbType.VarChar).Value = sessionId;
                        conn.Open();

                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                c = ConstructCustomerFromReader(reader);
                                HttpContext.Current.Cache.Insert(sessionId, c, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero); // cache for 30s
                            }
                        }
                    }
                }

            } catch(Exception ex) {
                HttpContext.Current.Response.Write("Whoopsies! An error occurred." + ex);
                HttpContext.Current.Response.End();
            }

            return c;
         
        }

        private static Customer ConstructCustomerFromReader(SqlDataReader reader) {
            return new Customer(
                Convert.ToInt32(reader["customerid"]),
                Convert.ToString(reader["username"]),
                Convert.ToString(reader["firstname"]),
                Convert.ToString(reader["lastname"]),
                Convert.ToString(reader["password"])
            );
        }

        public static Customer GetFromCache(string sessionId) {
            return (Customer)HttpContext.Current.Cache.Get(sessionId);
        }
    }
}