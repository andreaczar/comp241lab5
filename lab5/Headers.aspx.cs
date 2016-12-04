using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab5 {
    public partial class Headers : System.Web.UI.Page {

        public bool Authenticated { get; private set; }
        public static string AuthCookieName = "login";

        protected void Page_Load(object sender, EventArgs e) {
            //Iterate through HTTP headers
            // Display their keys and values
            // Headers in Request.Header property
            // Response.Write() to generate appropriate HTML 
            Authenticated = (Request.Cookies[Headers.AuthCookieName] != null);

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

            //foreach(string key in headers.AllKeys) {
            //    Response.Write("Key: " + key + "value" + headers[key]);
            //    Response.Write("<br>");
            //}

            //Response.Write("</pre>");

            //Request.Headers;
        }
        protected void LogoutUser(object sender, EventArgs e) {
            Authenticated = false;
            Helpers.SignOut();

            Response.Redirect("Login.aspx");
        }

        protected void cmdSignOut_Click(object sender, EventArgs e) {
            Helpers.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}