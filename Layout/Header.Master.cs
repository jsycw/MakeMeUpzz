using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Layout
{
    public partial class Header : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetButton(false);

                if (Session["user"] != null)
                {
                    User user = (User)Session["user"];
                    if (user.UserRole == "User")
                    {
                        UserButton();
                    }
                    else if (user.UserRole == "Admin")
                    {
                        AdminButton();
                    }
                }
                else
                {
                    GuestButton();
                }
            }
        }

        private void SetButton(bool isVisible)
        {
            LoginBtn.Visible = isVisible;
            RegisterBtn.Visible = isVisible;
            HomeBtn.Visible = isVisible;
            OrderMakeupBtn.Visible = isVisible;
            ProfileBtn.Visible = isVisible;
            TransactionHistoryBtn.Visible = isVisible;
            ManageMakeupBtn.Visible = isVisible;
            HandleTransactionBtn.Visible = isVisible;
            ViewReportBtn.Visible = isVisible;
            LogoutBtn.Visible = isVisible;
        }

        private void GuestButton()
        {
            LoginBtn.Visible = true;
            RegisterBtn.Visible = true;
        }

        private void UserButton()
        {
            HomeBtn.Visible = true;
            OrderMakeupBtn.Visible = true;
            ProfileBtn.Visible = true;
            TransactionHistoryBtn.Visible = true;
            LogoutBtn.Visible = true;
        }

        private void AdminButton()
        {
            HomeBtn.Visible = true;
            ManageMakeupBtn.Visible = true;
            HandleTransactionBtn.Visible = true;
            TransactionHistoryBtn.Visible = true;
            ProfileBtn.Visible = true;
            ViewReportBtn.Visible = true;
            LogoutBtn.Visible = true;
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }

        protected void HomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void OrderMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/OrderMakeupPage.aspx");
        }

        protected void ProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }

        protected void TransactionHistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistoryPage.aspx");
        }

        protected void ManageMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }

        protected void HandleTransactionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HandleTransactionPage.aspx");
        }

        protected void ViewReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionReportPage.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            if (Request.Cookies["user_cookie"] != null)
            {
                Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        
    }
}