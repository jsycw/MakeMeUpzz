using MakeMeUpzz.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        UserController userController = new UserController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        protected void RegistButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = UsernameTextBox.Text.Trim();
                string email = EmailTextBox.Text.Trim();
                DateTime dob = DOBCalendar.SelectedDate;
                string gender = GenderRadioButtonList.SelectedValue;
                string password = PasswordTextBox.Text;
                string confirm = ConfirmTextBox.Text;

                string errorMessage;
                if (userController.RegisterUser(username, email, dob, gender, password, confirm, out errorMessage))
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
                else
                {
                    ErrorMessageLabel.Text = errorMessage;
                }
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = "Error: " + ex.Message;
            }
        }

        protected void DOBCalendar_SelectionChanged(object sender, EventArgs e)
        {
            DOBTextBox.Text = DOBCalendar.SelectedDate.ToString("dd MMMM yyyy");
        }

        protected void loginRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}