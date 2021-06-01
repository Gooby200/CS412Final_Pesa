<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Example3.aspx.cs" Inherits="CS412Final_Pesa.Example3Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: white;
            color: black;
            margin-bottom: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <label for="<%= name.ClientID %>">Name</label><br />
    <asp:TextBox ID="name" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
    <br />
    <br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Button ID="Button9" runat="server" Text="Button" OnClick="Button9_Click" />
    <br />
    <br />
    <asp:TextBox ID="nameStaticID" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="styledTextbox" style="background-color: red;" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="disabledTextbox" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="invisibleTextbox" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="submitButton" runat="server" Text="Submit Button" />
    <br />
    <br />
    <asp:Button ID="Button8" runat="server" Text="Disable Me" OnClick="Button8_Click" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Button3" runat="server" Text="Toggle Label Visibility" OnClick="Button3_Click" />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" PageSize="10" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <%-- will grab and implement data from the source list --%>
            <asp:BoundField HeaderText="Bound ID" DataField="Id" />

<%--             custom field that can be manipulated to load data from the 
                source into whatever element you add in here --%>
            <asp:TemplateField HeaderText="Custom ID">
                <ItemTemplate>
                    <asp:Label ID="userId" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Custom Name Column">
                <ItemTemplate>
                    <asp:Label ID="userName" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

<%--             a button that can perform any action you want upon a button click --%>
            <asp:ButtonField HeaderText="Button Action" Text="Click Me" CommandName="CLICKED" />

<%--             a command field that gives the user a bunch of abilities.
                these commands have to be handled in the backend in the same
                way as a buttonfield, but this gives a better way to manage that and provides element
                changes out of the box --%>
            <asp:CommandField HeaderText="Command Actions" ShowCancelButton="true" ShowDeleteButton="true" ShowEditButton="true" ShowInsertButton="true" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <!-- requires scrip manager -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="updatePanelLabel" runat="server" Text="Button Clicked: N/A"></asp:Label>
            <asp:Button ID="updatePanelButton" runat="server" Text="Click Me" OnClick="updatePanelButton_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <table>
        <tr>
            <th>First Name</th>
            <th>Last Name</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><asp:Label ID="repeaterFirstName" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="repeaterLastName" runat="server" Text="Label"></asp:Label></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <br />
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>User1</asp:ListItem>
        <asp:ListItem>User2</asp:ListItem>
        <asp:ListItem>User3</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Literal ID="Literal1" runat="server" Text="<script>alert('test')</script>"></asp:Literal>
    <asp:Literal ID="encodedLiteral" runat="server" Mode="Encode" Text="<script>alert('test')</script>"></asp:Literal>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">I am a link button</asp:LinkButton>
    <asp:Button ID="Button1" runat="server" Text="I am a normal button" OnClick="LinkButton1_Click" />
    <br />
    <br />
    <!-- whats the difference when this is all rendered? -->
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <input type="text" id="diffTextbox" />
    <br />
    <br />
    <asp:CheckBox ID="CheckBox1" runat="server" Text="Check Me" />
    <asp:CheckBox ID="CheckBox2" runat="server" Text="Check Me" />
    <asp:CheckBox ID="CheckBox3" runat="server" Text="Check Me" /><br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
    <asp:Button ID="Button4" runat="server" Text="Button" OnClick="Button4_Click" />
    <br />
    <br />
    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
        <asp:ListItem Value="One">Click Me</asp:ListItem>
        <asp:ListItem Value="Two">Click Me</asp:ListItem>
        <asp:ListItem Value="Three">Click Me</asp:ListItem>
    </asp:CheckBoxList>
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
    <asp:Button ID="Button5" runat="server" Text="Button" OnClick="Button5_Click"/>
    <br />
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem Value="One">Click Me</asp:ListItem>
        <asp:ListItem Value="Two">Click Me</asp:ListItem>
        <asp:ListItem Value="Three">Click Me</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
    <asp:Button ID="Button6" runat="server" Text="Button" OnClick="Button6_Click"/>
    <br />
    <br />
    <asp:RadioButton ID="RadioButton1" GroupName="RadioGroup" runat="server" Text="Click Me" />
    <asp:RadioButton ID="RadioButton2" GroupName="RadioGroup" runat="server" Text="Click Me" />
    <asp:RadioButton ID="RadioButton3" GroupName="RadioGroup" runat="server" Text="Click Me" /><br />
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label><br />
    <asp:Button ID="Button7" runat="server" Text="Button" OnClick="Button7_Click"/>
</asp:Content>
