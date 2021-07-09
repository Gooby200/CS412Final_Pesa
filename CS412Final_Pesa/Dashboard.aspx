<%@ Page Title="" Language="C#" MasterPageFile="~/SystemMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CS412Final_Pesa.DashboardPage" EnableViewState="true" %>

<%@ Register Src="~/UserControls/OrderControl.ascx" TagPrefix="PESAControl" TagName="OrderControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col">
            Welcome, <asp:Literal ID="loggedInUserName" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <div class="number-info">
                <div class="site-title">Order Count</div>
                <div class="number-text"><asp:Literal ID="litOrderCount" runat="server"></asp:Literal></div>
            </div>
        </div>
        <div class="col">
            <div class="number-info">
                <div class="site-title">Money Collected</div>
                <div class="number-text">$<asp:Literal ID="litMoneyCollected" runat="server"></asp:Literal></div>
            </div>
        </div>
        <div class="col">
            <div class="number-info">
                <div class="site-title">Orders Completed</div>
                <div class="number-text"><asp:Literal ID="litOrdersCompleted" runat="server"></asp:Literal></div>
            </div>
        </div>
    </div>
    <div class="row">
        <asp:Repeater ID="OrderControlRepeater" runat="server" OnItemDataBound="OrderControlRepeater_ItemDataBound">
            <ItemTemplate>
                <div class="col-5">
                    <PESAControl:OrderControl runat="server" id="OrderControl" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="row">
        <div class="col">
            <div class="data-content">
                <p class="fw-bold">All Orders</p>
                <asp:GridView ID="gridOrderDetails" runat="server" CssClass="table table-sm table-striped" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowDataBound="gridOrderDetails_RowDataBound" OnPageIndexChanging="gridOrderDetails_PageIndexChanging" OnRowDeleting="gridOrderDetails_RowDeleting">
                    <EmptyDataTemplate>
                        No records found.
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />
                        <asp:TemplateField HeaderText="Customer">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnId" runat="server" />
                                <asp:Label ID="lblCustomerName" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Services">
                            <ItemTemplate>
                                <asp:Label ID="lblServices" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderPrice" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Service Date">
                            <ItemTemplate>
                                <asp:Label ID="lblServiceDate" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" DeleteText="X" ControlStyle-CssClass="delete-mark" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <div class="data-content">
                <p class="fw-bold">My Orders</p>
                <asp:GridView ID="MyOrdersGrid" runat="server" CssClass="table table-sm table-striped" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowDataBound="MyOrdersGrid_RowDataBound" OnPageIndexChanging="MyOrdersGrid_PageIndexChanging">
                    <EmptyDataTemplate>
                        No records found.
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />
                        <asp:TemplateField HeaderText="Customer">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnId" runat="server" />
                                <asp:Label ID="lblCustomerName" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Services">
                            <ItemTemplate>
                                <asp:Label ID="lblServices" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderPrice" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Service Date">
                            <ItemTemplate>
                                <asp:Label ID="lblServiceDate" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
