<%@ Page Title="" Language="C#" MasterPageFile="~/SystemPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CS412Final_Pesa.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Dashboard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="numberInfo">
                <div class="site-title">Order Count</div>
                <div class="numberText">342</div>
            </div>
        </div>
        <div class="col">
            <div class="numberInfo">
                <div class="site-title">Money Collected</div>
                <div class="numberText">$50,000</div>
            </div>
        </div>
        <div class="col">
            <div class="numberInfo">
                <div class="site-title">Orders Completed</div>
                <div class="numberText">136</div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <div class="ordersTable">
                <table class="table table-sm table-striped">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Customer</th>
                            <th>Services</th>
                            <th>Price</th>
                            <th>Service Date</th>
                            <th>Delete</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>Gaston Pesa</td>
                            <td>Tree Trim, Mowing</td>
                            <td>$50.00</td>
                            <td>05/30/2021</td>
                            <td><a href="#" class="delete-mark">X</a></td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Gaston Pesa</td>
                            <td>Mowing</td>
                            <td>$25.00</td>
                            <td>05/30/2021</td>
                            <td><a href="#" class="delete-mark">X</a></td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>Gaston Pesa</td>
                            <td>Cleanup</td>
                            <td>$250.00</td>
                            <td>05/30/2021</td>
                            <td><a href="#" class="delete-mark">X</a></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
