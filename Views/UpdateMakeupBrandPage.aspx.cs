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
    public partial class UpdateMakeupBrandPage : System.Web.UI.Page
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

                int id = Convert.ToInt32(Request.QueryString["id"]);
                MakeupBrand makeupbr = makeupController.getMakeupBrandById(id);

                nameinput.Text = makeupbr.MakeupBrandName;
                ratinginput.Text = makeupbr.MakeupBrandRating.ToString();
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }

        protected void Update_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Request.QueryString["id"]);
            String name = nameinput.Text;
            int rating = Convert.ToInt32(ratinginput.Text);

            MakeupBrand makeupbr = makeupController.getMakeupBrandById(id);

            if (makeupController.validateName(name) && makeupController.validateRate(rating))
            {
                makeupController.updateMakeupBrand(id, name, rating);

                Label.Text = "Data Updated Successfully";
                Label.Visible = true;

                nameinput.Text = makeupbr.MakeupBrandName;
                ratinginput.Text = makeupbr.MakeupBrandRating.ToString();

            }
            else
            {
                Label.Text = "Try again!";
                Label.Visible = true;
            }
        }
    }
}