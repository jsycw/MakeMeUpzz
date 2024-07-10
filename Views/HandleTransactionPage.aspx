<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="HandleTransactionPage.aspx.cs" Inherits="MakeMeUpzz.Views.HandleTransactionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Handle Transaction</h1>
    <asp:GridView ID="TransactionGV" runat="server" AutoGenerateColumns="false" OnRowUpdating="TransactionGV_RowUpdating">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID"></asp:BoundField>
            <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID"></asp:BoundField>
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate"></asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
            <asp:ButtonField CommandName="Update" Text="Handle" ButtonType="Button"></asp:ButtonField>
        </Columns>

    </asp:GridView>
</asp:Content>
