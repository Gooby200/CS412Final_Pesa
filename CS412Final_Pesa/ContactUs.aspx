<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="CS412Final_Pesa.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-content">
        <label class="fw-bold" for="<%= name.ClientID %>">Name</label>
        <asp:TextBox ID="name" runat="server" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="<%= email.ClientID %>">Email</label>
        <asp:TextBox ID="email" TextMode="Email" runat="server" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="<%= phone.ClientID %>">Phone</label>
        <asp:TextBox ID="phone" TextMode="Phone" runat="server" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="<%= comment.ClientID %>">Comment</label>
        <asp:TextBox ID="comment" Rows="10" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
        <div class="d-grid">
            <asp:Button ID="btnSendInfo" runat="server" Text="Send" CssClass="btn btn-primary btn-push-top-10" />
        </div>
    </div>
</asp:Content>
