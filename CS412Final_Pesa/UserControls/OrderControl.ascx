<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderControl.ascx.cs" Inherits="CS412Final_Pesa.UserControls.OrderControl" %>
<link href="../Styles/OrderControl.css" rel="stylesheet" />
<div class="orderControl">
    <div>Order #<asp:Literal ID="litOrderNumber" runat="server"></asp:Literal></div>
    <div>Customer Name: <asp:Literal ID="litCustomerName" runat="server"></asp:Literal></div>
    <div>Service Date: <asp:Literal ID="litServiceDate" runat="server"></asp:Literal></div>
    <div>Services</div>
    <div>
        <asp:Repeater ID="ServiceRepeater" runat="server" OnItemDataBound="ServiceRepeater_ItemDataBound">
            <ItemTemplate>
                <div class="service">
                    <asp:Label ID="ServiceName" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="ServicePrice" CssClass="fw-bold" runat="server" Text="Label"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div>Total: <asp:Label ID="lblTotal" CssClass="fw-bold" runat="server" Text="Label"></asp:Label></div>
</div>