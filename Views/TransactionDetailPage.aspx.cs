using MakeMeUpzz.Controllers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        public TransactionHeader tran = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }

            TransactionController tranController = new TransactionController();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            tran = tranController.GetTransactionById(id);

            if (tran == null)
            {
                Response.Redirect("~Views/TransactionHistoryPage.aspx");
            }
        }
    }
}