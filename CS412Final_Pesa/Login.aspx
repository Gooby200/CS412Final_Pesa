<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CS412Final_Pesa.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-content">
        <label class="fw-bold" for="<%= email.ClientID %>">Email</label>
        <asp:TextBox ID="email" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
        <label class="fw-bold" for="<%= pass.ClientID %>">Password</label>
        <asp:TextBox ID="pass" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
        <div class="clearfix">
            <asp:Button ID="submit" CssClass="btn btn-primary float-end btn-push-top-10" runat="server" Text="Login" />
        </div>
    </div>
</asp:Content>
