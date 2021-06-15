<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="ImageUploadExample.aspx.cs" Inherits="CS412Final_Pesa.Examples.ImageUploadExample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <label>Upload Image</label>
        <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    <div class="row">
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <div class="col-4">
                    <asp:Image ID="Image1" Width="100%" runat="server" ImageUrl="<%# Container.DataItem %>" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
