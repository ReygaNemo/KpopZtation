<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KpopZtationNew.View.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .card {
            display: flex;
            flex-direction: column;
            width: 50vw;
            margin-left: 25vw;
            margin-top: 8vw;
            margin-bottom: 15vh;
        }
        .form-group {
            margin-top: 2vw;
            margin-bottom: 1vw;
        }
        .title {
            margin-top: 1vw;
        }
        .errorMsg {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card" id="card">
        <div class="card-body">
            <h2 class="card-title" id="title">Register</h2>
            <div class="form-group">
                <label for="nameLabel">Name</label>
                <asp:TextBox type="text" class="form-control" ID="nameField" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="emailLabel">Email address</label>
                <asp:TextBox type="email" class="form-control" ID="emailField" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="genderLabel">Gender</label>
                <asp:TextBox type="text" class="form-control" ID="genderField" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="addressLabel">Address</label>
                <asp:TextBox type="text" class="form-control" ID="addressField" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
               <label for="passwordLabel">Password</label>
                <asp:TextBox type="password" class="form-control" ID="passwordField" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label class="text-danger" ID="errorMsg" runat="server" Text=""></asp:Label>
            </div>
            <asp:Button ID="submitbtn" class="btn btn-primary" OnClick="register" runat="server" Text="Register" />
        </div>
    </div>
</asp:Content>
