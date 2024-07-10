<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="TransactionReportPage.aspx.cs" Inherits="MakeMeUpzz.Views.TransactionReportPage" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction Report</h1>
    <hr />
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    </div>

</asp:Content>
