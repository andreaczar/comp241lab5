using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace lab5 {
    public class Helpers {

        public static void SignOut() {

            if (HttpContext.Current.Request.Cookies[Login.AuthCookieName] != null) {

                HttpContext.Current.Response.Cookies[Login.AuthCookieName].Expires = DateTime.Now.AddYears(-1);
                DatabaseHelper.ClearSession(HttpContext.Current.Request.Cookies[Login.AuthCookieName].Value);
                HttpContext.Current.Cache.Remove(HttpContext.Current.Request.Cookies[Login.AuthCookieName].Value);
            }
            FormsAuthentication.SignOut();
        }

    }
}