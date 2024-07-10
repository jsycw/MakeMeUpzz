<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="MakeMeUpzz.Views.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Profile</h1>
    <hr />
    <div>
        <asp:Label ID="UsernameLabel" runat="server" Text="Username "></asp:Label>
        <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="EmailLabel" runat="server" Text="Email "></asp:Label>
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="GenderLabel" runat="server" Text="Gender "></asp:Label>
        <asp:RadioButtonList ID="GenderRadioButtonList" runat="server">
            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div>
        <asp:Label ID="DOBLabel" runat="server" Text="Date of Birth"></asp:Label>
        <asp:Calendar ID="DOBCalendar" runat="server" OnSelectionChanged="DOBCalendar_SelectionChanged"></asp:Calendar>
        <asp:TextBox ID="DOBTextBox" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="ErrorUpdateLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Button ID="UpdateButton" runat="server" Text="Update Profile" OnClick="UpdateButton_Click" />
    </div>
    <div>
        <asp:Label ID="PasswordLabel" runat="server" Text="Password "></asp:Label>
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="NewPasswordLabel" runat="server" Text="New Password "></asp:Label>
        <asp:TextBox ID="NewPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="ConfirmLabel" runat="server" Text="Confirm New Password "></asp:Label>
        <asp:TextBox ID="ConfirmTextBox" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="ErrorPassLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Button ID="ChangePass" runat="server" Text="Change Password" OnClick="ChangePass_Click" />
    </div>
</asp:Content>
