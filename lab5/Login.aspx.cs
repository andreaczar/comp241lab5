using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Security;

namespace lab5 {
    public partial class Login : System.Web.UI.Page {

        public bool InvalidLogin = false;
        public Customer RequestCustomer;

        protected void Page_Load(object sender, EventArgs e) {

            if (HttpContext.Current.User.Identity.IsAuthenticated) {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void ValidateUser(object sender, EventArgs e) {
            
            // validate form input
            if (Username.Text.Length > 16 || Username.Text.Length == 0) {
                InvalidLogin = true;
                Response.End();
            }

            if (Request.Cookies[AuthManager.AuthCookieName] != null && HttpContext.Current.User.Identity.IsAuthenticated) {
                // redirect to default page, user already logged into
                Response.Redirect("~/Default.aspx", true);
            }
              
            Customer customer = AuthManager.Authenticate(Username.Text, Password.Text);

            if (customer == null) {
                InvalidLogin = true;
                Response.End();
            }
            
            // Perform customer login
            AuthManager.Login(Request, Response, customer, RememberMe.Checked);

        }
    }
}