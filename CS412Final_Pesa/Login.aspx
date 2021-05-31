<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CS412Final_Pesa.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="loginForm">
        <label class="fw-bold" for="email">Email</label>
        <input type="email" id="email" class="form-control" />
        <label class="fw-bold" for="pass">Password</label>
        <input type="password" id="pass" class="form-control" />
        <div class="clearfix">
            <input type="submit" value="Login" class="btn btn-primary float-end" />
        </div>
    </div>
</asp:Content>
