<%@ Page Title="" Language="C#" MasterPageFile="~/SystemMaster.Master" AutoEventWireup="true" CodeBehind="OrdersServices.aspx.cs" Inherits="CS412Final_Pesa.OrdersServicesPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="data-content no-margin">
                <div class="site-title">Create Order</div>
                <hr />
                <label class="fw-bold" for="<%= customerName.ClientID %>">Customer Name</label>
                <asp:TextBox ID="customerName" CssClass="form-control" runat="server"></asp:TextBox>
                <label class="fw-bold" for="<%= serviceDate.ClientID %>">Service Date</label>
                <asp:TextBox ID="serviceDate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                <label class="fw-bold">Services</label>
                <asp:CheckBoxList ID="orderServiceList" runat="server" CssClass="form-check" AutoPostBack="true"></asp:CheckBoxList>
                <div runat="server" visible="<%# orderServiceList.Items.Count <= 0 %>">
                    None
                </div>
<%--                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="mowing" />
                    <label class="form-check-label" for="mowing">Mowing - $25.00</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="cleanup" />
                    <label class="form-check-label" for="cleanup">Cleanup - $250.00</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="treetrim" />
                    <label class="form-check-label" for="treetrim">Tree Trim - $25.00</label>
                </div>--%>
                <label class="fw-bold">Price:</label> <span><asp:Literal ID="litTotal" runat="server"></asp:Literal></span>
                <div class="d-grid">
                    <asp:Button ID="createOrder" runat="server" Text="Create" CssClass="btn btn-primary btn-push-top-10" OnClick="createOrder_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <div class="data-content">
                <div class="site-title">Create Service</div>
                <hr />
                <label class="fw-bold" for="serviceName">Service Name</label>
                <asp:TextBox ID="serviceName" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                <label class="fw-bold" for="servicePrice">Service Price</label>
                <asp:TextBox ID="servicePrice" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                <div class="d-grid">
                    <asp:Button ID="createService" runat="server" Text="Create" CssClass="btn btn-primary btn-push-top-10" OnClick="createService_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
