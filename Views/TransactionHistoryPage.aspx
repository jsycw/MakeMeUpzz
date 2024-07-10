<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="MakeMeUpzz.Views.TransactionHistoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction History Page</h1>
    <hr />
    <asp:GridView ID="TransactionGV" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="TransactionGV_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID"></asp:BoundField>
            <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID"></asp:BoundField>
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate"></asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
            <asp:ButtonField CommandName="Select" Text="Detail" ButtonType="Button"></asp:ButtonField>
        </Columns>
    </asp:GridView>

</asp:Content>
