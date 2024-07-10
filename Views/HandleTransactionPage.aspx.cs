using MakeMeUpzz.Controllers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class HandleTransactionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
                else if (((User)Session["user"]).UserRole != "Admin")
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }

                TransactionController tranController = new TransactionController();
                List<TransactionHeader> unhandledTran = tranController.GetAllUnhandledTransaction();
                TransactionGV.DataSource = unhandledTran;
                TransactionGV.DataBind();
            }
        }

        protected void TransactionGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = TransactionGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);

            TransactionController tranController = new TransactionController();
            tranController.UpdateTransactionStatusById(id);

            List<TransactionHeader> unhandledTran = tranController.GetAllUnhandledTransaction();
            TransactionGV.DataSource = unhandledTran;
            TransactionGV.DataBind();
        }
    }
}