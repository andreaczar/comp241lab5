using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab5 {
    public partial class Headers : BasePage {

     
        public static string AuthCookieName = "login";

        protected void Page_Load(object sender, EventArgs e) {
            base.Page_Load(sender, e);

            //Iterate through HTTP headers
            // Display their keys and values
            // Headers in Request.Header property
            // Response.Write() to generate appropriate HTML 


            NameValueCollection headers = Request.Headers;

            foreach(string key in Request.Headers) {
                TableRow row = new TableRow();
                TableCell header = new TableCell();
                TableCell value = new TableCell();

                header.Text = key;
                
                value.Text = Request.Headers[key];
                value.Attributes["width"] = "50%";

                row.Cells.Add(header);
                row.Cells.Add(value);
                HeadersTable.Rows.Add(row);
            }

        }
        protected void LogoutUser(object sender, EventArgs e) {
            Helpers.SignOut();
            Response.Redirect("Login.aspx");
        }

    }
}