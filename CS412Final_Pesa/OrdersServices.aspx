<%@ Page Title="" Language="C#" MasterPageFile="~/SystemMaster.Master" AutoEventWireup="true" CodeBehind="OrdersServices.aspx.cs" Inherits="CS412Final_Pesa.OrdersServicesPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="data-content no-margin">
                <div class="site-title">Create Order</div>
                <hr />
                <label class="fw-bold" for="customerName">Customer Name</label>
                <input class="form-control" type="text" id="customerName" />
                <label class="fw-bold" for="serviceDate">Service Date</label>
                <input class="form-control" type="date" id="serviceDate" />
                <label class="fw-bold">Services</label>
                <div class="form-check">
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
                </div>
                <label class="fw-bold">Price:</label> <span>$0.00</span>
                <div class="d-grid">
                    <input type="submit" value="Create" class="btn btn-primary btn-push-top-10" />
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
                <input type="text" class="form-control" id="serviceName" />
                <label class="fw-bold" for="servicePrice">Service Price</label>
                <input type="text" class="form-control" id="servicePrice" />
                <div class="d-grid">
                    <input type="submit" value="Create" class="btn btn-primary btn-push-top-10" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
