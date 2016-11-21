using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace lab5 {

   

    public partial class Login : System.Web.UI.Page {

        public static string AuthCookieName = "login";

        public bool Authenticated { get; private set; }
        public bool InvalidLogin = false;
        public Customer RequestCustomer;

        protected void Page_Load(object sender, EventArgs e) {
            if(Request.Cookies[Login.AuthCookieName] != null) {
                RequestCustomer = new Customer(Request.Cookies[Login.AuthCookieName].Value);
                Authenticated = RequestCustomer.Exists;
            } else {
                Authenticated = false;
            }
            
        }

        protected void ValidateUser(object sender, EventArgs e) {
            // do user form validation
            Authenticated = false;


            if (Username.Text.Length > 16 || Username.Text.Length == 0) {
                //throw an error
                return;
            }
            // no session cookie exists
            if (Request.Cookies[Login.AuthCookieName] == null) {

                //check username/password
                // if valid username/password combo, create a session and set cookie.

                int customerId = DatabaseHelper.Authenticate(Username.Text, Password.Text);
                if (customerId != 0) {

                    HttpCookie userCookie = new HttpCookie(Login.AuthCookieName);
                    userCookie.Value = Customer.GenerateSessionKey();
                    userCookie.Expires = DateTime.Now.AddDays(7.0);
                    Response.SetCookie(userCookie);
                    Authenticated = true;

                    try {
                        DatabaseHelper.PersistSession(userCookie.Value, customerId);
                    } catch( Exception ex) {
                        Response.Write(ex);
                    }
                    

                    Response.Redirect("Login.aspx");
                    return;

                } else {
                    InvalidLogin = true;
                }


            // session cookie exists, should check it.
            } else {
                Authenticated = true;
            }

        }



        protected void LogoutUser(object sender, EventArgs e) {
            Authenticated = false;
            if (Request.Cookies[Login.AuthCookieName] != null) {

                Response.Cookies[Login.AuthCookieName].Expires = DateTime.Now.AddYears(-1);
                DatabaseHelper.ClearSession(Request.Cookies[Login.AuthCookieName].Value);
            }

            Response.Redirect("Login.aspx");
        }
    }
}