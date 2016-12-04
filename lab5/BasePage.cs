using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab5
{
    public partial class BasePage : System.Web.UI.Page {
        protected void cmdSignOut_Click(Object sender, EventArgs e) {
            Helpers.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}