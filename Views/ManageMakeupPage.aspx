<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="ManageMakeupPage.aspx.cs" Inherits="MakeMeUpzz.Views.ManageMakeupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="margin-bottom: 5px;">Makeup</h1>
     <h5 style="color:red; margin:0px;margin-bottom:5px">Deleting a makeup will also remove all related makeup items from shopping carts and transaction details</h5>

    <asp:GridView ID="Makeup" runat="server" AutoGenerateColumns="False" OnRowEditing="Makeup_RowEditing" OnRowDeleting="Makeup_RowDeleting">
        <Columns>
            <asp:BoundField DataField="MakeupID" HeaderText="Makeup ID" SortExpression="MakeupID" />
            <asp:BoundField DataField="MakeupName" HeaderText="MakeupName" SortExpression="MakeupName" />
            <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight" SortExpression="MakeupWeight" />
            <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price" SortExpression="MakeupPrice" />
            <asp:BoundField DataField="MakeupTypeID" HeaderText="Makeup Type ID" SortExpression="MakeupTypeID" />
            <asp:BoundField DataField="MakeupBrandID" HeaderText="Makeup Brand ID" SortExpression="MakeupBrandID" />
            <asp:CommandField ButtonType="Button" HeaderText="Update" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>

    <h1 style="margin-bottom: 5px;">Makeup Types</h1>
    <h5 style="color:red; margin:0px;margin-bottom:5px">Deleting a makeup type will also remove all related makeup items from the brand, shopping carts, and transaction details</h5>

    <asp:GridView ID="MakeupTypes" runat="server" AutoGenerateColumns="False" OnRowDeleting="MakeupTypes_RowDeleting" OnRowEditing="MakeupTypes_RowEditing">
        <Columns>
            <asp:BoundField DataField="MakeupTypeID" HeaderText="Makeup Type ID" SortExpression="MakeupTypeID" />
            <asp:BoundField DataField="MakeupTypeName" HeaderText="Makeup Type Name" SortExpression="MakeupTypeName" />
            <asp:CommandField ButtonType="Button" HeaderText="Update" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>

    <br />
    <h1 style="margin-bottom: 5px;">Makeup Brand</h1>
    <h5 style="color:red; margin:0px;margin-bottom:5px">Deleting a makeup brand will also remove all related makeup items from the brand, shopping carts, and transaction details</h5>

    <asp:GridView ID="MakeupBrands" runat="server" AutoGenerateColumns="False" OnRowEditing="MakeupBrands_RowEditing" OnRowDeleting="MakeupBrands_RowDeleting">
        <Columns>
            <asp:BoundField DataField="MakeupBrandID" HeaderText="Makeup Brand ID" SortExpression="MakeupBrandID" />
            <asp:BoundField DataField="MakeupBrandName" HeaderText="Makeup Brand Name" SortExpression="MakeupBrandName" />
            <asp:BoundField DataField="MakeupBrandRating" HeaderText="Makeup Brand Rating" SortExpression="MakeupBrandRating" />
            <asp:CommandField ButtonType="Button" HeaderText="Update" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>

    <br />

    <asp:Button ID="InsertMakeup" runat="server" Text="Insert Makeup" OnClick="InsertMakeup_Click" />
    <asp:Button ID="InsertMakeupType" runat="server" Text="Insert Makeup Type" OnClick="InsertMakeupType_Click" />
    <asp:Button ID="InsertMakeupBrand" runat="server" Text="Insert Makeup Brand" OnClick="InsertMakeupBrand_Click" />
</asp:Content>
