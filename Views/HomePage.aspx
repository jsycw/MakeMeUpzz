<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MakeMeUpzz.Views.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home</h1>
    <hr />

    <div>
        <asp:Label ID="RoleLbl" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="UsernameLbl" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <div>
        <asp:GridView ID="CustomersGridView" runat="server">
            <Columns>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
