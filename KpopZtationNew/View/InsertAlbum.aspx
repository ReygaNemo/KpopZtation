﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="InsertAlbum.aspx.cs" Inherits="KpopZtationNew.View.InsertAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            margin-top: 6vh;
        }
        .form-group {
            margin-top: 2vh;
        }
        .insertError {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Insert Album</h2>
        <asp:Panel ID="insertAlbumPanel" runat="server">
            <div class="form-group">
                <label for="artistId">Artist ID:</label>
                <input type="text" id="artistId" name="artistId" runat="server" class="form-control" disabled/>
            </div>
            <div class="form-group">
                <label for="albumName">Album Name:</label>
                <input type="text" id="albumName" name="albumName" runat="server" class="form-control"/>
            </div>
            <div class="form-group">
                <label for="albumDescription">Album Description:</label>
                <input type="text" id="albumDescription" name="albumDescription" runat="server" class="form-control"/>
            </div>
            <div class="form-group">
                <label for="albumPrice">Album Price:</label>
                <input type="number" id="albumPrice" name="albumPrice" runat="server" class="form-control"/>
            </div>
            <div class="form-group">
                <label for="albumStock">Album Stock:</label>
                <input type="number" id="albumStock" name="albumStock" runat="server" class="form-control"/>
            </div>
            <div class="form-group">
                <label for="albumImage">Album Image:</label>
                <asp:Label ID="fileNameLabel" runat="server" CssClass="file-name-label"></asp:Label>
                <input type="file" id="albumImage" name="albumImage" runat="server" class="form-control" accept="image/*"/>
            </div>
            <div>
                <asp:Label class="text-danger" ID="insertError" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="insertButton" runat="server" Text="Insert" OnClick="insertButton_Click" class="btn btn-primary"/>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
