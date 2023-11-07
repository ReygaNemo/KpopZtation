<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KpopZtationNew.View.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .card {
            display: flex;
            flex-direction: column;
            width: 50vw;
            margin-left: 25vw;
            margin-top: 8vw;
        }
        .form-group {
            margin-top: 2vw;
            margin-bottom: 1vw;
        }
        .title {
            margin-top: 1vw;
        }
        .loginError {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card" id="card">
        <div class="card-body">
            <h2 class="card-title" id="title">Login</h2>
            <div class="form-group">
                <label for="emailLabel">Email address</label>
                <asp:TextBox type="email" class="form-control" ID="emailLogin" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="passwordLabel">Password</label>
                <asp:TextBox type="password" class="form-control" ID="passwordLogin" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:CheckBox ID="rememberMeCheckbox" runat="server"/>
                <label for="rememberLabel">Remember Me</label>
            </div>
            <div>
                <asp:Label class="text-danger" ID="loginError" runat="server" Text=""></asp:Label>
            </div>
            <asp:Button ID="loginbtn" class="btn btn-primary" OnClick="loginbtn_Click" runat="server" Text="Login" />
        </div>
    </div>
</asp:Content>
