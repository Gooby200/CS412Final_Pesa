<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CS412Final_Pesa.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-content">
        <label class="fw-bold" for="<%= email.ClientID %>">Email</label>
        <asp:TextBox ID="email" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="<%= pass.ClientID %>">Password</label>
        <asp:TextBox ID="pass" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
        <div class="clearfix">
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary float-end btn-push-top-10" OnClick="btnLogin_Click" />
        </div>
        <asp:Panel ID="errorPanel" runat="server" Visible="false">
            <asp:Label ID="lblErrors" runat="server" Text="Label" CssClass="error-message"></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>
