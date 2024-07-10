<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="MakeMeUpzz.Views.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction Detail</h1>
    <h3>Transaction ID: <%= tran.TransactionID %></h3>
    <table style="width: 700px; text-align: center;" border="1">
        <tr>
            <th>Makeup</th>
            <th>Makeup Type</th>
            <th>Makeup Brand</th>
            <th>Quantity</th>
            <th>Subtotal</th>
        </tr>
        <%foreach (var detail in tran.TransactionDetails)
            { %>
        <tr>
            <td><%= detail.Makeup.MakeupName %></td>
            <td><%= detail.Makeup.MakeupType.MakeupTypeName %></td>
            <td><%= detail.Makeup.MakeupBrand.MakeupBrandName %></td>
            <td><%= detail.Quantity %></td>
            <td><%= detail.Quantity * detail.Makeup.MakeupPrice %></td>
        </tr>
        <% } %>
        <tr>
            <td colspan="3">Total</td>
            <td><%= tran.TransactionDetails.Sum(detail => detail.Quantity) %></td>
            <td><%= tran.TransactionDetails.Sum(detail => detail.Quantity * detail.Makeup.MakeupPrice) %></td>
        </tr>
    </table>

</asp:Content>
