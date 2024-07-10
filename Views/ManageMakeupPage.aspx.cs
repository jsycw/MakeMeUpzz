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
    public partial class ManageMakeupPage : System.Web.UI.Page
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

                refreshMakeupGV();
                refreshMakeupTypeGV();
                refreshMakeupBrandGV();
            }
        }

        public void refreshMakeupGV()
        {
            List<Makeup> mu = makeupController.GetAllMakeup();
            Makeup.DataSource = mu;
            Makeup.DataBind();
        }

        public void refreshMakeupTypeGV()
        {
            List<MakeupType> makeupTypes = makeupController.GetAllTypes();
            MakeupTypes.DataSource = makeupTypes;
            MakeupTypes.DataBind();
        }

        public void refreshMakeupBrandGV()
        {
            List<MakeupBrand> makeupBrands = makeupController.GetAllBrandsDesc();
            MakeupBrands.DataSource = makeupBrands;
            MakeupBrands.DataBind();
        }

        protected void InsertMakeup_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupPage.aspx");
        }

        protected void InsertMakeupType_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupTypePage.aspx");
        }

        protected void InsertMakeupBrand_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupBrandPage.aspx");
        }

        protected void Makeup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = Makeup.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateMakeupPage.aspx?id=" + id);
        }

        protected void Makeup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = Makeup.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            makeupController.removeMakeups(id);

            refreshMakeupGV();
        }

        protected void MakeupTypes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupTypes.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            makeupController.removeMakeupType(id);
            
            refreshMakeupTypeGV();
            refreshMakeupGV();
        }

        protected void MakeupTypes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupTypes.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateMakeupTypePage.aspx?id=" + id);
        }

        protected void MakeupBrands_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupBrands.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateMakeupBrandPage.aspx?id=" + id);
        }

        protected void MakeupBrands_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupBrands.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            makeupController.removeMakeupBrand(id);

            refreshMakeupBrandGV();
            refreshMakeupGV();
        }
    }
}