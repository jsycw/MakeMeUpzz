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
    public partial class TransactionHistoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                User currUser = null;

                if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
                else
                {
                    if (Session["user"] == null)
                    {
                        UserController userController = new UserController();

                        int id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                        currUser = userController.GetUserById(id);

                        Session["user"] = currUser;
                    }
                    else
                    {
                        currUser = (User)Session["user"];
                    }

                    TransactionController tranController = new TransactionController();
                    List<TransactionHeader> tran;

                    if (currUser.UserRole == "Admin")
                    {
                        tran = tranController.GetAllTransaction();

                    }
                    else
                    {
                        tran = tranController.GetUserTransaction(currUser);
                    }

                    TransactionGV.DataSource = tran;
                    TransactionGV.DataBind();
                }

            }

        }

        protected void TransactionGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = TransactionGV.SelectedRow;
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/TransactionDetailPage.aspx?id=" + id);
        }
    }
}