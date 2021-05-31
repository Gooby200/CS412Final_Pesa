<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CS412Final_Pesa.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-content">
        <label class="fw-bold" for="email">Email</label>
        <input type="email" id="email" class="form-control" />
        <label class="fw-bold" for="pass">Password</label>
        <input type="password" id="pass" class="form-control" />
        <div class="clearfix">
            <input type="submit" value="Login" class="btn btn-primary float-end btn-push-top-10" />
        </div>
    </div>
</asp:Content>
