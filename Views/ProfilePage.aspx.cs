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
    public partial class ProfilePage : System.Web.UI.Page
    {
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
                {
                    User user = (User)Session["user"];
                    UsernameTextBox.Text = user.Username;
                    EmailTextBox.Text = user.UserEmail;
                    GenderRadioButtonList.SelectedValue = user.UserGender;
                    DOBTextBox.Text = user.UserDOB.ToString("dd MMMM yyyy");
                    PasswordTextBox.Text = user.UserPassword;
                    ConfirmTextBox.Text = user.UserPassword;
                }
                else
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                user.Username = UsernameTextBox.Text;
                user.UserEmail = EmailTextBox.Text;
                user.UserGender = GenderRadioButtonList.SelectedValue;
                user.UserDOB = DateTime.Parse(DOBTextBox.Text);
                string error;

                if (userController.UpdateUser(user, out error))
                {
                    Session["user"] = user;
                    ErrorUpdateLabel.Text = "Profile updated successfully!";
                    ErrorUpdateLabel.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    ErrorUpdateLabel.Text = error;
                    ErrorUpdateLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void ChangePass_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                string Pass = PasswordTextBox.Text;
                string newPass = NewPasswordTextBox.Text;
                string confirmPass = ConfirmTextBox.Text;

                if (user.UserPassword == Pass)
                {
                    string error;

                    if (userController.UpdatePassword(user, newPass, confirmPass, out error))
                    {
                        Session["user"] = user;
                        ErrorPassLabel.Text = "Password updated successfully!";
                        ErrorPassLabel.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        ErrorPassLabel.Text = error;
                        ErrorPassLabel.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    ErrorPassLabel.Text = "Old password is incorrect.";
                    ErrorPassLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void DOBCalendar_SelectionChanged(object sender, EventArgs e)
        {
            DOBTextBox.Text = DOBCalendar.SelectedDate.ToString("dd MMMM yyyy");
        }
    }
}