<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CS412Final_Pesa.SignUpPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-content">
        <label class="fw-bold" for="<%= first.ClientID %>">First Name</label>
        <asp:TextBox ID="first" runat="server" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="<%= last.ClientID %>">Last Name</label>
        <asp:TextBox ID="last" runat="server" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="<%= email.ClientID %>">Email</label>
        <asp:TextBox ID="email" TextMode="Email" runat="server" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="<%= pass.ClientID %>">Password</label>
        <asp:TextBox ID="pass" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="<%= vpass.ClientID %>">Verify Password</label>
        <asp:TextBox ID="vpass" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
        <div class="clearfix">
            <asp:Button ID="btnSignup" runat="server" Text="Sign Up" CssClass="btn btn-primary float-end btn-push-top-10" OnClick="btnSignup_Click" />
        </div>
        <asp:Panel ID="errorPanel" runat="server" Visible="false">
            <asp:Label ID="lblErrors" runat="server" Text="Label" CssClass="error-message"></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>
