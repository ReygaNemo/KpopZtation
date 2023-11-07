<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="UpdateArtist.aspx.cs" Inherits="KpopZtationNew.View.UpdateArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-group {
            margin-top: 2vh;
        }
        .updateError {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Update Artist</h2>
        <asp:Panel ID="updateArtistPanel" runat="server">
            <div class="form-group">
                <label for="artistId">Artist ID:</label>
                <input type="text" id="artistId" name="artistId" runat="server" class="form-control" disabled/>
            </div>
            <div class="form-group">
                <label for="artistName">Artist Name:</label>
                <input type="text" id="artistName" name="artistName" runat="server" class="form-control"/>
            </div>
            <div class="form-group">
                <label for="artistImage">Artist Image:</label>
                <asp:Label ID="fileNameLabel" runat="server" CssClass="file-name-label"></asp:Label>
                <input type="file" id="artistImage" name="artistImage" runat="server" class="form-control" accept="image/*"/>
            </div>
            <div>
                <asp:Label class="text-danger" ID="updateError" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click" class="btn btn-primary"/>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
