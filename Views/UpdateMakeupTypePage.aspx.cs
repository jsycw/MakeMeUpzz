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
    public partial class UpdateMakeupTypePage : System.Web.UI.Page
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
                MakeupType makeupType = makeupController.GetMakeupTypeByID(id);

                nameinput.Text = makeupType.MakeupTypeName;
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

            MakeupType makeupType = makeupController.GetMakeupTypeByID(id);

            if (makeupController.validateName(name))
            {
                makeupController.updateMakeupType(id, name);

                Label.Text = "Data Updated Successfully";
                Label.Visible = true;

                nameinput.Text = makeupType.MakeupTypeName;

            }
            else
            {
                Label.Text = "Try again!";
                Label.Visible = true;
            }
        }
    }
}