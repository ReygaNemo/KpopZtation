<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="KpopZtationNew.View.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Transaction History </h1>
    <asp:Repeater ID="cartsRepeater" runat="server">
        <ItemTemplate>
            <div class="albumImgContainer">
                <img class="albumImg" src='<%# ResolveUrl("../Assets/Albums/" + Eval("AlbumPic")) %>' data-image-id='<%# Eval("AlbumID") %>' />
            </div>
            <div>
                <h3>TransactionID: <%# Eval("TransactionID") %></h3>
                <p>Price: <%# Eval("TransDate") %></p>
                <p>CustName: <%# Eval("CustomerName") %></p>
                <p>AlbumName: <%# Eval("AlbumName") %></p>
                <p>AlbumQTY: <%# Eval("Quantity") %></p>
                <p>Price: <%# Eval("Price") %></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
