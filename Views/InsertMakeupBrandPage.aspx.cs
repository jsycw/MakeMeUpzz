using MakeMeUpzz.Controllers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class InsertMakeupBrandPage : System.Web.UI.Page
    {
        MakeupController makeupController = new MakeupController();

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
            }
        }
        protected void insert_Click(object sender, EventArgs e)
        {
            String name = nameinput.Text;
            int rating = Convert.ToInt32(ratinginput.Text);

            
            if (makeupController.validateName(name) && makeupController.validateRate(rating))
            {
                makeupController.addMakeupBrand(name, rating);
                Label.Text = "Data Inserted Successfully";
                Label.Visible = true;
                nameinput.Text = String.Empty;
                ratinginput.Text = String.Empty;
            }
            else
            {
                Debug.WriteLine("masuk di else");
                Label.Text = "Try again!";
                Label.Visible = true;
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }
    }
}