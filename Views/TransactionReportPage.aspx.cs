using MakeMeUpzz.Controllers;
using MakeMeUpzz.Dataset;
using MakeMeUpzz.Models;
using MakeMeUpzz.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class TransactionReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else if (((User)Session["user"]).UserRole != "Admin")
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }

            TransactionController tranController = new TransactionController();
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            List<TransactionHeader> transactions = tranController.GetAllTransaction();

            MakeMeUpzzDataset data = GetData(transactions);
            report.SetDataSource(data);
        }

        private MakeMeUpzzDataset GetData(List<TransactionHeader> transactions)
        {
            MakeMeUpzzDataset data = new MakeMeUpzzDataset();
            //sesuai dengan nama tabel
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;

            foreach (var t in transactions)
            {
                int subTotal = 0;
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["User"] = t.User.Username;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["Status"] = t.Status;
                

                foreach (var d in t.TransactionDetails)
                {
                    //Diisi sesuai dengan database d. nya
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["Makeup"] = d.Makeup.MakeupName;
                    drow["Quantity"] = d.Quantity;
                    //sesuai dengan kuantitas barang yang dibeli
                    int totalPrice = d.Makeup.MakeupPrice * d.Quantity;
                    drow["Price"] = totalPrice;
               
                    subTotal += totalPrice;
                    detailTable.Rows.Add(drow);
                }

                hrow["SubTotal"] = subTotal;
                headerTable.Rows.Add(hrow);
            }

            return data;
        }
    }
}