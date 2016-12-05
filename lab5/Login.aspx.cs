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

        public static string AuthCookieName = "login";

        public bool Authenticated { get; private set; }
        public bool InvalidLogin = false;
        public Customer RequestCustomer;

        protected void Page_Load(object sender, EventArgs e) {
            Authenticated = HttpContext.Current.User.Identity.IsAuthenticated;

            if (Authenticated) {
                Response.Redirect("~/Default.aspx");
            }
            //if (Request.Cookies[Login.AuthCookieName] != null && Authenticated) {
            //    RequestCustomer = new Customer(Request.Cookies[Login.AuthCookieName].Value);
            //} else {
            //    //RequestCustomer = new Customer("No", "body");
            //}

        }

        protected void ValidateUser(object sender, EventArgs e) {
            // do user form validation
            Authenticated = false;


            if (Username.Text.Length > 16 || Username.Text.Length == 0) {
                InvalidLogin = true;
            }
            // no session cookie exists
            if (Request.Cookies[Login.AuthCookieName] == null || !HttpContext.Current.User.Identity.IsAuthenticated) {

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
                    int timeout = 0;

                    if (RememberMe.Checked) {
                        timeout = (int)TimeSpan.FromDays(7).TotalMinutes;
                    }

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(Username.Text, true, timeout);
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    cookie.Expires = ticket.Expiration;
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    string requestedPage = FormsAuthentication.GetRedirectUrl(Username.Text, false);

                    Customer c = Customer.GetById(customerId);  
                    FormsAuthentication.RedirectFromLoginPage(c.Firstname + " " + c.Lastname, true);

                    //Response.Redirect(requestedPage, true);

                    return;

                } else {
                    InvalidLogin = true;
                }


            // session cookie exists, should check it.
            } else {
                Response.Redirect("~/Default.aspx");
            }
        }



        protected void LogoutUser(object sender, EventArgs e) {
            Authenticated = false;
            Helpers.SignOut();

            Response.Redirect("Login.aspx");
        }
    }
}