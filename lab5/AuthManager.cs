using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace lab5 {
    public class AuthManager {

        public static string AuthCookieName = "login";

        public static Customer Authenticate(string username, string password) {

            Customer authenticatedCustomer= Customer.GetByUsername(username);

            if (authenticatedCustomer == null) return authenticatedCustomer;

            if (authenticatedCustomer.CheckPassword(password)) {
                return authenticatedCustomer;
            }

            return null;
        }

        public static void Login(HttpRequest request, HttpResponse response, Customer customer, bool rememberMe = false) {
            HttpCookie userCookie = new HttpCookie(AuthManager.AuthCookieName);
            userCookie.Value = Customer.GenerateSessionKey();
            userCookie.Expires = DateTime.Now.AddDays(7.0);
            response.SetCookie(userCookie);

            // save user cookie to db
            DatabaseHelper.PersistSession(userCookie.Value, customer.Customerid);

            // persist session across browser close
            if (rememberMe) {

                int timeout = (int)TimeSpan.FromDays(7.0).TotalMinutes;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(customer.Username, rememberMe, timeout);
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                cookie.Expires = ticket.Expiration;
                HttpContext.Current.Response.Cookies.Add(cookie);
                string requestedPage = FormsAuthentication.GetRedirectUrl(customer.GetFullName(), rememberMe);
                response.Redirect(requestedPage, true);

            } else {
                string username = customer.GetFullName(); 
                FormsAuthentication.RedirectFromLoginPage(username, rememberMe);
            }
        }

        public static void Logout(HttpRequest request, HttpResponse response) {
            if (HttpContext.Current.Request.Cookies[AuthManager.AuthCookieName] != null) {

                response.Cookies[AuthManager.AuthCookieName].Expires = DateTime.Now.AddYears(-1);
                DatabaseHelper.ClearSession(request.Cookies[AuthManager.AuthCookieName].Value);
                HttpContext.Current.Cache.Remove(request.Cookies[AuthManager.AuthCookieName].Value);
            }
            FormsAuthentication.SignOut();
        }

    }
}