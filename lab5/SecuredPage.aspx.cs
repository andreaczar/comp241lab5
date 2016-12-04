using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab5 {
    public partial class SecuredPage : BasePage {
        protected void Page_Load(object sender, EventArgs e) {
            lblMessage.Text = "You have reached the secured page, ";
            lblMessage.Text += User.Identity.Name + ".";

            TableRow headers = SalesTable.Rows[0];

            SalesTable.Rows.Clear();
            SalesTable.Rows.Add(headers);

            List<Sales> sales = Sales.GetAll();

            foreach (Sales sale in sales) {
                TableRow r = new TableRow();

                TableCell storeid = new TableCell();
                storeid.Controls.Add(new LiteralControl(String.Format("{0}", sale.StoreId)));
                r.Cells.Add(storeid);

                TableCell order = new TableCell();
                order.Controls.Add(new LiteralControl(String.Format("{0}", sale.OrderNumber)));
                r.Cells.Add(order);

                TableCell orderDate = new TableCell();
                orderDate.Controls.Add(new LiteralControl(String.Format("{0}", sale.OrderDate)));
                r.Cells.Add(orderDate);

                TableCell quantity = new TableCell();
                quantity.Controls.Add(new LiteralControl(String.Format("{0}", sale.Quantity)));
                r.Cells.Add(quantity);

                TableCell payterms = new TableCell();
                payterms.Controls.Add(new LiteralControl(String.Format("{0}", sale.Payterms)));
                r.Cells.Add(payterms);

                TableCell titleId = new TableCell();
                titleId.Controls.Add(new LiteralControl(String.Format("{0}", sale.TitleId)));
                r.Cells.Add(titleId);

                SalesTable.Rows.Add(r);

            }

        }
    }
}