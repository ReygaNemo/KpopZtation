<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="ArtistDetails.aspx.cs" Inherits="KpopZtationNew.View.ArtistDetails" %>
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
        .albumInfoContainer {
            text-align: center;
        }
        .albumInfoContainer p {
            margin-bottom: 1vh;
        }
    </style>
    <script type="text/javascript">
        function imageClicked(albumId, artistId) {
            window.location.href = "AlbumDetails.aspx?albumId=" + albumId + "&artistId=" + artistId;
        }
        function insertClicked(artistId) {
            window.location.href = "InsertAlbum.aspx?artistId=" + artistId;
        }
        function updateAlbum(albumId, artistId) {
            window.location.href = "UpdateAlbum.aspx?artistId=" + artistId + "&albumId=" + albumId;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="artistImgContainer">
        <a id="translink" class="navbar-brand" href="/View/TransactionHistory.aspx" runat="server" visible="true">Transaction Press me</a>
        <h1><asp:Label ID="artistNameLabel" runat="server"></asp:Label></h1>
        <asp:Image ID="artistImage" runat="server"/>
        <hr/>
        <h2>Albums:</h2>
        <hr/>
        <asp:Repeater ID="albumsRepeater" runat="server">
            <ItemTemplate>
                <div>
                    <h3><%# Eval("AlbumName") %></h3>
                    <p><%# Eval("AlbumDescription") %></p>
                    <div class="albumImgContainer">
                        <img class="albumImg" src='<%# ResolveUrl("../Assets/Albums/" + Eval("AlbumImage")) %>'
                            data-image-id='<%# Eval("AlbumID") %>'
                            onclick='<%# "imageClicked(" + Eval("AlbumID") + ", " + Eval("ArtistID") + "); return false;" %>' />
                    </div>
                    <div class="albumInfoContainer">
                        <p>Price: <%# Eval("AlbumPrice") %></p>
                        <p>Stock: <%# Eval("AlbumStock") %></p>
                    </div>
                    <asp:Button runat="server" Text="Update" CssClass="btn btn-primary" OnClientClick='<%# "updateAlbum(" + Eval("AlbumID") + ", " + Eval("ArtistID") + "); return false;" %>' />
                </div>
                <hr/>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Button runat="server" ID="insertAlbumBtn" Text="Insert Album" CssClass="btn btn-primary" OnClick="insertAlbumBtn_Click" />
    </div>
</asp:Content>
