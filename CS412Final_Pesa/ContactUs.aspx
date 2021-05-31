<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="CS412Final_Pesa.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contactUsForm">
        <label for="name" class="fw-bold">Name</label>
        <input id="name" type="text" class="form-control" />
        <label for="email" class="fw-bold">Email</label>
        <input id="email" type="email" class="form-control" />
        <label for="phone" class="fw-bold">Phone</label>
        <input id="phone" type="tel" class="form-control" />
        <label for="comment" class="fw-bold">Comment</label>
        <textarea id="comment" rows="10" class="form-control"></textarea>
        <div class="d-grid">
            <input type="button" value="Send" class="btn btn-primary" />
        </div>
    </div>
</asp:Content>
