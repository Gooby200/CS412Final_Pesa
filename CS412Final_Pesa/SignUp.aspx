<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CS412Final_Pesa.SignUpPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-content">
        <label class="fw-bold" for="first">First Name</label>
        <input type="text" id="first" class="form-control" />
        <label class="fw-bold" for="last">Last Name</label>
        <input type="text" id="last" class="form-control" />
        <label class="fw-bold" for="email">Email</label>
        <input type="email" id="email" class="form-control" />
        <label class="fw-bold" for="pass">Password</label>
        <input type="text" id="pass" class="form-control" />
        <label class="fw-bold" for="vpass">Verify Password</label>
        <input type="text" id="vpass" class="form-control" />
        <div class="clearfix">
            <input type="submit" value="Sign Up" class="btn btn-primary float-end btn-push-top-10" />
        </div>
    </div>
</asp:Content>
