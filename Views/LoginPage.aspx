<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MakeMeUpzz.Views.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Login</h1>
    <hr />

    <div>
        <asp:Label ID="UsernameLabel" runat="server" Text="Username "></asp:Label>
        <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="PassLabel" runat="server" Text="Password "></asp:Label>
        <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:CheckBox ID="RememberCheckBox" runat="server" Text="Remember Me" />
    </div>
    <div>
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
    </div>
    <div>
        <asp:Label ID="ErrorLabel" runat="server" Visible="false" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:LinkButton ID="registerRedirect" runat="server" OnClick="registerRedirect_Click" Text="Don't have an account? Register here!" />
    </div>

</asp:Content>
