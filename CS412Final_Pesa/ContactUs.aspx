<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="CS412Final_Pesa.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-content">
        <label class="fw-bold" for="name">Name</label>
        <input type="text" id="name" class="form-control" />
        <label class="fw-bold" for="email">Email</label>
        <input type="email" id="email" class="form-control" />
        <label class="fw-bold" for="phone">Phone</label>
        <input type="tel" id="phone" class="form-control" />
        <label class="fw-bold" for="comment">Comment</label>
        <textarea id="comment" rows="10" class="form-control"></textarea>
        <div class="d-grid">
            <input type="submit" value="Send" class="btn btn-primary btn-push-top-10" />
        </div>
    </div>
</asp:Content>
