<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="InsertMakeupBrandPage.aspx.cs" Inherits="MakeMeUpzz.Views.InsertMakeupBrandPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Back_Click" />
    <div>
        <asp:Label ID="Name" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="nameinput" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Rating" runat="server" Text="Rating"></asp:Label>
        <asp:TextBox ID="ratinginput" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="insert" runat="server" Text="Insert" OnClick="insert_Click" />
    <asp:Label ID="Label" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>
