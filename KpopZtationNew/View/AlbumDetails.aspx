<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="AlbumDetails.aspx.cs" Inherits="KpopZtationNew.View.AlbumDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="albumDetailsContainer">
        <h1><asp:Label ID="albumNameLabel" runat="server"></asp:Label></h1>
        <p>Price: $<asp:Label ID="albumPriceLabel" runat="server"></asp:Label></p>
        <p>Desc: <asp:Label ID="albumDescLabel" runat="server"></asp:Label></p>
        <p>Stock: <asp:Label ID="albumStockLabel" runat="server"></asp:Label></p>
    </div>

    <div class="quantityContainer">
        <label for="quantityInput">Quantity:</label>
        <input type="number" id="quantityInput" runat="server" min="1" value="1" />
    </div>

    <asp:Button runat="server" ID="addToCartBtn" Text="Add to Cart" CssClass="btn btn-primary" OnClick="addToCartBtn_Click"/>
    <asp:Button runat="server" ID="CheckoutBtn" Text="Go to cart" CssClass="btn btn-primary" OnClick="checkoutBtn_Click" />
</asp:Content>