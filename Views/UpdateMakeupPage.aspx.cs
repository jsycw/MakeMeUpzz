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
    public partial class UpdateMakeupPage : System.Web.UI.Page
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
                Makeup makeup = makeupController.getMakeupById(id);

                NameTB.Text = makeup.MakeupName;
                PriceTB.Text = makeup.MakeupPrice.ToString();
                WeightTB.Text = makeup.MakeupWeight.ToString();
                TypeIDTB.Text = makeup.MakeupTypeID.ToString();
                BrandIDTB.Text = makeup.MakeupBrandID.ToString();

            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }

        protected void Update_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Request.QueryString["id"]);
            String name = NameTB.Text;
            String price = PriceTB.Text;
            String weight = WeightTB.Text;
            String typeId = TypeIDTB.Text;
            String brandId = BrandIDTB.Text;

            Makeup makeup = makeupController.getMakeupById(id);

            if (makeupController.validate(name, price, weight, typeId, brandId))
            {
                int p = Convert.ToInt32(price);
                int w = Convert.ToInt32(weight);
                int typeID = Convert.ToInt32(TypeIDTB.Text);
                int brandID = Convert.ToInt32(BrandIDTB.Text);

                makeupController.updateMakeup(id, name, p, w, typeID, brandID);

                Label.Text = "Data Updated Successfully";
                Label.Visible = true;

                NameTB.Text = makeup.MakeupName;
                PriceTB.Text = makeup.MakeupPrice.ToString();
                WeightTB.Text = makeup.MakeupWeight.ToString();
                TypeIDTB.Text = makeup.MakeupTypeID.ToString();
                BrandIDTB.Text = makeup.MakeupBrandID.ToString();
            }
            else
            {
                Label.Text = "Try again!";
                Label.Visible = true;
            }
        }
    }
}