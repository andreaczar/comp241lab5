using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab5 {
    public partial class Login : System.Web.UI.Page {

        public static string AuthCookieName = "login";

        public bool Authenticated { get; private set; }

        protected void Page_Load(object sender, EventArgs e) {
            Authenticated = (Request.Cookies[Login.AuthCookieName] != null);

        }

        protected void ValidateUser(object sender, EventArgs e) {
            // do user form validation
            Authenticated = false;

            if(Username.Text.Length > 16 || Username.Text.Length == 0) {
                //throw an error
                return;
            }

            if (Request.Cookies[Login.AuthCookieName] == null) {

                HttpCookie userCookie = new HttpCookie(Login.AuthCookieName);
                userCookie.Value = EncodeUsername(Username.Text);
                userCookie.Expires = DateTime.Now.AddDays(7.0);
                Response.SetCookie(userCookie);
                Authenticated = true;

            } else {
                Authenticated = true;
            }
            
            
        }

        protected void LogoutUser(object sender, EventArgs e) {
            Authenticated = false;
            if(Request.Cookies[Login.AuthCookieName] != null) {

                Response.Cookies[Login.AuthCookieName].Expires = DateTime.Now.AddYears(-1);
            }

            Response.Redirect("Login.aspx");
        }

        private string EncodeUsername(string username) {
            username = username.ToLower();

            var bytes = System.Text.Encoding.UTF8.GetBytes(username);

            return Convert.ToBase64String(bytes);
        }

        private string DecodeUsername(string base64Username) {
            var bytes = Convert.FromBase64String(base64Username);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
    }
}