<%@ Page Title="" Language="C#" MasterPageFile="~/SystemPage.Master" AutoEventWireup="true" CodeBehind="OrdersServices.aspx.cs" Inherits="CS412Final_Pesa.OrdersServices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/OrdersServices.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="creationPanel">
                <div class="site-title">Create Order</div>
                <hr />
                <label class="fw-bold">Customer Name</label>
                <input class="form-control" type="text" />
                <label class="fw-bold">Service Date</label>
                <input class="form-control" type="date" />
                <label class="fw-bold">Services</label>
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" value="" id="mowing">
                  <label class="form-check-label" for="mowing">
                    Mowing - $25
                  </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" value="" id="cleanup">
                  <label class="form-check-label" for="cleanup">
                    Cleanup - $250
                  </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" value="" id="treetrim">
                  <label class="form-check-label" for="treetrim">
                    Tree Trim - $25
                  </label>
                </div>
                <label class="fw-bold push-10">Price</label>
                <span>$0.00</span>
                <div class="d-grid push-10">
                    <input type="button" value="Create" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
    <div class="row push-panel">
        <div class="col">
            <div class="creationPanel">
                <div class="site-title">Create Service</div>
                <hr />
                <label class="fw-bold">Service Name</label>
                <input class="form-control" type="text" />
                <label class="fw-bold">Service Price</label>
                <input class="form-control" type="text" />
                <div class="d-grid push-10">
                    <input type="button" value="Create" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
