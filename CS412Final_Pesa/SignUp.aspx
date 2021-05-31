<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CS412Final_Pesa.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="signUpForm">
        <label class="fw-bold" for="first">First Name</label>
        <input type="text" id="first" class="form-control" />
        <label class="fw-bold" for="last">Last Name</label>
        <input type="text" id="last" class="form-control" />
        <label class="fw-bold" for="email">Email</label>
        <input type="email" id="email" class="form-control" />
        <label class="fw-bold" for="pass">Password</label>
        <input type="password" id="pass" class="form-control" />
        <label class="fw-bold" for="vPass">Verify Password</label>
        <input type="password" id="vPass" class="form-control" />
        <div class="clearfix">
            <input type="submit" value="Create" class="btn btn-primary float-end" />
        </div>
    </div>
</asp:Content>
