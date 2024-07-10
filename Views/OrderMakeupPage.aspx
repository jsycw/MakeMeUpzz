<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="OrderMakeupPage.aspx.cs" Inherits="MakeMeUpzz.Views.OrderMakeupPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Order Makeup</h1>
    <hr />

    <asp:GridView ID="MakeupGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="MakeupGridView_RowCommand" DataKeyNames="MakeupID">
        <Columns>
            <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupID" />
            <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName" />
            <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
            <asp:BoundField DataField="MakeupWeight" HeaderText="Weight (grams)" SortExpression="MakeupWeight" />
            <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Type" SortExpression="MakeupType.MakeupTypeName" />
            <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand" SortExpression="MakeupBrand.MakeupBrandName" />
            <asp:TemplateField HeaderText="Input Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="QuantityTextBox" runat="server" TextMode="Number"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="AddToCartButton" runat="server" CommandName="add_to_cart" CommandArgument='<%# Container.DataItemIndex %>' Text="Add to cart" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>

    <br />
    <h3>Cart</h3>

    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Makeup.MakeupName" HeaderText="Makeup Name" SortExpression="MakeupName" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" Visible="false" OnClick="CheckoutBtn_Click"/>
    <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" Visible="false" OnClick="ClearCartBtn_Click" />
</asp:Content>
