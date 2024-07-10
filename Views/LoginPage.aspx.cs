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
    public partial class LoginPage : System.Web.UI.Page
    {
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void registerRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PassTextBox.Text;

            User user = userController.ValidateUser(username, password);

            if (user == null)
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "Invalid username or password";
                return;
            }
            else
            {
                Session["user"] = user;

                if (RememberCheckBox.Checked)
                {
                    userController.RememberUser(user, Response);
                }

                Response.Redirect("~/Views/HomePage.aspx");
            }
        }
    }
}