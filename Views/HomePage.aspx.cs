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
    public partial class HomePage : System.Web.UI.Page
    {
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    User user = (User)Session["user"];
                    DisplayUserData(user);
                }
            }
        }

        protected void DisplayUserData(User user)
        {
            RoleLbl.Text = "Role: " + user.UserRole;
            UsernameLbl.Text = "Name: " + user.Username;

            if (user.UserRole == "Admin")
            {
                DisplayCustomerData();
            }
        }

        protected void DisplayCustomerData()
        {
            CustomersGridView.DataSource = userController.GetAllCustomers();
            CustomersGridView.DataBind();
        }
    }
}