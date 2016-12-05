using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab5
{
    public partial class BasePage : System.Web.UI.Page {

        protected Customer customer;

        protected void cmdSignOut_Click(Object sender, EventArgs e) {
            Helpers.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        // Check to see if both Cookies are set, if they aren't return them to the login page
        // create the customer object based on cookie value
        protected void Page_Load(object sender, EventArgs e) {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) {
                Helpers.SignOut();
                Response.Redirect("~/Login.aspx");
                return;
            }
            if (HttpContext.Current.Request.Cookies[Login.AuthCookieName] == null) {
                Helpers.SignOut();
                Response.Redirect("~/Login.aspx");
                return;
            }
            customer = Customer.GetByCookie(HttpContext.Current.Request.Cookies[Login.AuthCookieName].Value);

            // If customer has session cookie, but no data in DB boot them 
            if(customer == null) {
                Response.Redirect("~/Login.aspx");
                return;
            }
        }
    }
}