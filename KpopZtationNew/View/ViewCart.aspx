<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="KpopZtationNew.View.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .artistImgContainer {
            text-align: center;
            padding: 2vh;
        }
        .artistImgContainer h1 {
            font-size: 4vh;
            margin-bottom: 2vh;
        }
        .artistImgContainer h2 {
            font-size: 3vh;
            margin-top: 2vh;
            margin-bottom: 2vh;
        }
        .artistImgContainer div {
            margin-bottom: 4vh;
        }
        .albumImg {
            width: 20vh;
            height: 20vh;
            cursor: pointer;
        }
        .albumImgContainer {
            display: flex;
            justify-content: center;
            align-items: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="cartsRepeater" runat="server">
        <ItemTemplate>
            <div class="albumImgContainer">
                <img class="albumImg" src='<%# ResolveUrl("../Assets/Albums/" + Eval("AlbumPic")) %>' data-image-id='<%# Eval("AlbumID") %>' />
            </div>
            <div>
                <h3><%# Eval("AlbumName") %></h3>
                <p>Price: <%# Eval("Price") %></p>
                <p>Quantity: <%# Eval("Quantity") %></p>
                <asp:Button runat="server" ID="btnRemove" CommandArgument='<%# Eval("AlbumID") %>' Text="Remove" CssClass="btn btn-danger" OnClick="DeleteCart_Click"/>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Button runat="server" ID="btnCheckout" Text="Checkout" CssClass="btn btn-danger" OnClick="Checkout_Click"/>
</asp:Content>
