<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZtationNew.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .artistImgContainer {
            display: flex;
            flex-wrap: wrap;
        }
        .artistItem {
            text-align: center;
            margin-bottom: 5vh;
        }
        .artistImg {
            width: 30vh;
            height: 30vh;
            margin-left: 2vh;
            margin-top: 2vh;
            cursor: pointer;
        }
        .artistName {
            font-weight: bold;
        }
        .artistActions {
            margin-top: 1vh;
        }
        .btn {
            margin-top: 2vh;
            margin-left: 2vh;
            margin-bottom: 6vh;
        }
    </style>
    <script type="text/javascript">
        function imageClicked(artistId) {
            window.location.href = "ArtistDetails.aspx?artistId=" + artistId;
        }
        function updateArtist(artistId) {
            window.location.href = "UpdateArtist.aspx?artistId=" + artistId;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="insertBtn" runat="server" onclick="btnInsert_Click" CssClass="btn btn-primary" Text="Insert Artist" />
    <div class="artistImgContainer">
        <asp:Repeater ID="artistRepeater" runat="server">
            <ItemTemplate>
                <div class="artistItem">
                    <img class="artistImg" src='<%# ResolveUrl("../Assets/Artists/" + Eval("ArtistImage")) %>' data-image-id='<%# Eval("ArtistID") %>' onclick='<%# "imageClicked(" + Eval("ArtistID") + "); return false;" %>' />
                    <br />
                    <span class="artistName"><%# Eval("ArtistName") %></span>
                    <div class="artistActions">
                        <asp:Button runat="server" Text="Update" CssClass="btn btn-primary" OnClientClick='<%# "updateArtist(" + Eval("ArtistID") + "); return false;" %>' />
                        <asp:Button runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="DeleteArtist_Click" ID="btnDelete" CommandArgument='<%# Eval("ArtistID") %>' />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
