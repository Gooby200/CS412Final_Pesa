<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Example4.aspx.cs" Inherits="CS412Final_Pesa.Example4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function foo() {
            var x = 5 / 0;
            // whole bunch of code
            console.log("step 1");
            debugger;
            // more code
            console.log("step 2");
            //more code
            console.log("step 3");
            //even more code
            console.log(x);
        }

        foo();
    </script>
</asp:Content>
