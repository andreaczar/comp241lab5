using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace lab5 {
    public class Sales {
        public int StoreId { get; private set; }
        public string OrderNumber { get; private set; }
        public DateTime OrderDate { get; private set; }
        public int Quantity { get; private set; }
        public string Payterms { get; private set; }
        public string TitleId { get; private set; }

        public Sales(int storeId, string orderNumber, DateTime orderDate, int quantity, string payterms, string titleId) {
            StoreId = storeId;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Quantity = quantity;
            Payterms = payterms;
            TitleId = titleId;
        }

        public static List<Sales> GetAll() {
            List<Sales> sales = new List<Sales>();

            SqlConnection conn = DatabaseHelper.GetConnection();
            SqlCommand command = new SqlCommand(
                   "SELECT * " +
                   "FROM sales;", conn);

            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                Sales sale = new Sales(
                    Convert.ToInt32(reader["stor_id"]),
                    Convert.ToString(reader["ord_num"]),
                    Convert.ToDateTime(reader["ord_date"]),
                    Convert.ToInt32(reader["qty"]),
                    Convert.ToString(reader["payterms"]),
                    Convert.ToString(reader["title_id"])    
                );
                sales.Add(sale);
            }
            reader.Close();
            conn.Close();
            
            return sales;
        }
    }
}